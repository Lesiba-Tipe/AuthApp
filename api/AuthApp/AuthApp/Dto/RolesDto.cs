using System.Collections.Generic;

namespace AuthApp.Dto
{
    public class RolesDto
    {
        public RolesDto(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
        public List<string> Roles { get; set; }
    }
}
