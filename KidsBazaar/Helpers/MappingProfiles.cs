using AutoMapper;
using Core.Entities;
using KidsBazaar.DTOs;

namespace KidsBazaar.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductsToReturnDTO>()
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Categories.Name));
            CreateMap<User, UserToReturnDTO>();
            CreateMap<Product, ProductToUpdateDTO>();
            CreateMap<ProductToUpdateDTO, Product>();
            CreateMap<ProductsForCreatingDTO, Product>();
        }
    }
}
