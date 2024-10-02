using AutoMapper;
using Store.MohamedBassem.Domain;
using Store.MohamedBassem.Domain.Dtos.Products;
using Store.MohamedBassem.Domain.Entities;
using Store.MohamedBassem.Domain.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.MohamedBassem.Service.Services.Products
{
    public class ProductService : IProductServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
           return _mapper.Map<IEnumerable<ProductDto>>(await _unitOfWork.Repositroy<Product, int>().GetAllAsync());
        }
        public async Task<IEnumerable<TypeBrandDto>> GetAllTypesAsync()
            => _mapper.Map<IEnumerable<TypeBrandDto>>(await _unitOfWork.Repositroy<ProductType, int>().GetAllAsync());
        public async Task<ProductDto> GetProudctById(int id)
        {
            var product = await _unitOfWork.Repositroy<Product,int>().GetAsync(id);
            var mappedproduct = _mapper.Map<ProductDto>(product);
            return mappedproduct;
        }
        public async Task<IEnumerable<TypeBrandDto>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.Repositroy<ProductBrand, int>().GetAllAsync();
            var mappedBrands = _mapper.Map<IEnumerable<TypeBrandDto>>(brands);
            return mappedBrands;
        }
    }
}
