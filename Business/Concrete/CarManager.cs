using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal cardal)
        {
            _carDal = cardal;

        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            //if (car.DailyPrice<=0)
            //{


            //    return new ErrorResult(Messages.InvalidDailyPrice);


            IResult result = BusinessRules.Run();
            //}


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

        public IDataResult<List<Car>> GetAll()
        {
            var getCarAll = _carDal.GetAll();

            if (getCarAll is  null )
            {

                return new ErrorDataResult<List<Car>>(Messages.NotFound);

            }

            return new SuccessDataResult<List<Car>>(getCarAll, Messages.Listed);            

           
        }

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

        public IDataResult<List<CarAllDetailsDto>> GetCarAllDetails()
        {
            var carsToGetDetails = _carDal.GetCarAllDetails();
            if (carsToGetDetails is null)
            {
                return new ErrorDataResult<List<CarAllDetailsDto>>(Messages.NotFound);

            }

            return new SuccessDataResult<List<CarAllDetailsDto>>(carsToGetDetails, Messages.Listed);
        }

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

      
    }
}
