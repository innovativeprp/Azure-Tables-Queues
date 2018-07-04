using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureTables
{
    class CarEntity:TableEntity
    {
        public CarEntity()
        {

        }
        public CarEntity(int id,string make,string model,string color)
        {
            Id = id;
            Make = make;
            Model = model;
            Color = color;
            PartitionKey = "car";
            RowKey = Id.ToString();
        }

        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
    }
}
