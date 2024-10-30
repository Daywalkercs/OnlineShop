using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data.Interfaces;
using OnlineShop.Data.Models;
using OnlineShop.ViewModels;

namespace OnlineShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCarsCategory;

        public CarsController(IAllCars allCars, ICarsCategory carsCategory)
        {
            _allCars = allCars;
            _allCarsCategory = carsCategory;
        }

        [Route("Cars/CarsList")]
        [Route("Cars/CarsList/{category}")]
        public ViewResult CarsList(string category)
        {
            IEnumerable<Car> cars;
            string currCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.OrderBy(i => i.Id);
                currCategory = "All Cars";
            }
            else
            {
                if (string.Equals("Electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.CategoryName == "Electro Cars").OrderBy(i => i.Id);
                    currCategory = _allCarsCategory.GetCategories.FirstOrDefault(i => i.CategoryName == "Electro Cars")?.CategoryName ?? "Electro Cars";
                }
                else if (string.Equals("Gas", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.CategoryName == "Gas Cars").OrderBy(i => i.Id);
                    currCategory = _allCarsCategory.GetCategories.FirstOrDefault(i => i.CategoryName == "Gas Cars")?.CategoryName ?? "Gas Cars";
                }
                else
                {
                    cars = Enumerable.Empty<Car>(); // Обработка неизвестной категории
                    currCategory = "Unknown Category";
                }
            }

            var carObj = new CarsListViewModel
            {
                GetAllCars = cars,
                CurrCategory = currCategory
            };

            ViewBag.Title = "Cars page";

            return View(carObj);
        }

        public ViewResult Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                ViewBag.Message = "Please enter a search query.";
                return View(new CarsListViewModel { GetAllCars = new List<Car>(), CurrCategory = "Search" });
            }


            var cars = _allCars.Cars.Where(
              c => c.CarModel.Contains(query, StringComparison.OrdinalIgnoreCase) ||
              c.LongDescription.Contains(query, StringComparison.OrdinalIgnoreCase) ||
              c.ShortDescription.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();

            if (cars.Count == 0)
            {
                ViewBag.Message = $"No cars found matching '{query}'.";
            }

            var carSearchViewModel = new CarsListViewModel
            {
                GetAllCars = cars,
                CurrCategory = cars.Count == 0 ? "No results" : $"Search results for: {query}"
            };

          

            return View(carSearchViewModel);
        }
    }
}



