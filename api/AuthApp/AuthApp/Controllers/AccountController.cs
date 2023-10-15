using AuthApp.Data;
using AuthApp.Dto;
using AuthApp.Entity;
using AuthApp.Service;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly ILogger<AccountController> logger;
        //private readonly AuthDBContext context;
        private readonly UserManager<User> userManager;
        private readonly IAuthManager authManager;
        private readonly UserService userService;

        private readonly IConfiguration configuration;
        private IEmailService emailService;

        public AccountController(
            UserManager<User> userManager,
            ILogger<AccountController> logger,
            IAuthManager authManager,
            IEmailService emailService,
            AuthDBContext context,
            IMapper mapper,
            IConfiguration configuration
            ) : base(context, mapper)
        {
            this.userManager = userManager;
            this.logger = logger;
            this.authManager = authManager;
            this.emailService = emailService;
            this.configuration = configuration;
            userService = new UserService(userManager, context, mapper);
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

            try
            {

                var results = await userService.CreateAsync(mapper.Map<User>(userDto), userDto.Password);

                if (!results.Succeeded)
                {
                    foreach (var error in results.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }

                await context.SaveChangesAsync();
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
        public async Task<IActionResult> Login([FromBody] LogInDto loginDto)
        {
            logger.LogInformation($"Login attempt for {loginDto.Email}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (!await authManager.ValidateUserWithPassword(loginDto))
                {
                    return Unauthorized("Incorrect Username or password");
                }


                var user = await userService.FindByEmailAsync(loginDto.Email);
                var roles = await userService.GetRolesAsync(user);

                //var token = 
                var results = new { jwtToken = "Bearer " + await authManager.GenerateJwtToken(user), roles = roles, id = user.Id };

                return Accepted(results);
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

            try
            {
                //Validate if user Exist

                //map User data
                var user = mapper.Map<User>(userDto);

                var results = await userService.CreateAsync(user);

                if (!results.Succeeded)
                {
                    foreach (var error in results.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }

                context.SaveChanges();
                //var rolesResults = await userService.AddRoles(userDto);
                return Accepted(userDto);
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
                if (!await userService.UserExist(googleDto.Email))
                {
                    return Unauthorized("Please sign up, Your email could not be found");
                }

                var user = await userService.FindByEmailAsync(googleDto.Email);
                var roles = await userService.GetRolesAsync(user);
                //var token = 
                var results = new { jwtToken = "Bearer " + await authManager.GenerateJwtToken(user), roles = roles, id = user.Id };

                return Accepted(results);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"something went wrong {nameof(Register)}");
                return StatusCode(500, $"Internl server Error {ex.Message}");
            }
        }

        [HttpPost]
        [Route("request-otp")]
        public async Task<IActionResult> RequestOTP([FromBody] EmailDto emailDto)
        {
            var code = new Random().Next(111111, 999999);

            var user = await userService.FindByEmailAsync(emailDto.Email);

            var _emailDto = new EmailDto
            {
                Email = user.Email,
                Body = emailService.EmailBodyConfirm(user.Firstname, code)

            };

            await emailService.GoogleSMTP(_emailDto);

            return Accepted();
        }

        [HttpPost]
        [Route("request-password-token")]
        public async Task<IActionResult> RequestPasswordToken([FromBody] RequestPasswordDto requestPasswordDto)
        {
            //Request Token
            var user = await userService.FindByEmailAsync(requestPasswordDto.Email);

            if (user == null)
                return BadRequest("User does exist in current database");

            var token = await authManager.RequestPasswordToken(requestPasswordDto);

            var param = new Dictionary<string, string?>
            {
                {"token", token },
                {"email", requestPasswordDto.Email }
            };

            var urlToken = QueryHelpers.AddQueryString(
                configuration.GetSection("AngularClient").GetSection("ResetPasswordURL").Value, 
                param);

            var emailDto = new EmailDto
            {
                Email = user.Email,
                Body = emailService.EmailBodySendPasswordToken(user.Firstname, urlToken),

            };
            //Send Email
            await emailService.GoogleSMTP(emailDto);

            return Accepted();
        }

        [HttpPost]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            // Request Token | Email | Token | Password

            var user = userService.FindByEmailAsync(resetPasswordDto.Email);
            if (user == null)
                return NotFound();

            var results = await authManager.ResetPassword(resetPasswordDto);

            if (!results.Succeeded)
            {
                //foreach (var error in results.Errors)
                //{
                //    ModelState.AddModelError(error.Code, error.Description);
                //}
                var errors = results.Errors.Select(e => e.Description);
                return BadRequest(new { Errors = errors });
                //return BadRequest(ModelState);
            }
            
            return Ok();
        }
    }
}
