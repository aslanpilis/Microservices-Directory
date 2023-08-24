using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Services.Model
{
    public class ReportUpdate
    {
        public string Id { get; set; }

        public int UserCount { get; set; }

        public int PhoneCount { get; set; }

        public int Status { get; set; }

        public DateTime UptedTime { get; set; }
    }
}
