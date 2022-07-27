using MongoDB.Bson.Serialization.Attributes;

namespace TestTask.Models
{
    public class Catalog
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
    }
}
