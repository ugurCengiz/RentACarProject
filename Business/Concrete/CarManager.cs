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
         ICarDal _CarDal;

         public CarManager(ICarDal carDal)
         {
             _CarDal = carDal;
         }
        public List<Car> GetAll()
        {
            return _CarDal.GetAll();
        }
    }
}
