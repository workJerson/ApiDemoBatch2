using Microsoft.AspNetCore.Mvc;

namespace ApiDemoBatch2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private static List<Car> cars = new List<Car>()
        {
            new Car()
            {
                Id = 1,
                Brand = "Honda",
                Model = "City"
            },
            new Car()
            {
                Id = 2,
                Brand = "Toyota",
                Model = "Rush"
            },
            new Car()
            {
                Id = 3,
                Brand = "Honda",
                Model = "Civic"
            },
        };

        [HttpGet()]
        public async Task<List<Car>> GetAllCars()
        {
            return cars;
        }

        [HttpGet("{id}")]
        public async Task<Car?> GetCarById([FromRoute] int id)
        {
            //Car fetchedCar = cars.Where(x => x.Id == 5).First();

            //List<Car> linqCar = (from c in cars
            //               where c.Id == 5
            //               select c).ToList();

            // SELECT * FROM Cars c WHERE c.Id = 5;

            return cars.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost()]
        public async Task<Car> CreateCar([FromBody] Car car)
        {
            cars.Add(car);

            return car;
        }

        [HttpPut("{id}")]
        public async Task<Car?> UpdateCar([FromRoute] int id, [FromBody] Car car)
        {
            // Validation to check if car exists
            Car? carRecord = cars.FirstOrDefault(x => x.Id == id);

            if (carRecord == null)
            {
                return null;
            }

            carRecord.Model = car.Model;
            carRecord.Brand = car.Brand;

            return carRecord;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteCar([FromRoute] int id)
        {
            // Validation to check if car exists
            Car? carRecord = cars.FirstOrDefault(x => x.Id == id);

            if(carRecord == null)
            {
                return false;
            }

            cars.Remove(carRecord);

            return true;
        }
    }
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}
