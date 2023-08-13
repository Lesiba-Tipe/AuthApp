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

namespace AuthApp.Controllers
{
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly AuthBDContext context;

        public UserController(UserManager<User> userManager, AuthBDContext context)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            if (context == null)
                return NotFound();

            return await GetAllUser();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(string id)
        {
            if (context == null)
                return NotFound();

            var user = await context.Users.FindAsync(id);

            if (user == null)
                return NotFound();

            //Map Data
            var userDto = new UserDto()
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Roles = null,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            return userDto;
        }

        [HttpPut("{id}")]
        //[Route("update")]
        public async Task<ActionResult<UserDto>> UpdateUser(string id, UserDto userDto)
        {
            var user = new User();

            //Map Data
            var _user = new User()
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            if (id != user.Id)
                return BadRequest();

            context.Entry(user).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntryExist(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        private async Task<List<User>> GetAllUser()
        {
            return await context.Users.ToListAsync();
        }

        private bool EntryExist(string email)
        {
            return (context.Users?.Any(user => user.Email == email)).GetValueOrDefault();
        }

    }
}
