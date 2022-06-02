using System;
using System.Collections.Generic;
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
            CarManager carManager = new CarManager(new EfCarDal());
            
            
            
            AddTest(carManager);
            DetailsTest(carManager);
        }

        private static void AddTest(CarManager carManager)
        {
            carManager.Add(new Car
            {
                CarName = "Cayman911",
                BrandId = 5,
                DailyPrice = 500,
                Description = "Sıfır Araç",
                ColorId = 1, 
                ModelYear = 2022,
                
            });
        }

        public static void DetailsTest(CarManager carManager)
        {
            var result = carManager.GetProductDetails();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    System.Console.WriteLine(car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
                }
            }
            else
            {
                System.Console.WriteLine(result.Message);
            }
           
        }
    }
}
