using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Interfaces;
using OnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public IEnumerable<Car> Cars => _applicationDbContext.Car.Include(c => c.Category);

        public IEnumerable<Car> GetFavCars => _applicationDbContext.Car.Where(p => p.IsFavourite).Include(c => c.Category);

        public CarRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Car GetCarById(int id) => _applicationDbContext.Car.First(p => p.Id == id);

        public void AddCar(Car car)
        {
            _applicationDbContext.Car.Add(car);
            _applicationDbContext.SaveChanges();
        }

        public void UpdateCar(Car car)
        {
            var existingCar = _applicationDbContext.Car.FirstOrDefault(p => p.Id == car.Id);
            if (existingCar != null)
            {
                existingCar.CarModel = car.CarModel;
                existingCar.ShortDescription = car.ShortDescription;
                existingCar.LongDescription = car.LongDescription;
                existingCar.Price = car.Price;
                existingCar.IsFavourite = car.IsFavourite;
                existingCar.Available = car.Available;
                existingCar.CategoryID = car.CategoryID;

                _applicationDbContext.SaveChanges();
            }
        }

        public void DeleteCar(int carId)
        {
            var car = _applicationDbContext.Car.FirstOrDefault(p => p.Id == carId);
            if (car != null)
            {
                _applicationDbContext.Car.Remove(car);
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
