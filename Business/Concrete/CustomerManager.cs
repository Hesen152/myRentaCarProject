using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
                
        }


        public IResult Add(Customer customer)
        { 
            

            _customerDal.Add(customer);

            return new SuccesResult(Messages.Added);

           
        }

        public IResult Delete(Customer customer)
        {
            var deletedcustomer = _customerDal.Get(c => c.Id == customer.Id);
            if (deletedcustomer is null)
            {
                return new ErrorResult(Messages.NotFound);

            }

            _customerDal.Delete(deletedcustomer);

            return new SuccesResult(Messages.Deleted);


        }

        public IDataResult<List<Customer>> GetAll()
        {
            var result = _customerDal.GetAll();

            if (result is null)
            {
                return new ErrorDataResult<List<Customer>>(result,Messages.NotFound);
                
                 

            }

            return new SuccessDataResult<List<Customer>>(result, Messages.Listed);

        }

        public IDataResult<Customer> GetById(int customerId)
        {
            var getcustomerbyId = _customerDal.Get(c => c.Id == customerId);
            if (getcustomerbyId is null)
            {
                return new ErrorDataResult<Customer>(getcustomerbyId,Messages.NotFound);

            }




            return new SuccessDataResult<Customer>(getcustomerbyId, Messages.Listed);
        }

        public IResult Update(Customer customer)
        {
            var getcustomer = _customerDal.Get(c => c.Id == customer.Id);

            if (getcustomer is null)
            {

                return new ErrorResult(Messages.NotFound);
                 

            }
            _customerDal.Update(customer);


            return new SuccesResult(Messages.Updated); 


        }
    }
}
