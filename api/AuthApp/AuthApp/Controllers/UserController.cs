using AuthApp.Data;
using AuthApp.Dto;
using AuthApp.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using AuthApp.Service;


namespace AuthApp.Controllers
{
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        //private readonly UserManager<User> userManager;
        private UserService userService;
        public UserController(UserManager<User> userManager, AuthDBContext context, IMapper mapper) : base(context,mapper)
        {
            //this.userManager = userManager;

            userService = new UserService(userManager, context, mapper);
        }

        [AllowAnonymous]
        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            if (context == null)
                return NotFound();

            var users = await userService.GetAll();

            if (User == null)
                return NotFound();

            return Accepted(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(string id)
        {
            if (context == null)
                return NotFound();

            var user = await userService.FindById(id);

            if (user == null)
                return NotFound();

            var roles = await userService.GetRolesAsync(user);

            //Map Data
            var userDto = mapper.Map<UserDto>(user);
            userDto.Roles = roles;

            return userDto;
        }

        [AllowAnonymous]
        [HttpPut("update/{id}")]
        //[Route("update")]
        public async Task<ActionResult<UserDto>> UpdateUser(string id, [FromBody]UserDto userDto)
        {

            if (id != userDto.Id)
                return BadRequest("Content did not match subject");

            try 
            {
                await userService.Update(userDto);

                var results = await context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!EntryExist(id))
                    return NotFound(ex);
                else
                    throw;
            }

            return NoContent();
        }
        
        private bool EntryExist(string email)
        {
            return (context.Users?.Any(user => user.Email == email)).GetValueOrDefault();
        }
       
        [AllowAnonymous]
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
