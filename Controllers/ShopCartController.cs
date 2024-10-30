using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data.Interfaces;
using OnlineShop.Data.Models;
using OnlineShop.Data.Repository;
using OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars allCars, ShopCart shopCar)
        {
            _allCars = allCars;
            _shopCart = shopCar;
        }

        public ViewResult IndexShopCart()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems = items;
            
            var obj = new ShopCartViewModel { ShopCart = _shopCart };
            return View("IndexShopCart", obj);
        }


        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            var item = _allCars.Cars.FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                return NotFound("Car not found.");
            }

            try
            {
                _shopCart.AddToCart(item);

                var cartItems = _shopCart.GetShopItems();
                _shopCart.ListShopItems = cartItems;

                return PartialView("CartPartial", cartItems);
            }
            catch (Exception ex)
            {
                // Логирование ошибки (например, в консоль)
                Console.WriteLine(ex.Message);
                // Возврат статуса ошибки
                return StatusCode(500, "Internal server error occurred.");
            }
        }


        [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            var item = _allCars.Cars.FirstOrDefault(i => i.Id == id);
            if (item != null) _shopCart.RemoveFromCart(item);

            var cartItems = _shopCart.GetShopItems();
            _shopCart.ListShopItems = cartItems;



            return PartialView("CartPartial", cartItems);
        }


    }
}
