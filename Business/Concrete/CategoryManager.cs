using Business.Abstract;
using Core.Ultilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<Category> GetById(int Id)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == Id));
        }

        public IResult Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
