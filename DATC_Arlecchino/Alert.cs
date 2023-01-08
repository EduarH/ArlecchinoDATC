using DATC_Arlecchino.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace DATC_Arlecchino
{
    public class Alert: TableEntity
    {

        public string Title { get; set; }
        public string Text { get; set; }

        public string Latitudine { get; set; }
        public string Longitudine { get; set; }


        public Alert()
        {
            this.PartitionKey = "-";
            this.RowKey = "-";
            this.Latitudine = "-";
            this.Longitudine = "-";
            this.Title = "-";
            this.Text = "-";
        }

        public Alert(string partitionKey, string rowKey, string latitudine, string longitudine, string title,string text)
        {
            this.PartitionKey = partitionKey;
            this.RowKey = rowKey;
            this.Latitudine = latitudine;
            this.Longitudine = longitudine;
            this.Title = title;
            this.Text = text;
        }


        //public Citizen Citizen { get; set; }
        //public Category Category { get; set; }
    }
}
