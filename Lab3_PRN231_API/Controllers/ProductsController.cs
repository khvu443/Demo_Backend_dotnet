using BusinessObject.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace Lab3_PRN231_API.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository rep = new ProductRepository();


        //Get: api/Product
        [HttpGet, AllowAnonymous]
        public ActionResult<IEnumerable<Product>> GetProducts() => rep.GetProducts();

        //Get: api/Product/5
        [HttpGet("{id:int}"), AllowAnonymous]
        public Product GetProductById(int id)
        {
            return rep.GetProductById(id);
        }

        //Post: api/Product
        [HttpPost, Authorize(Roles = "Adminstrator")]
        public ActionResult PostProduct(Product p)
        {
            rep.SaveProduct(p);
            return Ok();
        }

        //Delete: api/Product/5
        [HttpDelete("{id:int}"), Authorize(Roles = "Adminstrator")]
        public ActionResult DeleteProduct(int id)
        {
            if (rep.GetProductById(id) != null)
            {

                rep.DeleteProduct(id);
                return Ok();
            }
            return NotFound();

        }

        //Put: api/Product/5
        [HttpPut("{id:int}"), Authorize(Roles = "Adminstrator")]
        public ActionResult UpdateProduct(int id, Product p)
        {

            if (rep.GetProductById(id) != null)
            {
                rep.UpdateProduct(id, p);
                return Ok();
            }
            return NotFound();

        }
    }
}
