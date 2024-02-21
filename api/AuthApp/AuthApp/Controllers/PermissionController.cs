using AuthApp.Data;
using AuthApp.Dto;
using AuthApp.Entity;
using AuthApp.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class PermissionController : BaseController
    {
        private UserService userService;

        public PermissionController(UserManager<User> userManager, AuthDBContext context, IMapper mapper) : base(context, mapper)
        {
            userService = new UserService(userManager, context, mapper);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("add-roles")]
        public async Task<IActionResult> AddRoles([FromBody] RolesDto rolesDto)
        {
            //Add Roles
            var results = await userService.AddRoles(rolesDto);

            if (!results.Succeeded)
            {
                foreach (var error in results.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return Accepted(results);
        }
    }
}
