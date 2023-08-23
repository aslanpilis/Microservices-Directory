using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directory.Business.Implementation
{
    public class ContactInfoCreateDto
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int Location { get; set; }
    }
}
