using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
   public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IResult EndRental(Rental rental);
        IResult isCarAvailable(Rental rental);


        IDataResult<List<RentalDetailDto>> GetRentalsByCarId(int carId);
        IDataResult<List<RentalDetailDto>> GetRentalByCustomerId(int customerId);
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IDataResult<Rental> GetById(int id);
    }
}
