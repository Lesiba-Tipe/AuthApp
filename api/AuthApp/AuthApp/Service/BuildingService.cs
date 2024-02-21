using AuthApp.Data;
using AuthApp.Entity;
using AuthApp.Repository;
using Microsoft.Extensions.Logging;

namespace AuthApp.Service
{   

    public class BuildingService : GenericRepository<Building>, ICompleteTask
    {
        protected readonly ILogger logger;
        public BuildingService(AuthDBContext context) : base(context)
        {
            //this.logger = logger;
        }       
    }
}
