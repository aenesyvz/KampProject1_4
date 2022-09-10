using Business.Abstract;
using Core.Ultilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public IResult Add(Order entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Order>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Order> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
