using AuthApp.Data;
using AuthApp.Entity;
using AuthApp.Repository;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

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
