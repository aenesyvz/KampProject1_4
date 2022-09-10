using Core.Ultilities.Result;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProductService : IServiceBase<Product>
    {
        IDataResult<Product> GetProdcutDetail(int Id);
        IDataResult<List<Product>> GetByCategoryId(int Id);
        IResult AddTransactionalTest(Product product);
    }
}
