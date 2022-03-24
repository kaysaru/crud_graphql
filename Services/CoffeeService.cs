using WebApplication2.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication2.Services
{
    public class CoffeeService
    {
        private readonly IMongoCollection<Coffee> _coffees;

        public CoffeeService()
        {
            string connectionString = "mongodb://localhost:27017/CoffeeDatabase";
            MongoUrlBuilder connection = new MongoUrlBuilder(connectionString);
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase(connection.DatabaseName);

            _coffees = database.GetCollection<Coffee>("Coffee");
        }

        public List<Coffee> Get()
        {
            return _coffees.Find(coffee => true).ToList();
        }

        public Coffee Get(string id)
        {
            return _coffees.Find(coffee => coffee.Id == id).FirstOrDefault();
        }

        public Coffee Create(Coffee coffee)
        {
            _coffees.InsertOne(coffee);
            return coffee;
        }

        public Coffee Update(string id, Coffee coffeeIn)
        {
            _coffees.ReplaceOne(coffee => coffee.Id == id, coffeeIn);
            return coffeeIn;
        }

        public void Remove(Coffee bookIn)
        {
            _coffees.DeleteOne(coffee => coffee.Id == bookIn.Id);
        }

        public Coffee Remove(string id)
        {
            _coffees.DeleteOne(coffee => coffee.Id == id);
            return Get(id);
        }
    }
}