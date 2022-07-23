using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;


        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        //[SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Rental rental)
        {
            var results = _rentalDal.GetAll((r => r.CarId == rental.CarId));
            foreach (var result in results)
            {
                if (result.ReturnDate==null || (rental.RentDate >= result.RentDate && rental.RentDate <= result.ReturnDate) ||
                    (rental.ReturnDate >= result.RentDate && rental.RentDate <= result.ReturnDate))
                {
                    return new ErrorResult(Messages.RentalError);

                }
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.SuccessRentalUpdate);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.ProductDeleted);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            var result = _rentalDal.GetRentalDetails();
            return new SuccessDataResult<List<RentalDetailDto>>(result, Messages.ProductListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(b => b.Id == id));
        }

        public IResult EndRental(Rental rental)
        {
            var result = _rentalDal.GetAll();
            var updatedRental = result.LastOrDefault();
            if (updatedRental.ReturnDate != null && updatedRental.RentDate < DateTime.Now && updatedRental.ReturnDate > DateTime.Now)
            {
                updatedRental.ReturnDate = DateTime.Now;
                _rentalDal.Update(updatedRental);
                return new SuccessResult(Messages.SuccessRentalUpdate);
            }

            return new ErrorResult(Messages.ErrorRentalUpdate);
        }

        public IResult isCarAvailable(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId);

            if (result.Any(r => r.RentDate != null && r.ReturnDate == null))
            {
                return new ErrorResult(Messages.CarIsNotAvailable);
            }
            else
            {
                return new SuccessResult();
            }
        }

        public IDataResult<List<RentalDetailDto>> GetRentalsByCarId(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.CarId == carId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.CustomerId == customerId));
        }
    }
}
