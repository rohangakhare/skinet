using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helper
{
    public class ProductURLResolver : IValueResolver<Product, ProductToReturnDTO, string>
    {
        private readonly IConfiguration _configuration;
        public ProductURLResolver(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public string Resolve(Product source, ProductToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureURL))
            {
                return _configuration["APIURL"] + source.PictureURL;
            }

            return null;
        }
    }
}