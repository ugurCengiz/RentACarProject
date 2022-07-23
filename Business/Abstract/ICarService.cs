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
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult <List<Car>> GetCarsByBrandId(int brandId);
        IDataResult <List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetCarDetailsCarId(int id);

        IDataResult<CarDetailDto> GetCarDetailCarId(int id);
        IDataResult<List<CarDetailDto>> GetCarsDtoByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarsDtoByColorId(int colorId);
        IDataResult<List<Car>> GetCarsByCarId(int carId);
        IDataResult<List<CarDetailDto>> GetCarByColorIdAndBrandId(int colorId, int brandId);


    }
}
