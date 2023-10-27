using BusinessObject.Context;
using BusinessObject.Model;
using BusinessObject.Model.Authenticate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ProductDAO
{
    public class ProductDAO
    {
        public List<Product> GetProducts()
        {
            var list = new List<Product>();
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    list = ctx.Products.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public Product FindById(int id)
        {
            var p = new Product();
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    p = ctx.Products.FirstOrDefault<Product>(Products => id == Products.ProductId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return p;
        }

        public void AddProduct(Product p)
        {
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    ctx.Products.Add(p);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateProduct(int id, Product p)
        {
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    if(FindById(id) != null)
                    {
                        ctx.Products.Attach(p);
                        ctx.Entry<Product>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        ctx.SaveChanges();
                    }

                    //p.ProductId = id;
                    //ctx.Products.Update(p);
                    //ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    var p = ctx.Products.FirstOrDefault<Product>(x => id == x.ProductId);
                    ctx.Products.Remove(p);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }

}
