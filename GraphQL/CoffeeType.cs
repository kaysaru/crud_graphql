using HotChocolate.Types;
using WebApplication2.Models;

namespace WebApplication2.GraphQL
{
    public class CoffeeType : ObjectType<Coffee>
    {
        protected override void Configure(IObjectTypeDescriptor<Coffee> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(c => c.Id).Type<IdType>();
            descriptor.Field(c => c.Name).Type<StringType>();
            descriptor.Field(c => c.Amount).Type<IntType>();
            descriptor.Field(c => c.Price).Type<FloatType>();
        }
    }
}
