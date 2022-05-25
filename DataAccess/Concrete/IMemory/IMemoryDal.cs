using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.IMemory
{
   public class IMemoryDal:ICarDal
   {
        List<Car> _cars;

       public IMemoryDal()
       {
           _cars = new List<Car>
           {
               new Car {Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 100, ModelYear = 2015, Description = "BMV 320d"},
               new Car {Id = 2, BrandId = 1, ColorId = 2, DailyPrice = 150, ModelYear = 2016, Description = "BMV M5"},
               new Car {Id = 3, BrandId = 2, ColorId = 1, DailyPrice = 200, ModelYear = 2017, Description = "AUDİ A5"},
               new Car {Id = 4, BrandId = 2, ColorId = 2, DailyPrice = 250, ModelYear = 2018, Description = "AUDİ A6"},
               new Car {Id = 5, BrandId = 3, ColorId = 1, DailyPrice = 300, ModelYear = 2019, Description = "VOLVO XC90 "}
           };
       }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }
    }
}
