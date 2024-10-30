using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Models
{
    public class ShopCart
    {
        public string ShopCartId { get; set; } = "";
        public List<ShopCartItem> ListShopItems { get; set; } = new List<ShopCartItem>();

        private readonly ApplicationDbContext _applicationDbContext;

        public ShopCart(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public static ShopCart GetCar(IServiceProvider services)
        {
            var httpContextAccessor = services.GetRequiredService<IHttpContextAccessor>();
            var session = httpContextAccessor?.HttpContext?.Session;

            if (session == null)
                throw new InvalidOperationException("Session is not available.");
            
            var context = services.GetService<ApplicationDbContext>();

            if (context == null)
                throw new InvalidOperationException("ApplicationDbContext is not available.");
            
            string shopCarId = session.GetString("CarId") ?? Guid.NewGuid().ToString();
            session.SetString("CarId", shopCarId);

            return new ShopCart(context) { ShopCartId = shopCarId };
        }

        public void AddToCart(Car car)
        {
            _applicationDbContext.ShopCartItem.Add(new ShopCartItem
            {
                ShopCarID = this.ShopCartId,
                Car = car,
                Price = car.Price
            });
            _applicationDbContext?.SaveChanges();
        }

        public List<ShopCartItem> GetShopItems()
        {
            return _applicationDbContext.ShopCartItem.Where(c => c.ShopCarID == this.ShopCartId).Include(s => s.Car).ToList();
        }

        public void RemoveFromCart(Car car)
        {
            var carItem = _applicationDbContext.ShopCartItem.FirstOrDefault(c => c.ShopCarID == this.ShopCartId && c.Car.Id == car.Id);
            if (carItem != null)
            {
                _applicationDbContext.ShopCartItem.Remove(carItem);
                _applicationDbContext.SaveChanges();
            }
        }

        public void ClearCart()
        {
            var cartItems = _applicationDbContext.ShopCartItem.Where(c => c.ShopCarID == this.ShopCartId);
            _applicationDbContext.ShopCartItem.RemoveRange(cartItems);
            _applicationDbContext.SaveChanges();
        }
    }
}
