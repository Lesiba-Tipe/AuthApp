using AuthApp.Data;
using AuthApp.Dto;
using AuthApp.Entity;
using AuthApp.Service;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AuthApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly ILogger<AccountController> logger;
        private readonly IMapper mapper;
        private readonly AuthBDContext context;
        private readonly UserManager<User> userManager;
        private readonly IAuthManager authManager;

        public AccountController(
            UserManager<User> userManager, 
            ILogger<AccountController> logger,
            AuthBDContext context,
            IAuthManager authManager
            //IMapper mapper
            )
        {
            this.userManager = userManager;
            this.logger = logger;
            //this.mapper = mapper;
            this.context = context;
            this.authManager = authManager;
        }


        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] User userDto)
        {
            logger.LogInformation($"Registration attempt for {userDto.Email}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //map data
            //userDto.PasswordHash = "Mildret@10";
            try
            {
                //var user = mapper.Map<User>(userDto);
                var results = await userManager.CreateAsync(userDto, userDto.PasswordHash);

                if (!results.Succeeded)
                {
                    foreach (var error in results.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                
                return Accepted(userDto);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"something went wrong {nameof(Register)}");
                return StatusCode(500, $"Internl server Error");
            }

        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LogInDto userDto)
        {
            logger.LogInformation($"Login attempt for {userDto.Email}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if(!await authManager.ValidateUser(userDto))
                {
                    return Unauthorized();
                }
                var user = await userManager.FindByEmailAsync(userDto.Email);

                return Accepted(authManager.GenerateJwtToken(userDto.Email));  //Return Authorization here...
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"something went wrong {nameof(Register)}");
                return StatusCode(500, $"Internl server Error {ex.Message}");
            }
        }
    }
}
