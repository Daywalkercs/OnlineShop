using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Data.Interfaces;
using OnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders _allOrders;
        private readonly ShopCart _shopCar;

        public OrderController (IAllOrders allOrders, ShopCart shopCar)
        {
            _allOrders = allOrders;
            _shopCar = shopCar;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shopCar.ListShopItems = _shopCar.GetShopItems();
            
            if (_shopCar.ListShopItems.Count == 0)
                ModelState.AddModelError("", "There must be at least 1 item in the cart");

            if (ModelState.IsValid)
            {
                _allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }
            else
            {
                // Вы можете добавить дополнительные сообщения об ошибках в ModelState, если нужно
                ModelState.AddModelError("", "Please correct the errors in the form.");

                // Возвращаем представление с моделью, чтобы показать ошибки пользователю
                return View(order);
            }

            //return View(order);
            //return RedirectToAction("Complete");
            //return View(order);
        }

        public IActionResult Complete() 
        {
            ViewBag.Message = "Order processed successfully";
            return View();
        }
    }
}
