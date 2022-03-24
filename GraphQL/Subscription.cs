using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.GraphQL
{
    public class Subscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Coffee>> OnCoffeeCreated([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, Coffee>("CoffeeCreated", cancellationToken);
        }
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<List<Coffee>>> OnCoffeesGet([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, List<Coffee>>("ReturnedCoffees", cancellationToken);
        }
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Coffee>> OnCoffeeGet([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, Coffee>("ReturnedCoffee", cancellationToken);
        }
    }
}