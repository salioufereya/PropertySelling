using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using WebApi.Errors;
using WebApi.Extensions;


namespace WebApi.controllers
{
    public class AccountController : BaseController
    {

        private readonly IUnitOfWork uow;


        public AccountController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        [HttpPost("login")]

        public async Task<IActionResult> Login(LoginReqDto loginReqDto)
        {
            ApiError apiError = new ApiError();

            if (loginReqDto.Username.IsEmpty() || loginReqDto.Password.IsEmpty())
            {
                apiError.ErrorCode = BadRequest().StatusCode;
                apiError.ErrorMessage = "User or password cant not be blank";
                return Unauthorized(apiError);
            }
            var user = await uow.UserRepository.Authenticate(loginReqDto.Username, loginReqDto.Password);

            if (user == null)
            {
                apiError.ErrorCode = Unauthorized().StatusCode;
                apiError.ErrorMessage = "Invalid username or password";
                apiError.ErrorDetails = "this is not a valid";
                return Unauthorized(apiError);
            }
            var loginRes = new LoginResDto();
            loginRes.Username = loginReqDto.Username;
            loginRes.token = CreateJWT(user);
            return Ok(loginRes);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(LoginReqDto loginReq)
        {
            ApiError apiError = new ApiError();
            if (await uow.UserRepository.UserAlreadyExists(loginReq.Username))
            {

                apiError.ErrorCode = BadRequest().StatusCode;
                apiError.ErrorMessage = "  Username already exists";
                return BadRequest(apiError);
            }
            uow.UserRepository.Register(loginReq.Username, loginReq.Password);
            await uow.SaveAsync();
            return StatusCode(201);

        }

        private string secretKey = "shhh.. this is my top secret secret secret";
        [HttpPost]
        public string CreateJWT(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var claims = new Claim[]{
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

            var signingCredentials = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}