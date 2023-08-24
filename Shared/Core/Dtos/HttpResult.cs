using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class HttpResult
    {
        public string exceptionMessage { get; set; }
        public string Result { get; set; }
        public bool Status { get; set; } = true;
        public int statusCode { get; set; }
    }
}
