using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TestTask.Models
{
    public class Entity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int BIN { get; set; }
        public DateTime FoundationDate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public object Photo { get; set; }
        public int KRP { get; set; }
        public string Occupation { get; set; }
        public string Description { get; set; }
        public int EmployeeNumber { get; set; }
    }
}
