using Core.Ultilities.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IServiceBase<T>
    {
        IDataResult<List<T>> GetAll();
        IDataResult<T> GetById(int Id);
        IResult Add(T entity);
        IResult Delete(T entity);
        IResult Update(T entity);
    }
}
