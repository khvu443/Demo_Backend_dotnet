using BusinessObject.Model;
using BusinessObject.Model.Authenticate;
using Lab3_PRN231_API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Repositories;
using System;

namespace Lab3_PRN231_API.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IProductRepository rep = new ProductRepository();
        private readonly StoreService service = new StoreService();

        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("{id}"), Authorize]
        public ActionResult GetUserById(string id)
        {
            return Ok(rep.GetUserById(new Guid(service.DecryptString(Uri.UnescapeDataString(id), _configuration))));
        }

        [HttpPut("{id}"), Authorize]
        public void UpdateUser(string id, User user)
        {
            rep.UpdateUser(new Guid(service.DecryptString(Uri.UnescapeDataString(id), _configuration)), user);
        }
    }
}
