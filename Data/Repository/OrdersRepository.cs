using OnlineShop.Data.Interfaces;
using OnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ShopCart _shopCar;

        public OrdersRepository(ApplicationDbContext applicationDbContext, ShopCart shopCar)
        {
            _applicationDbContext = applicationDbContext;
            _shopCar = shopCar;
        }



        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            _applicationDbContext.Order.Add(order);
            _applicationDbContext.SaveChanges();
            List<ShopCartItem> items = _shopCar.ListShopItems;

            foreach (ShopCartItem item in items)
            {
                OrderDetail orderDetail = new OrderDetail()
                {

                    CarId = item.Car.Id,
                    OrderId = order.Id,
                    Price = item.Car.Price

                };
                _applicationDbContext.OrderDetail.Add(orderDetail);
            }
            _applicationDbContext.SaveChanges();
        }
    }
}
