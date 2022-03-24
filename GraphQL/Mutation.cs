using HotChocolate;
using HotChocolate.Subscriptions;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.GraphQL
{
    public class Mutation
    {
        public async Task<Coffee> CreateCoffee([Service] CoffeeService coffeeService, [Service] ITopicEventSender eventSender, string id, string name, int amount, float price)
        {
            var data = new Coffee
            {
                Id = id,
                Name = name,
                Amount = amount,
                Price = price
            };
            var result = coffeeService.Create(data);
            await eventSender.SendAsync("CoffeeCreated", result);
            return result;
        }

        public void UpdateCoffee([Service] CoffeeService coffeeService, [Service] ITopicEventSender eventSender, string id, string name, int amount, float price)
        {
            var data = coffeeService.Get(id);
            data.Name = name;
            data.Amount = amount;
            data.Price = price;
            coffeeService.Update(id, data);
        }

        public void DeleteCoffee([Service] CoffeeService coffeeService, [Service] ITopicEventSender eventSender, string id)
        {
            coffeeService.Remove(id);
        }
    }
}
