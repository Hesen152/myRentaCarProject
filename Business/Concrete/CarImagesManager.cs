using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.ImageUpload;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        public ICarImagesDal _carImagesDal;

           public CarImagesManager(ICarImagesDal carImagesDal)
        {
            _carImagesDal = carImagesDal;

                
        }



        public IResult Add(CarImages carImages)
        {
          var result =  BusinessRules.Run(CarImageLimitChecking(carImages.CarId));
            if (result is null)
            {
                return result;

            }
            saveImage(carImages);

            carImages.Date = DateTime.Now;
            _carImagesDal.Add(carImages);

            return new SuccesResult();

        }

        public IResult Delete(CarImages carImages)
        {

            var getCars = _carImagesDal.Get(C=>C.Id==carImages.Id);
            if (getCars is null)
            {
                return new ErrorResult();

            }

            _carImagesDal.Delete(getCars);

            return new SuccesResult(Messages.Deleted);
             
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            var result = _carImagesDal.GetAll();
            
            if (result is null)
            {
                return new  ErrorDataResult<List<CarImages>>(result,Messages.NotFound);

            }

            return  new SuccessDataResult<List<CarImages>>(result,Messages.Listed);
        }

        public IDataResult<CarImages> GetById(int carId)
        {
            var carImages = _carImagesDal.Get(c => c.Id == carId);
            if (carImages is null)
            {
                return new ErrorDataResult<CarImages>(carImages);

            }
            return new SuccessDataResult<CarImages>(carImages,Messages.Listed);

        }

        public IResult Update(CarImages carImages)
        {
            var carimagess = _carImagesDal.Get(c => c.Id == carImages.Id);

            if (carImages is null)
            {
                return new ErrorResult(Messages.NotFound);

            }
            saveImage(carImages);
            carImages.Date = DateTime.Now;
            _carImagesDal.Update(carImages);

            return new SuccesResult(Messages.Updated);

        }


        public static void saveImage(CarImages carImages)
        {
            carImages.ImagePath = UploadImagesPath.CarImgSave(carImages.Image).Result.ToString();
        }




        private IResult CarImageLimitChecking(int carImageId)
        {
            var imgCount = _carImagesDal.GetAll().Count();

            if (imgCount<=5)
            {
                return new ErrorResult(Messages.CarLimitedDenied);
            }

            return new SuccesResult();
        }

       

        public IDataResult<List<CarImages>> GetListByCardId(int carId)
        {
            var GetList = _carImagesDal.GetAll(c => c.CarId == carId);
            if (GetList.Count() > 0)
            {
                return new SuccessDataResult<List<CarImages>>(GetList, Messages.Listed);


            }

            var defaultPath = PathName.ImagesCarDefault;
            var ImageDefault = new List<CarImages> { new CarImages { ImagePath = defaultPath } };


            return new SuccessDataResult<List<CarImages>>(ImageDefault);
        }
    }
}
