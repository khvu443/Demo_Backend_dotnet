using BusinessObject.Context;
using BusinessObject.Model;

namespace DataAccess.CategoryDAO
{
    public class CategoryDAO
    {
        public List<Category> GetCategories()
        {
            var list = new List<Category>();
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    list = ctx.Categories.ToList();
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
    }
}