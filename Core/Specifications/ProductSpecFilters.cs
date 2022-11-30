using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public static class ProductSpecFilters
    {
        public static Expression<Func<Product, bool>> GetFilterExpression(ProductSpecParams specParams)
        {
            return x =>
                    (string.IsNullOrEmpty(specParams.Search) || x.Name.ToLower().Contains(specParams.Search)) &&
                    (!specParams.BrandId.HasValue || x.ProductBrandId == specParams.BrandId) &&
                    (!specParams.TypeId.HasValue || x.ProductTypeId == specParams.TypeId);
        }
    }
}