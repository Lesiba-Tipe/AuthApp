using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Dto
{
    public class EmailDto
    {
        private string firstname;
        private int code;
        public EmailDto(string firstname, int code)
        {
            this.firstname = firstname;
            this.code = code;
        }
        
        public string Body { get; set;}

        public string Subject { get; set; } = "AuthApp Confirmation";
    }
}
