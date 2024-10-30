using OnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car>? GetAllCars {  get; set; }
        public required string CurrCategory { get; set; }
    }
}
