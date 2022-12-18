using System.Collections.Generic;
using IronWaterStudioNet6.Models;

namespace IronWaterStudioNet6.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> products { get; set; }
        public PagingInfo pagingInfo { get; set; }
    }
}
