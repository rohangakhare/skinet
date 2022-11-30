using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSepcification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSepcification(ProductSpecParams specParams)
         : base(ProductSpecFilters.GetFilterExpression(specParams))
        {

        }
    }
}