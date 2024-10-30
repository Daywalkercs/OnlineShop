using OnlineShop.Data.Models;

namespace OnlineShop.Data.Interfaces
{
    public interface IAllOrders
    {
        public void CreateOrder(Order order);
    }
}
