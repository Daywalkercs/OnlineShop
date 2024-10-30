using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data.Interfaces;
using OnlineShop.Data.Repository;
using OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {

        private readonly IAllCars _allCars;
        public HomeController(IAllCars carRep)
        {
            _allCars = carRep;
        }

        public ViewResult Index()
        {
            var homeCars = new HomeViewModel()
            {
                FavCars = _allCars.GetFavCars
            };
            return View(homeCars);
        }
    }
}
