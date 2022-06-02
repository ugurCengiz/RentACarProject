using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.IMemory
{
   public class IMemoryDal:ICarDal
   {
        List<Car> _cars;

       public IMemoryDal()
       {
           _cars = new List<Car>
           {
               new Car {CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 100, ModelYear = 2015, Description = "BMV 320d"},
               new Car {CarId = 2, BrandId = 1, ColorId = 2, DailyPrice = 150, ModelYear = 2016, Description = "BMV M5"},
               new Car {CarId = 3, BrandId = 2, ColorId = 1, DailyPrice = 200, ModelYear = 2017, Description = "AUDİ A5"},
               new Car {CarId = 4, BrandId = 2, ColorId = 2, DailyPrice = 250, ModelYear = 2018, Description = "AUDİ A6"},
               new Car {CarId = 5, BrandId = 3, ColorId = 1, DailyPrice = 300, ModelYear = 2019, Description = "VOLVO XC90 "}
           };
       }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.CarId == id).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Color Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        Car IEntityRepository<Car>.Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
