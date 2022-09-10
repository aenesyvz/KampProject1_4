using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CSS;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Ultilities.Business;
using Core.Ultilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product entity)
        {
            IResult result = BusinessRules.Run(
                                                CheckIfProductCountOfCategoryCorrect(entity.CategoryId),
                                                CheckIfProductNameExists(entity.ProductName),
                                                CheckIfCategoryLimitExceded()
                                              );
            if (result != null)
            {
                return result;
            }
            _productDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Product entity)
        {
            _productDal.Delete(entity);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
        }

        public IDataResult<List<Product>> GetByCategoryId(int Id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == Id));
        }
        [CacheAspect]
        //[PerformanceAspect(5)]
        public IDataResult<Product> GetById(int Id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == Id));
        }

        public IDataResult<Product> GetProdcutDetail(int Id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == Id));
        }
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product entity)
        {
            _productDal.Update(entity);
            return new SuccessResult();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result <= 10)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();

        }
        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll().Data.Count;
            if (result > 15)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        //[TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            using (TransactionScope scope = new TransactionScope())
            {

                Add(product);
                if (product.UnitPrice < 10)
                {
                    throw new Exception("");
                }
                Add(product);
                scope.Complete();

            }
            return null;
        }
    }
}
