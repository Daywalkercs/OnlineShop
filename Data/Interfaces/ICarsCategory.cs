using OnlineShop.Data.Models;

namespace OnlineShop.Data.Interfaces
{
    public interface ICarsCategory
    {
        IEnumerable<Category> GetCategories {  get; }
    }
}
