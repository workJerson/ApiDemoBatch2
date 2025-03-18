using ApiDemoBatch2.Context;
using ApiDemoBatch2.Dtos;
using ApiDemoBatch2.Entities;
using ApiDemoBatch2.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiDemoBatch2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService carService;

        public CarController(ICarService carService)
        {
            this.carService = carService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await carService.GetAllCars();

            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById([FromRoute] int id)
        {
            var car = await carService.GetCarById(id);
            if (car == null)
                return NotFound();

            return Ok(car);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateCar([FromBody] CreateCarModel car)
        {
            var createdCard = await carService.CreateCar(car);

            if (createdCard == null)
                return BadRequest();

            return Ok(createdCard);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar([FromRoute] int id, [FromBody] UpdateCarModel car)
        {
            var updateCarResult = await carService.UpdateCar(id, car);

            if (updateCarResult == null)
                return BadRequest();

            return Ok(updateCarResult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar([FromRoute] int id)
        {
            var deleteResult = await carService.DeleteCar(id);
            if (deleteResult == false)
                return BadRequest();

            return Ok(deleteResult);
        }
    }
}
