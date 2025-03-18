using ApiDemoBatch2.Context;
using ApiDemoBatch2.Entities;
using ApiDemoBatch2.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiDemoBatch2.Controllers
{
    public class CarBrandController : ControllerBase
    {
        private readonly ICarService carService;
        private readonly DatabaseContext databaseContext;
        public CarBrandController(DatabaseContext databaseContext, ICarService carService)
        {
            this.databaseContext = databaseContext;
            this.carService = carService;
        }

        [HttpGet()]
        public async Task<List<CarBrand>> GetAllCars()
        {
            var carBrand = await databaseContext.CarBrands.ToListAsync();

            return carBrand;
        }

        [HttpGet("{id}")]
        public async Task<CarBrand?> GetCarById([FromRoute] int id)
        {
            var carBrand = await databaseContext.CarBrands.FirstOrDefaultAsync(x => x.Id == id);

            return carBrand;
        }

        [HttpPost()]
        public async Task<CarBrand> CreateCar([FromBody] CarBrand carBrand)
        {
            databaseContext.CarBrands.Add(carBrand);
            await databaseContext.SaveChangesAsync();

            return carBrand;
        }

        [HttpPut("{id}")]
        public async Task<CarBrand?> UpdateCar([FromRoute] int id, [FromBody] CarBrand carBrand)
        {
            // Validation to check if carBrand exists
            var carRecord = await databaseContext.CarBrands.FirstOrDefaultAsync(x => x.Id == id);

            if (carRecord == null)
            {
                return null;
            }

            carRecord.Name = carBrand.Name;

            await databaseContext.SaveChangesAsync();

            return carRecord;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteCarBrand([FromRoute] int id)
        {
            // Validation to check if carBrand exists
            var carRecord = await databaseContext.CarBrands.FirstOrDefaultAsync(x => x.Id == id);

            if (carRecord == null)
            {
                return false;
            }

            databaseContext.CarBrands.Remove(carRecord);

            await databaseContext.SaveChangesAsync();

            return true;
        }
    }
}
