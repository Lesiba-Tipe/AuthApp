using AuthApp.Data;
using AuthApp.Dto;
using AuthApp.Entity;
using AuthApp.Input;
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
        public async Task<IActionResult> Register([FromBody] RegisterInput registerInput)
        {
            logger.LogInformation($"Registration attempt for {registerInput.Email}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                var results = await userService.CreateAsync(mapper.Map<User>(registerInput), registerInput.Password);

                if (!results.Succeeded)
                {
                    foreach (var error in results.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }

                //await context.SaveChangesAsync();

                return Accepted(registerInput);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"something went wrong {nameof(Register)}");
                return StatusCode(500, $"Internl server Error");
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginInput loginInput)
        {
            logger.LogInformation($"Login attempt for {loginInput.Email}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (!await authManager.ValidateUserWithPassword(loginInput))
                {
                    return Unauthorized("Incorrect Username or password");
                }


                var user = await userService.FindUserByEmailAsync(loginInput.Email);
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
        public async Task<IActionResult> SignUpWithGoogle([FromBody] GoogleRegisterInput googleRegisterInput)
        {
            logger.LogInformation($"Registration attempt for {googleRegisterInput.Email}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                //Validate if user Exist

                //map User data
                var user = mapper.Map<User>(googleRegisterInput);

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
                return Accepted(googleRegisterInput);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"something went wrong {nameof(Register)}");
                return StatusCode(500, $"Internl server Error");
            }
        }

        [HttpPost]
        [Route("google-sign-in")]
        public async Task<IActionResult> LoginWithGoogle([FromBody] GoogleLoginInput googleLoginInput)
        {
            logger.LogInformation($"Login attempt for {googleLoginInput.Email}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (!await userService.UserExist(googleLoginInput.Email))
                {
                    return Unauthorized("Please sign up, Your email could not be found");
                }

                var user = await userService.FindUserByEmailAsync(googleLoginInput.Email);
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

        /// <summary>
        /// To confirm Email, This router send email to user with five digit code
        /// </summary>
        /// <param name="requestEmailTokenInput"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("request-email-token")]
        public async Task<IActionResult> RequestOTP([FromBody] RequestEmailTokenInput requestEmailTokenInput)
        {

            var user = await userService.FindUserByEmailAsync(requestEmailTokenInput.Email);

            if(user == null)
            {
                return BadRequest("User does not exist.");
            }

            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
          
            var url = configuration.GetSection("AngularClient").GetSection("ResetEmailURL").Value;

            var emailDto = new EmailDto
            {
                Email = user.Email,
                Subject = "Aero Space - Confirm Email",
                Body = emailService.EmailBodyConfirm(user.Firstname, CreateUrlToken(user.Email, token, url))
            };

            await emailService.GoogleSMTP(emailDto);

            return Accepted();
        }

        [HttpPost]
        [Route("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailInput confrimEmailInput)
        {
            var user = await userManager.FindByEmailAsync(confrimEmailInput.Email);

            if (user == null)
                return NotFound();

            var results = await userManager.ConfirmEmailAsync(user, confrimEmailInput.Token);

            if (!results.Succeeded)
            {
                foreach (var error in results.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return Ok();
        }


        [HttpPost]
        [Route("request-password-token")]
        public async Task<IActionResult> RequestPasswordToken([FromBody] RequestPasswordInput requestPasswordDto)
        {
            //Request Token
            var user = await userService.FindUserByEmailAsync(requestPasswordDto.Email);

            if (user == null)
                return BadRequest("User does not exist.");

            var token = await userManager.GeneratePasswordResetTokenAsync(user);

            var url = configuration.GetSection("AngularClient").GetSection("ResetPasswordURL").Value;

            var emailDto = new EmailDto
            {
                Email = user.Email,
                Subject = "Aero Space - Reset Password",
                Body = emailService.EmailBodySendPasswordToken(user.Firstname, CreateUrlToken(user.Email, token, url))
            };
            
            //Send Email
            await emailService.GoogleSMTP(emailDto);

            return Accepted();
        }

        [HttpPost]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordInput resetPasswordDto)
        {
            // Request Token | Email | Token | Password

            var user = await userManager.FindByEmailAsync(resetPasswordDto.Email);
            if (user == null)
                return BadRequest();

            var results = await userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.Password);

            if (!results.Succeeded)
            {
                foreach (var error in results.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            
            return Ok();
        }
    
        private string CreateUrlToken(string email, string token, string url)
        {
            var param = new Dictionary<string, string>
            {
                {"token", token },
                {"email", email }
            };

            return QueryHelpers.AddQueryString(url,param);
        }
    }
}
