using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace NoSQLCosmosDemo1.Models
{
    internal class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public int Age { get; set; }
    }
    [BsonIgnoreExtraElements] // För att ignorera som kraschar
    internal class Address
    {
        public string City { get; set; }
        public string ZipCode { get; set; }
        
        // public string StreetAddress { get; set; }
    }
}
