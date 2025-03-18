using ApiDemoBatch2.Dtos;
using ApiDemoBatch2.Entities;
using AutoMapper;

namespace ApiDemoBatch2.AutoMapperProfiles
{
    public class CarAutoMapperProfiles : Profile
    {
        public CarAutoMapperProfiles() 
        {
            CreateMap<CreateCarModel, Car>();
                //.ForMember(x => x.Model, s => s.MapFrom(a => a.CarModel));
            CreateMap<UpdateCarModel, Car>();
            CreateMap<Car, GetCarModel>()
                .ForMember(x => x.CarModel, s => s.MapFrom(a => a.Model))
                .ForMember(x => x.CarYear, s => s.MapFrom(a => a.Year))
                .ForMember(x => x.CarColor, s => s.MapFrom(a => a.Color));
        }
    }
}
