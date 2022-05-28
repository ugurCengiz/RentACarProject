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
            //SİLME VE GÜNCELLEME YAPARKEN ID EKLE AMA EKLEME YAPARKEN ID KALDIR ÇÜNKÜ OTOTMATİK ARTAN VAR


            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car
            //{
            //    BrandId = 4,
            //    CarName = "Fiat",
            //    ColorId = 4,
            //    DailyPrice = 100,
            //    Description = "Linea",
            //    ModelYear = 2019,

            //});

            //-------------------------------------------------------------------------------------------------------------------------------- 

            ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add(new Color
            //{
            //    ColorName = "Mavi"
            //});

            ////--------------------------------------------------------------------------------------------------------------------------------

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(new Brand
            //{
            //    BrandName = "Fiat"
            //});

            GetAll(carManager);
            

        }

         static void GetAll(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                System.Console.WriteLine("{0} / {1} / {2} / {3}",car.CarName,car.ModelYear,car.DailyPrice,car.Description);
            }
        }



         static void GetAll(BrandManager brandManager)
         {
             foreach (var brand in brandManager.GetAll())
             {
                 System.Console.WriteLine("{0} / {1}", brand.BrandId,brand.BrandName);
             }
         }

         static void GetAll(ColorManager colorManager)
         {
             foreach (var color in colorManager.GetAll())
             {
                 System.Console.WriteLine("{0} / {1}",color.ColorId,color.ColorName);
             }
         }
    }
}
