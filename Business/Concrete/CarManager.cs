using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
   public class CarManager:ICarService
    {
         ICarDal _carDal;

         public CarManager(ICarDal carDal)
         {
             _carDal = carDal;
         }

        public void Add(Car car)
        {
            
            if (car.CarName.Length>2 && car.DailyPrice>0)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Koşullar Karşılanamadı !!!");
                
            }
            
            
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetCarsByBrandId(int brandId)
        {
            return _carDal.Get(c => c.BrandId == brandId);
        }

        public  Car GetCarsByColorId(int colorId)
        {
            return _carDal.Get(c => c.ColorId == colorId);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
