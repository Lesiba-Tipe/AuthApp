using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Dto
{
    public class EmailDto
    {        
        //public int Code { get; set;}
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
