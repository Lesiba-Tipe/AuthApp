using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Dto
{
    public class BuildingDto
    {
        public string Id { get; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public int Floors { get; set; }
        public int Code { get; set; }   //Represent the Property name, Buildings cannot have same name in the same Property

    }
}
