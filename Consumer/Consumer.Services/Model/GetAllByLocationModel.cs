using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Services.Model
{
    public class GetAllByLocationModel
    {

      
            public Data data { get; set; }
            public object errors { get; set; }
       
       


    }

    public class Data
    {
        public int userCount { get; set; }
        public int phoneCount { get; set; }
        public string location { get; set; }
    }
}
