using ApiDemoBatch2.Context;
using ApiDemoBatch2.Dtos;
using ApiDemoBatch2.Repositories;
using FluentValidation;

namespace ApiDemoBatch2.Validators
{
    public class CreateCarValidator : AbstractValidator<CreateCarModel>
    {
        public CreateCarValidator(ICarRepository carRepository) 
        {
            RuleFor(x => x.Model)
                .NotEmpty()
                .WithMessage("{PropertyName} must not be empty test here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here")
                .Must(Model => carRepository.GetCarByModel(Model).Result == null)
                    .WithMessage("{PropertyName} already exists.");

            RuleFor(x => x.Year)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Color)
                .NotEmpty()
                .NotNull();
        }
    }

    public class UpdateCarValidator : AbstractValidator<UpdateCarValidator>
    {

    }
}
