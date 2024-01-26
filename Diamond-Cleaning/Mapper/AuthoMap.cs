using AutoMapper;
using Diamond_Cleaning.Models;
using OnlineShop.Db.Models;

namespace Diamond_Cleaning.Mapper
{
    public class AuthoMap : Profile
    {
        public AuthoMap()
        {
            CreateMap<Service, ServiceDto>().ReverseMap();
        }
    }
}
