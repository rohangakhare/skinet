using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specifications;
using API.DTOs;
using AutoMapper;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productsRepo,
                                  IGenericRepository<ProductBrand> productBrandRepo,
                                  IGenericRepository<ProductType> productTypeRepo,
                                  IMapper mapper)
        {
            _productRepo = productsRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var specification = new ProductsWithTypesAndBrandSpecification();
            var products = await _productRepo.GetListAsync(specification);

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDTO>>(products));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var specification = new ProductsWithTypesAndBrandSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(specification);

            return Ok(_mapper.Map<Product, ProductToReturnDTO>(product));
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetProductBrands()
        {
            var productBrands = await _productBrandRepo.GetAllAsync();

            return Ok(productBrands);
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetProductTypes()
        {
            var productTypes = await _productTypeRepo.GetAllAsync();

            return Ok(productTypes);
        }
    }
}