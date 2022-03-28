using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BestCarzOfficialComplaints.Model
{
    [BsonIgnoreExtraElements]
    public class Videos
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
    }

   }