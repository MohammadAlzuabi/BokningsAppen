using MongoDB.Driver;

namespace NoSQLCosmosDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            while (true)
            {
                string[] FirstName = { "Anna", "Johan", "Lisa", "Gunnar" };
                string[] LastName = { "Svensson", "Andersson", "Lundström", "Björk" };
                string[] City = { "Stockholm", "Göteborg", "Malmö", "Sundsvall" };

                var person = new Models.Person
                {
                    Id = Guid.NewGuid(), // välja id slumptal
                    Name = FirstName[rnd.Next(0, 4)] + " " + LastName[rnd.Next(0, 4)],
                    Age = rnd.Next(18, 65), 
                    Address = new Models.Address
                    {
                        City = City[rnd.Next(0,4)],
                        ZipCode = rnd.Next(1000,9999).ToString() // Gör om till en string
                        //StreetAddress = "Storgatan 34"
                    }
                };

                Connection.PepoleCollection().InsertOne(person);

                var allPerson = Connection.PepoleCollection().
                                                AsQueryable().
                                                Where(p => p.Age > 0).
                                                ToList(); // Hämta person lista (Läsa ut)
                foreach(var p in allPerson)
                {
                    Console.WriteLine($"{p.Id} {p.Name} {p.Address.City}  {p.Age}"); // {p.Address.StreetAddress}
                }
                Guid guid = Guid.Parse("0d7e2cb3-8467-4bcc-844d-a7e61ef10977");

                var singlePerson = Connection.PepoleCollection().AsQueryable().SingleOrDefault(x => x.Id == guid);
                Console.WriteLine($"Utvaldperson {singlePerson.Name}");

                singlePerson.Age = 25;
              //singlePerson.Address.City = "Nyköping"; // Fungerar inte eftersom Shard Key
                Connection.PepoleCollection().ReplaceOne(x => x.Id == singlePerson.Id, singlePerson); //Update ålder till 25

              //Connection.PepoleCollection().DeleteOne(x => x.Id == singlePerson.Id); // Delete

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}