using ApiDemoBatch2.Context;
using ApiDemoBatch2.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiDemoBatch2.Repositories
{
    public interface ICarRepository
    {
        Task<List<Car>> GetAllCars();
        Task<Car?> GetCarById(int id);
        Task<Car> CreateCar(Car car);
        Task<Car?> UpdateCar(int id, Car car);
        Task<bool> DeleteCar(int id);
        Task<Car?> GetCarByModel(string model);
    }
    public class CarRepository : ICarRepository
    {
        private readonly DatabaseContext databaseContext;

        public CarRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<Car> CreateCar(Car car)
        {
            databaseContext.Cars.Add(car);
            await databaseContext.SaveChangesAsync();

            return car;
        }

        public async Task<bool> DeleteCar(int id)
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

        public async Task<List<Car>> GetAllCars()
        {
            var cars = await databaseContext.Cars.ToListAsync();

            return cars;
        }

        public async Task<Car?> GetCarById(int id)
        {
            var car = await databaseContext.Cars.FirstOrDefaultAsync(x => x.Id == id);

            return car;
        }

        public async Task<Car?> GetCarByModel(string model)
        {
            Car? car = await databaseContext.Cars.FirstOrDefaultAsync(x => x.Model == model);

            return car;
        }

        public async Task<Car?> UpdateCar(int id, Car car)
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
    }
}
