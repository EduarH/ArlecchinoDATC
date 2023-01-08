using Microsoft.WindowsAzure.Storage.Table;
using System.Numerics;
using Microsoft.WindowsAzure.Storage;

namespace DATC_Arlecchino.Models
{
    public class AlertRepo : AzureTable
    {
        public List<Alert> AlertList = new List<Alert>();

        public AlertRepo(string storageAccount, string storageKey, string tableName) :
            base(storageAccount, storageKey, tableName)
        {
            Console.WriteLine("A connection to the table named: " + tableName + " has been established\n");
        }

        public async Task<List<Alert>> GetAllAlerts()
        {
            CloudTable table = await GetTable();
            TableQuery<Alert> query = new TableQuery<Alert>();
           
            List<Alert> alertList = new List<Alert>();


            TableContinuationToken continuationToken = null;

            do
            {
                TableQuerySegment<Alert> queryResults =
                    await table.ExecuteQuerySegmentedAsync(query,
                        continuationToken);
                continuationToken = queryResults.ContinuationToken;
                alertList.AddRange(queryResults.Results);
            } while (continuationToken != null);

            return alertList;
        }

        public async Task InsertAlert(Alert alert)
        {
            CloudTable table = await GetTable();
            TableOperation insert_operation = TableOperation.Insert((ITableEntity)alert);
            await table.ExecuteAsync(insert_operation);
        }

    }
}
