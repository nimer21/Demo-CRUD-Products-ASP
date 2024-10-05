using AutoMapper;
using Demo.DAL.Models;
using Demo.PL.ViewModels;

namespace Demo.PL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<ProductFormViewModel, Product>();        
            CreateMap<Product, ProductVM>();        
        }
    }
}
