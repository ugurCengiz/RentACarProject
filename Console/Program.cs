using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.IMemory;
using Entities.Concrete;

namespace Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //GetAll(carManager);

            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car
            {
                BrandId = 1,
                CarName = "a",
                ColorId = 1,
                DailyPrice = 100,
                Description = "M5",
                ModelYear = 2019,
                Id = 1
            });
            

            
        }

        private static void GetAll(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                System.Console.WriteLine(car.Description);
            }
        }
    }
}
