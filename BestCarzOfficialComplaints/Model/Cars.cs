using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BestCarzOfficialComplaints.Model
{
    [BsonIgnoreExtraElements]
    public class Cars
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public string Userid { get; set; }
        public string Username { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Year { get; set; }
        public RepairLog[] RepairLog { get; set; }
      

    }
}