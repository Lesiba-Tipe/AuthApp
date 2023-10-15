using AuthApp.Data;
using AuthApp.Dto;
using AuthApp.Entity;
using AuthApp.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AuthApp.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : BaseController
    {
        private readonly ILogger<BuildingController> logger;       
        private readonly BuildingService buildingService;

        public BuildingController(
            ILogger<BuildingController> logger,
            AuthDBContext context,
            IMapper mapper          
            ) : base(context,mapper)
        {
            this.logger = logger;
            buildingService = new BuildingService(context);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] BuildingDto buildingDto)
        {
            try
            {
                var building = mapper.Map<Building>(buildingDto);

                var buildings = buildingService.dbSet.Where(x => x.Name == building.Name && x.Code == building.Code).FirstOrDefault();

                if (buildings != null)
                {
                    return BadRequest("Building with same name Exist in current Property");

                }


                var results = await buildingService.Insert(building);

                if (results == null)
                {
                    return BadRequest("Could not create Building");
                    
                }

                await buildingService.CompleteAsync();
                return Accepted("Succeded");

            }
            catch (Exception ex)
            {

                var msg = ex.Message.ToString();
                throw new Exception(msg);
            }
        }
    }
}
