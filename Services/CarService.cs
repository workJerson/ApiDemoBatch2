using ApiDemoBatch2.Context;
using ApiDemoBatch2.Dtos;
using ApiDemoBatch2.Entities;
using ApiDemoBatch2.Repositories;
using ApiDemoBatch2.Validators;
using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiDemoBatch2.Service
{
    public interface ICarService
    {
        Task<List<GetCarModel>> GetAllCars();
        Task<GetCarModel?> GetCarById(int id);
        Task<GetCarModel> CreateCar(CreateCarModel car);
        Task<GetCarModel?> UpdateCar(int id, UpdateCarModel car);
        Task<bool> DeleteCar(int id);
    }
    public class CarService : ICarService
    {
        private readonly ICarRepository carRepository;
        private readonly IMapper mapper;
        public CarService(ICarRepository carRepository, IMapper mapper)
        {
            this.carRepository = carRepository;
            this.mapper = mapper;
        }

        public async Task<GetCarModel> CreateCar(CreateCarModel car)
        {
            CreateCarValidator validator = new CreateCarValidator(carRepository);
            ValidationResult results = validator.Validate(car);

            if (results.Errors.Count > 0)
            {
                throw new Exception(string.Join(",", results.Errors.Select(x => x.ErrorMessage).ToList()));
            }

            var createdCard = await carRepository.CreateCar(mapper.Map<Car>(car));

            return mapper.Map<GetCarModel>(createdCard);
        }

        public async Task<bool> DeleteCar(int id)
        {
            var deleteResult = await carRepository.DeleteCar(id);

            return deleteResult;
        }

        public async Task<List<GetCarModel>> GetAllCars()
        {
            var cars = await carRepository.GetAllCars();

            return mapper.Map<List<GetCarModel>>(cars);
        }

        public async Task<GetCarModel?> GetCarById(int id)
        {
            var car = await carRepository.GetCarById(id);

            return mapper.Map<GetCarModel>(car);
        }

        public async Task<GetCarModel?> UpdateCar(int id, UpdateCarModel car)
        {
            var updateCarResult = await carRepository.UpdateCar(id, mapper.Map<Car>(car));

            return mapper.Map<GetCarModel>(updateCarResult);
        }
    }
}
