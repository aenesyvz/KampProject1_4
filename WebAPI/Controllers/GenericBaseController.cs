using Business.Abstract;
using Core.Entities;
using Core.Ultilities.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericBaseController<TEntity,TService> : ControllerBase
        where TEntity:class,IEntity,new()
        where TService:IServiceBase<TEntity>
    {
        protected TService _service;
        
        public GenericBaseController(TService service)
        {
            this._service = service;
        }
        
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            Thread.Sleep(1000);
            return GetResponseByResultSuccess(_service.GetAll());
        }
        
        [HttpGet("GetById")]
        public IActionResult GetById(int Id)
        {
            return GetResponseByResultSuccess(_service.GetById(Id));
        }

        [HttpPost("Add")]
        public IActionResult Add(TEntity entity)
        {
            return GetResponseByResultSuccess(_service.Add(entity));
        }
        
        [HttpPost("Delete")]
        public IActionResult Delete(TEntity entity)
        {
            return GetResponseByResultSuccess(_service.Delete(entity));
        }
        
        [HttpPost("Update")]
        public IActionResult Update(TEntity entity)
        {
            return GetResponseByResultSuccess(_service.Update(entity));
        }

        protected IActionResult GetResponseByResultSuccess(IResult result)
        {
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
