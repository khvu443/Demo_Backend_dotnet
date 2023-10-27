using BusinessObject.Model;
using BusinessObject.Model.Authenticate;

namespace Repositories
{
    public interface IProductRepository
    {
        void SaveProduct(Product p);
        Product GetProductById(int id);
        void UpdateProduct(int id, Product p);
        void DeleteProduct(int id);
        List<Product> GetProducts();

        //----------------------------------------------
        List<Category> GetCategories();

        //----------------------------------------------
        User Authenticate(UserLogin login);
        void CreateUser(User user);
        void UpdateUser(Guid id, User user);
        User GetUserById(Guid id);



    }
}