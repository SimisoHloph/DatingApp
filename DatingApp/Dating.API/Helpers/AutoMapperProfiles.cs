using AutoMapper;
using Dating.API.Models;
using Dating.API.Dtos;
using System.Linq;
namespace Dating.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
          CreateMap<User,UserForLIstDto>().ForMember(dest => dest.PhotoUrl, opt => opt.
          MapFrom(src =>src.Photos.FirstOrDefault(p=>p.IsMain).Url)).
          ForMember(dest => dest.Age, opt => opt.MapFrom(src=>src.DateOfBirth.CalculateAge()));
           
          CreateMap<User,UserForDetailedDto>().ForMember(dest => dest.PhotoUrl, opt => opt.
          MapFrom(src =>src.Photos.FirstOrDefault(p=>p.IsMain).Url))
         .ForMember(dest => dest.Age, opt => opt.MapFrom(src=>src.DateOfBirth.CalculateAge()));
           
          
          CreateMap<Photo,PhotosForDetailsDto>();

        }
    }
}