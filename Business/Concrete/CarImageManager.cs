using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Business.Concrete
{
    class CarImageManager:ICarImageService
    {
        private ICarImageDal _carImagesDal;

        public CarImageManager(ICarImageDal carImagesDal)
        {
            _carImagesDal = carImagesDal;
        }

        [SecuredOperation("product.add,admin")]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId), CheckIfImageExtensionValid(file));
            if (result != null)
            {

                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date=DateTime.Now;
            _carImagesDal.Add(carImage);
            return new SuccessResult();
        }
        [SecuredOperation("product.add,admin")]
        public IResult Delete(CarImage carImage)
        {
           string path = GetByImageId(carImage.CarImageId).Data.ImagePath;
            FileHelper.Delete(path);
            _carImagesDal.Delete(carImage);
            return new SuccessResult();
        }
        [SecuredOperation("product.add,admin")]
        public IResult Updated(IFormFile file, CarImage carImage)
        {
            string oldPath = GetByImageId(carImage.CarImageId).Data.ImagePath;
            FileHelper.Update(file,oldPath);
           _carImagesDal.Update(carImage);
           return new SuccessResult(Messages.ProductUpdated);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImagesDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<CarImage> GetByImageId(int id)
        {
            return new SuccessDataResult<CarImage>(_carImagesDal.Get(c => c.CarImageId == id));
        }
        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(ChechIfCarHaveNoImage(carId));
        }

        IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImagesDal.GetAll(c => c.CarId == carId).Count;
            if (result>=5)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IResult CheckIfImageExtensionValid(IFormFile file)
        {
            bool isValidFileExtension = Messages.ValidImageFileTypes.Any(t => t == Path.GetExtension(file.FileName).ToUpper());
            if (!isValidFileExtension)
                return new ErrorResult(Messages.InvalidImageExtension);
            return new SuccessResult();
        }

        private List<CarImage> ChechIfCarHaveNoImage(int carId)
        {
            string path = @"\Images\default.png";
            var result = _carImagesDal.GetAll(c => c.CarId == carId);
            if (!result.Any())
            {
                return new List<CarImage> {new CarImage {CarId = carId, ImagePath = path}};

            }

            return result;
        }


    }
}
