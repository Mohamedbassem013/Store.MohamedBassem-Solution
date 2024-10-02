using AutoMapper;
using Store.MohamedBassem.Domain.Dtos.Products;
using Store.MohamedBassem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.MohamedBassem.Domain.Mapping.Products
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.BrandName , options => options.MapFrom(s => s.Brand.Name))
                .ForMember(d => d.typeName, options => options.MapFrom(s => s.type.Name));


            CreateMap<ProductBrand, TypeBrandDto>();
            CreateMap<ProductType, TypeBrandDto>();
        }
    }
}
