using Business.Abstract;
using Business.BusinessAspects.Aspects;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal cardal)
        {
            _carDal = cardal;

        }


        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]

        public IResult Add(Car car)
        {

            //ValidationTool.Validate(new CarValidator(), car);


            IResult result = BusinessRules.Run();

            try
            {

            }
            catch (Exception)
            {

                throw;
            }

            _carDal.Add(car);

            return new SuccesResult(Messages.Added);
           




        }

        public IResult Delete(Car car)
        {
            var deletedCar = _carDal.Get(c => c.Id == car.Id);

            if (deletedCar==null)
            {
                return new ErrorResult(Messages.NotFound);

            }

             _carDal.Delete(deletedCar);

            return new SuccesResult(Messages.Deleted);
              
             








        }

        [CacheAspect] //key,value
        [PerformanceAspect(2)]
        public IDataResult<List<Car>> GetAll()
        {
            var getCarAll = _carDal.GetAll();

            if (getCarAll is  null )
            {

                return new ErrorDataResult<List<Car>>(Messages.NotFound);

            }

            return new SuccessDataResult<List<Car>>(getCarAll, Messages.Listed);            

           
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Car> GetById(int carId)
        {
            var getById = _carDal.Get(c => c.Id == carId);
            if (getById is null )
            {
                return new ErrorDataResult<Car>(Messages.NotFound);

            }


            return new SuccessDataResult<Car>(getById, Messages.Listed);




        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {

            var getcarBranId = _carDal.GetAll(c => c.BrandId == brandId);

            if (getcarBranId is  null)
            {
                return new ErrorDataResult<List<Car>>(Messages.NotFound);

            }

            return new SuccessDataResult<List<Car>>(getcarBranId, Messages.Listed);



        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            var getcarByColorId = _carDal.GetAll(c => c.ColorId == colorId);

            if (getcarByColorId is null)
            {
                return new ErrorDataResult<List<Car>>(Messages.NotFound);

                

            }

            return new SuccessDataResult<List<Car>>(getcarByColorId, Messages.NotFound);


            
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            var carsToGetDetails = _carDal.GetCarDetails();
            if (carsToGetDetails is null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.NotFound);

            }

            return new SuccessDataResult<List<CarDetailDto>>(carsToGetDetails, Messages.Listed);
        }
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {

            // this entitty have Id  already database? 
            var getCarUpdate = _carDal.Get(c => c.Id == car.Id);
            //false
            if (getCarUpdate is null )
            {
                return new ErrorResult(Messages.NotFound);

            }

            //true
            
            _carDal.Update(car);

            return new SuccesResult(Messages.Updated);






        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            //#region testTransaction

            //using (TransactionScope scope=new TransactionScope())
            //{
            //    try
            //    {
            //        Add(car);

            //        if (car.DailyPrice < 10)
            //        {
            //            throw new Exception("");

            //        }
            //        Add(car);
            //        scope.Complete();

            //    }
            //    catch (Exception)
            //    {
            //        scope.Dispose();
            //        throw;
            //    }

            //}
            
            //#endregion



            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetAllBrandId(int brandId)
        {
            var getAllBranId = _carDal.GetAll(c=>c.BrandId==brandId);
            if (getAllBranId is null)
            {
                return new ErrorDataResult<List<Car>>(Messages.NotFound);

            }

            return new SuccessDataResult<List<Car>>(getAllBranId, Messages.Listed);
        }

        public IDataResult<CarForDetailDto> GetForCarDetails(int id)
        {
            return new SuccessDataResult<CarForDetailDto>(_carDal.GetForDetails(c => c.Id == id));
        }
    }
}
