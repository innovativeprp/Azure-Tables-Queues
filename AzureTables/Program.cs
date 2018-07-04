using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Configuration;


namespace AzureTables
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings.Get("StorageConnectionString"));
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable cloudTable = tableClient.GetTableReference("FirstTable");
            cloudTable.CreateIfNotExists();
             
            var carEntity = new CarEntity(3, "Honda", "Civic", "MSG");
            // InsertCarData(cloudTable, carEntity);

            //RetrieveCarData(cloudTable);
            CarEntityQuery(cloudTable);

            Console.WriteLine("Completed");
            Console.ReadKey();
        }

        private static void InsertCarData(CloudTable table,CarEntity carEntity)
        {
            TableOperation operation = TableOperation.Insert(carEntity);
            table.Execute(operation);
        }
        private static void RetrieveCarData(CloudTable table)
        {
            TableOperation operation = TableOperation.Retrieve<CarEntity>("car", "3");
            TableResult result = table.Execute(operation);
            
            if(result.Result==null)
            {
                Console.WriteLine("Car not found!!!");
            }
            CarEntity retrievedCar = (CarEntity)(result.Result);
            Console.WriteLine($"Car found with model {retrievedCar.Model} , make is {retrievedCar.Make} and color is {retrievedCar.Color}");
        }

        private static void CarEntityQuery(CloudTable table)
        {
            var query = new TableQuery<CarEntity>();
          foreach(var item in table.ExecuteQuery(query))
            {
                Console.WriteLine($"Car make is {item.Make} and model is {item.Model}");
            }
        }
    }
}
