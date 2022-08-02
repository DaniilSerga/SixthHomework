using AutoMapper;
using Shop.Models.DatabaseModels;
using Shop.Common.Models;

namespace Shop.Common.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<List<Product>, List<ProductModel>>().ReverseMap();

            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<List<User>, List<UserModel>>().ReverseMap();

            CreateMap<Sale, SaleModel>().ReverseMap();
        }
    }
}
