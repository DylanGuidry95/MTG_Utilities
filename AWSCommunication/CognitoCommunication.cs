using System.Collections.Generic;
using Amazon.Extensions.CognitoAuthentication;
using Amazon.CognitoIdentity;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using System;
using System.Threading.Tasks;

namespace AWSCommunication
{
    public class CognitoCommunication
    {        
        private string _identityPool;
        private string _appClientId;
        private string _userPoolId;

        private CognitoUser _activeUser;
        private string _activeUserId;
        public string ActiveUserBearerToken => _activeUser.SessionTokens.AccessToken;
        public string ActiveUserName => _activeUser.Username;

        private AmazonCognitoIdentityProviderClient _client;
        private CognitoAWSCredentials _cognitoCredentials;

        public CognitoCommunication(string idPool, string appClientId, string userPoolId, Amazon.RegionEndpoint endpoint)
        {
            _appClientId = appClientId;
            _identityPool = idPool;
            _userPoolId = userPoolId;
            _client = new AmazonCognitoIdentityProviderClient(new Amazon.Runtime.AnonymousAWSCredentials(), endpoint);            
        }

        public async Task<Dictionary<string, string>> SignUp(string username, string email, string password)
        {
            SignUpRequest signUpRequest = new SignUpRequest()
            {
                ClientId = _appClientId,
                Username = username,                
                Password = password
            };
            
            List<AttributeType> attributes = new List<AttributeType>
              {
                 new AttributeType(){
                    Name = "email", Value = email
                 },
                 new AttributeType(){
                    Name = "preferred_username", Value = username
                 }
            };
            signUpRequest.UserAttributes = attributes;

            try
            {
                var response = await _client.SignUpAsync(signUpRequest);
                return new Dictionary<string, string>
                {
                    { "Message", "Account created, check email for verification code"}
                };
            }
            catch (Exception e)
            {
                return new Dictionary<string, string>
                {
                    {"Message", $"Signup failed: {e.Message}" }
                };
            }
        }

        public async Task<Dictionary<string, string>> ConfirmRegistration(string username, string code)
        {
            var request = new ConfirmSignUpRequest
            {
                ClientId = _appClientId,
                ConfirmationCode = code,
                Username = username
            };

            try
            {
                var response = await _client.ConfirmSignUpAsync(request);
                return new Dictionary<string, string>
                {
                    {"Message", "User Confirmed, please log in" }
                };
            }
            catch(Exception e)
            {
                return new Dictionary<string, string>
                {
                    {"Message", $"Confirmation Failed: {e.Message}" }
                };
            }
        }

        public async Task<Dictionary<string, string>> Login(string username, string password)
        {
            var userPool = new CognitoUserPool(_userPoolId, _appClientId, _client);
            var user = new CognitoUser(username, _appClientId, userPool, _client);

            var authRequest = new InitiateSrpAuthRequest()
            {
                Password = password
            };

            try
            {
                var authFlowResponse = await user.StartWithSrpAuthAsync(authRequest).ConfigureAwait(false);

                _activeUserId = await GetUserIdFromProvider(authFlowResponse.AuthenticationResult.AccessToken);
                
                _cognitoCredentials = user.GetCognitoAWSCredentials(_identityPool, _client.Config.RegionEndpoint);

                _activeUser = user;                

                return new Dictionary<string, string>
                {
                    { "Message", $"User {username} has been successfully logged in"}
                };
            }
            catch (Exception e)
            {
                return new Dictionary<string, string>
                {
                    { "Message", $"Log in failed: {e.Message}"}
                };
            }
        }

        private async Task<string> GetUserIdFromProvider(string accessToken)
        {            
            string subId = "";

            Task<GetUserResponse> responseTask =
               _client.GetUserAsync(new GetUserRequest
               {
                   AccessToken = accessToken
               });

            GetUserResponse responseObject = await responseTask;
            
            foreach (var attribute in responseObject.UserAttributes)
            {
                if (attribute.Name == "sub")
                {
                    subId = attribute.Value;
                    break;
                }
            }

            return subId;
        }
    }
}
