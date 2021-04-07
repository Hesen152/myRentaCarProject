using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

           public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
                
        }



        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate==null)
            {
                return new ErrorResult(Messages.NullDate);

            }
            _rentalDal.Add(rental);

            return new SuccesResult(Messages.Added);

            

            


        }

        public IResult Delete(Rental rental)
        {
            var deletedRental = _rentalDal.Get(c => c.Id == rental.Id);

            if (deletedRental==null)
            {

                return new ErrorResult(Messages.NotFound);
            }

            _rentalDal.Delete(deletedRental);

            return new SuccesResult(Messages.Deleted);

           
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var rentalALL = _rentalDal.GetAll();

            if (rentalALL is null)
            {
                return new ErrorDataResult<List<Rental>>( Messages.NotFound);

            }


            return new SuccessDataResult<List<Rental>>(rentalALL, Messages.Listed);
           
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            var rentalGetById = _rentalDal.Get(c => c.Id == rentalId);
            if (rentalGetById is null)
            {
                return new ErrorDataResult<Rental>(Messages.NotFound);

            }

            return new SuccessDataResult<Rental>(rentalGetById, Messages.Listed);


        }

        public IDataResult<List<Rental>> GetRentalByCarId(int carId)
        {
            var getrentalByCarId = _rentalDal.GetAll(rental=>rental.CarId==carId);

            if (getrentalByCarId is null)
            {

                return new ErrorDataResult<List<Rental>>(Messages.NotFound);
            }

            return new SuccessDataResult<List<Rental>>(getrentalByCarId);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            var rentalDetails = _rentalDal.GetRentalDetails();
            if (rentalDetails is null)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(rentalDetails, Messages.NotFound);

            }

            return new SuccessDataResult<List<RentalDetailDto>>(rentalDetails, Messages.Listed);
        }

        public IResult Update(Rental rental)
        {
            var rentalByUpdate = _rentalDal.Get(c => c.Id == rental.Id);
            if (rentalByUpdate is null)
            {
                return new SuccesResult(Messages.NotFound);

            }
            _rentalDal.Update(rental);

            return new SuccesResult(Messages.Updated);
            
        }
    }
}
