using AutoMapper;
using Shop.Models.DatabaseModels;
using Shop.Common.Models;

namespace Shop.Common.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductModel, Product>();
            CreateMap<UserModel, User>();
            CreateMap<SaleModel, Sale>();
        }
    }
}
