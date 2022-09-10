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
    public class CategoriesController : GenericBaseController<Category,ICategoryService>
    {
        ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService):base(categoryService)
        {
            this._categoryService = categoryService;
        }
    }
}
