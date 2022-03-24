using HotChocolate;
using HotChocolate.Types;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication2.Models
{
    public class Coffee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [GraphQLType(typeof(NonNullType<IdType>))]
        public string Id { get; set; }

        [BsonElement("Name")]
        [GraphQLType(typeof(NonNullType<StringType>))]
        public string Name { get; set; }
        [GraphQLNonNullType]
        public int Amount { get; set; }
        public float Price { get; set; }
    }
}
