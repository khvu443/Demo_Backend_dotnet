using BusinessObject.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace Lab3_PRN231_API.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IProductRepository rep = new ProductRepository();
        //Get: api/Category
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories() => rep.GetCategories();
    }
}
