using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Entities.Entity
{
    public class Reports
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public int UserCount { get; set; }

        public int PhoneCount { get; set; }

        public string Location { get; set; }

        public string UserId { get; set; }


        public int Status { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedTime { get; set; }
        
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime UptedTime { get; set; }
    }
}
