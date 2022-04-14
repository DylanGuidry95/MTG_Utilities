using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace AWSCommunication
{
    public class DynamoCommunication
    {
        private AmazonDynamoDBClient _client;

        public DynamoCommunication()
        {            
            _client = new AmazonDynamoDBClient();
        }

        public async Task<Dictionary<string,dynamic>> TryCreateTable(string tableName, List<KeyValuePair<string,string>> attributes, List<KeyValuePair<string, string>> schemas)
        {
            var currentTables = await _client.ListTablesAsync();
            if (currentTables.TableNames.Contains(tableName))
                return new Dictionary<string, dynamic> { { "Error", $"Table {tableName} already exists on the server" } };
            var atrList = new List<AttributeDefinition>();
            foreach(var atr in attributes)
            {
                atrList.Add(new AttributeDefinition() { AttributeName = atr.Key, AttributeType = atr.Value });
            }

            var schemaList = new List<KeySchemaElement>();
            foreach(var schema in schemas)
            {
                schemaList.Add(new KeySchemaElement() { AttributeName = schema.Key, KeyType = schema.Value });
            }

            var request = new CreateTableRequest
            {
                TableName = tableName,
                AttributeDefinitions = atrList,
                KeySchema = schemaList,
                ProvisionedThroughput = new ProvisionedThroughput
                { 
                    ReadCapacityUnits = 10,
                    WriteCapacityUnits = 5
                }
            };

            var response = await _client.CreateTableAsync(request);            
            return new Dictionary<string, dynamic> { { "Success", $"Table {tableName} created successfully" } };
        }
    }
}
