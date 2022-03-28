using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestCarzOfficialComplaints.Model
{
    [BsonIgnoreExtraElements]
    public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public string Username { get; set; }
        public string password { get; set; }
        public bool active { get; set; }
        public DateTime? lastlogin { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public bool Ismechanic { get; set; }
        public string[] Carspeciality { get; set; }
        public bool Issparepartdealer { get; set; }
        public string[] Spareparts { get; set; }
        public string MechanicCategory { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ImageUrl { get; set; }
    }

   }