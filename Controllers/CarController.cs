using ApiDemoBatch2.Context;
using ApiDemoBatch2.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiDemoBatch2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly DatabaseContext databaseContext;
        public CarController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        [HttpGet()]
        public async Task<List<Car>> GetAllCars()
        {
            var cars = await databaseContext.Cars.ToListAsync();

            return cars;
        }

        [HttpGet("{id}")]
        public async Task<Car?> GetCarById([FromRoute] int id)
        {
            var car = await databaseContext.Cars.FirstOrDefaultAsync(x => x.Id == id);

            return car;
        }

        [HttpPost()]
        public async Task<Car> CreateCar([FromBody] Car car)
        {
            databaseContext.Cars.Add(car);
            await databaseContext.SaveChangesAsync();

            return car;
        }

        [HttpPut("{id}")]
        public async Task<Car?> UpdateCar([FromRoute] int id, [FromBody] Car car)
        {
            // Validation to check if car exists
            var carRecord = await databaseContext.Cars.FirstOrDefaultAsync(x => x.Id == id);

            if (carRecord == null)
            {
                return null;
            }

            carRecord.Model = car.Model;
            carRecord.Year = car.Year;
            carRecord.Color = car.Color;
            carRecord.CarBrandId = car.CarBrandId;

            await databaseContext.SaveChangesAsync();

            return carRecord;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteCar([FromRoute] int id)
        {
            // Validation to check if car exists
            var carRecord = await databaseContext.Cars.FirstOrDefaultAsync(x => x.Id == id);

            if (carRecord == null)
            {
                return false;
            }

            databaseContext.Cars.Remove(carRecord);

            await databaseContext.SaveChangesAsync();

            return true;
        }
    }
}
