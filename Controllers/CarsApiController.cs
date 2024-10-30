using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data.Interfaces;
using OnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsApiController : ControllerBase
    {
        private readonly IAllCars _allCars;

        public CarsApiController(IAllCars allCars)
        {
            _allCars = allCars;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetCars()
        {
            return Ok(_allCars.Cars);
        }

        [HttpGet("{id}")]
        public ActionResult<Car> GetCar(int id)
        {
            var car = _allCars.GetCarById(id);
            if (car == null) return NotFound();
            return Ok(car);
        }

        [HttpPost]
        public ActionResult<Car> PostCar([FromBody] Car car)
        {
            if (car == null) return BadRequest();
            return CreatedAtAction(nameof(GetCar), new {id = car.Id}, car);
        }

        [HttpPut("{id}")]
        public IActionResult PutCar(int id, [FromBody] Car car)
        {
            if (id != car.Id || car == null) return BadRequest();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var car = _allCars.GetCarById(id);
            if (car == null) return NotFound();
            return NoContent();
        }
    }
}
