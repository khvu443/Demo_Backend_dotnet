using BusinessObject.Model;
using BusinessObject.Model.Authenticate;
using DataAccess.CategoryDAO;
using DataAccess.ProductDAO;
using DataAccess.UserDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly ProductDAO pDao = new ProductDAO();
        readonly CategoryDAO cDao = new CategoryDAO();
        readonly UserDAO uDao = new UserDAO();

        public void DeleteProduct(int id)
        {
            pDao.DeleteProduct(id);
        }
        public Product GetProductById(int id)
        {
            return pDao.FindById(id);
        }

        public List<Product> GetProducts()
        {
            return pDao.GetProducts();
        }

        public void SaveProduct(Product p)
        {
            pDao.AddProduct(p);
        }

        public void UpdateProduct(int id, Product p)
        {
            pDao.UpdateProduct(id, p);
        }


        //------------------------------------------------------------
        public List<Category> GetCategories()
        {
            return cDao.GetCategories();
        }

        //------------------------------------------------------------

        public User Authenticate(UserLogin login)
        {
            return uDao.GetUser(login);
        }

        public void CreateUser(User user)
        {
            uDao.CreateUser(user);
        }

        public void UpdateUser(Guid id, User user)
        {
            uDao.UpdateUser(id, user);
        }

        public User GetUserById(Guid id)
        {
            return uDao.GetUserByUid(id);
        }
    }
}
