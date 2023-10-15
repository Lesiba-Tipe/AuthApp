using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Entity
{
    public class Building
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Floors { get; set; }
        public int Code { get; set; }
    }
}
