using BusinessObject.Model.Authenticate;
using Lab3_PRN231_API.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using System.Security.Claims;

namespace Lab3_PRN231_API.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ProductRepository productRepository = new ProductRepository();
        private readonly StoreService service = new StoreService();

        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register([FromBody] User user)
        {
            productRepository.CreateUser(user);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin login)
        {
            var user = productRepository.Authenticate(login);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role)
                };

                string token = service.CreateToken(claims, _configuration);

                SetCookie("access_token", token, true);
                SetCookie("uid", service.EncryptString(user.UserId.ToString(), _configuration), false);
                return Ok(token);
            }
            return BadRequest("User not found");
        }

        [HttpPost, Authorize]
        public IActionResult Logout()
        {
            foreach (var cookie in Request.Cookies.Keys) {
                System.Diagnostics.Debug.Write("Cookie: " + cookie);
                Response.Cookies.Delete(cookie, new CookieOptions()
                {
                    IsEssential = true,
                    SameSite = SameSiteMode.None,
                    Secure = true
                });
            }
            return Ok();

        }

        private void SetCookie(string name, string value, bool httpOnly)
        {
            Response.Cookies.Append(name, value, new CookieOptions()
            {
                IsEssential = true,
                Expires = DateTime.Now.AddHours(3),
                Secure = true,
                HttpOnly = httpOnly,
                SameSite = SameSiteMode.None
            });
        }
    }

}
