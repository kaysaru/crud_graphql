using HotChocolate;
using HotChocolate.Subscriptions;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.GraphQL
{
    public class Query
    {
        public async Task<List<Coffee>> GetAllCoffees([Service] CoffeeService coffeeService, [Service] ITopicEventSender eventSender)
        {
            List<Coffee> coffees = coffeeService.Get();
            await eventSender.SendAsync("ReturnedCoffees", coffees);
            return coffees;
        }
        public async Task<Coffee> GetCoffeeById([Service] CoffeeService coffeeService, [Service]ITopicEventSender eventSender, string id)
        {
            Coffee coffee = coffeeService.Get(id);
            await eventSender.SendAsync("ReturnedCoffee", coffee);
            return coffee;
        }
    }
}
