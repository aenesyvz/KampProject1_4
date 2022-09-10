using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : GenericBaseController<Product,IProductService>
    {
        IProductService _productService;
        public ProductsController(IProductService productService):base(productService)
        {
            this._productService = productService;
        }
        [HttpGet("GetByCategory")]
        public IActionResult GetByCategory(int categoryId)
        {
            return GetResponseByResultSuccess(_service.GetByCategoryId(categoryId));
        }

    }
}
