using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Entities.Dtos
{
    public class ReportCreateDto
    {
        public string UserId { get; set; }

        public string Location { get; set; }
        public int Status { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
