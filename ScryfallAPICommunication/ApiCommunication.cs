using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace ScryfallAPICommunication
{
    public class ApiCommunication : IDisposable
    {
        private IntPtr handle;
        private HttpClient _client;
        private string _endPointUrl;
        private bool disposed = false;
        public static ApiCommunication instance { get; private set; }

        public ApiCommunication(string endPoint)
        {
            if (instance != null && instance != this)
                Dispose();
            else
            {
                instance = this;
            }
            _client = new HttpClient();
            _endPointUrl = endPoint;
            _client.BaseAddress = new Uri(endPoint);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Dictionary<string, dynamic>> PostToBackEnd(string method, Dictionary<string, dynamic> args)
        {
            try
            {
                var response = await _client.PostAsJsonAsync(method, args);
                var result = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(result);
            }
            catch(Exception e)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(e.Message);
            }
        }

        public async Task<Dictionary<string,dynamic>> FetchFromBackEnd(string method)
        {            
            try
            {
                var response = await _client.GetStringAsync(method);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(response);
            }
            catch(Exception e)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(e.Message);
            }
        }        

        #region MemoryCleanUp
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {            
            if (!this.disposed)
            {                
                if (disposing)
                {                    
                    _client.Dispose();
                }

                CloseHandle(handle);
                handle = IntPtr.Zero;

                disposed = true;
            }
        }
        
        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);
        
        ~ApiCommunication()
        {
            Dispose(disposing: false);
        }
        #endregion
    }
}
