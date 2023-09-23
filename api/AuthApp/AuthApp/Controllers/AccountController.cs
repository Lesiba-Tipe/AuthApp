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
using System.Collections.Generic;
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
        private IEmailConfirmService emailConfirmService;

        public AccountController(
            UserManager<User> userManager, 
            ILogger<AccountController> logger,
            AuthBDContext context,
            IAuthManager authManager,
            IEmailConfirmService emailConfirmService
            //IMapper mapper
            )
        {
            this.userManager = userManager;
            this.logger = logger;
            //this.mapper = mapper;
            this.context = context;
            this.authManager = authManager;
            this.emailConfirmService = emailConfirmService;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            logger.LogInformation($"Registration attempt for {userDto.Email}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //map User data

            var user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Firstname = userDto.Firstname,
                Lastname = userDto.Lastname,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                UserName = userDto.Password
            };

            try
            {                
                //var user = mapper.Map<User>(userDto);

                var results = await userManager.CreateAsync(user, userDto.Password);

                if (!results.Succeeded)
                {
                    foreach (var error in results.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }

                
                var roles = new List<string>();
                if (userDto.Roles == null)
                {
                    roles.Add("User");   //Set Default Role if Null
                }
                else
                {
                    foreach (var role in userDto.Roles)
                    {
                        roles.Add(role);
                    }
                }
                
                await userManager.AddToRolesAsync(user, roles);

                return Accepted(user);
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
                if(!await authManager.ValidateUserWithPassword(userDto))
                {
                    return Unauthorized();
                }
                var user = await userManager.FindByEmailAsync(userDto.Email);
                var roles = await userManager.GetRolesAsync(user);

                //var token = 
                var results = new { jwtToken = "Bearer " + await authManager.GenerateJwtToken(), roles = roles, id = user.Id };

                return Accepted(results);

                //return Accepted(results);  //Return Authorization here...
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"something went wrong {nameof(Register)}");
                return StatusCode(500, $"Internl server Error {ex.Message}");
            }
        }

        [HttpPost]
        [Route("google-sign-up")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SignUpWithGoogle([FromBody] UserDto userDto)
        {
            logger.LogInformation($"Registration attempt for {userDto.Email}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //map User data

            var user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Firstname = userDto.Firstname,
                Lastname = userDto.Lastname,
                Email = userDto.Email,
                PhoneNumber = null,
                UserName = userDto.Email
                
            };

            try
            {              
                //var user = mapper.Map<User>(userDto);
                var results = await userManager.CreateAsync(user);

                if (!results.Succeeded)
                {
                    foreach (var error in results.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }

                var roles = new List<string>();
                if (userDto.Roles == null)
                {
                    roles.Add("User");   //Set Default Role if Null
                }
                else
                {
                    foreach (var role in userDto.Roles)
                    {
                        roles.Add(role);
                    }
                }

                await userManager.AddToRolesAsync(user, roles);

                return Accepted(user);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"something went wrong {nameof(Register)}");
                return StatusCode(500, $"Internl server Error");
            }
        }

        [HttpPost]
        [Route("google-sign-in")]
        public async Task<IActionResult> LoginWithGoogle([FromBody] GoogleDto googleDto)
        {
            logger.LogInformation($"Login attempt for {googleDto.Email}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (!await authManager.ValidateUserWithEmail(googleDto.Email))
                {
                    return Unauthorized();
                }

                var user = await userManager.FindByEmailAsync(googleDto.Email);
                var roles = await userManager.GetRolesAsync(user);

                //var token = 
                var results = new { jwtToken = "Bearer " + await authManager.GenerateJwtToken(), roles = roles, id = user.Id };

                return Accepted(results);

                //return Accepted(results);  //Return Authorization here...
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"something went wrong {nameof(Register)}");
                return StatusCode(500, $"Internl server Error {ex.Message}");
            }
        }

        [HttpPost]
        [Route("request-otp")]
        public IActionResult RequestOTP([FromBody] EmailDto emailDto)
        {
            var code = new Random().Next(111111, 999999);

            emailConfirmService.GoogleSMTP(emailDto, code);

            return Accepted(new EmailDto() { Code = code, });
        }
    }
}
