using System;
using System.Collections.Generic;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;

using Entities.Concrete;

namespace Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new EfCarDal());
             EfRentalDal rentalManager = new EfRentalDal();
            // DetailsTest(rentalManager.GetRentalDetails());
            foreach (var rental in rentalManager.GetRentalDetails())
            {
                System.Console.WriteLine(rental.BrandName);
            }

            //RentalAddTest();


            //AddTest(carManager);

        }

        private static void RentalAddTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental()
            {
                CarId = 1,
                CustomerId = 1,
                RentDate = new DateTime(2022, 7, 1),
                ReturnDate = new DateTime(2022, 9, 1)
            });
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

        public static void DetailsTest(RentalManager rentalManager)
        {
            var result = rentalManager.GetRentalDetails();
            if (result.Success==true)
            {
                foreach (var rental in result.Data)
                {
                    System.Console.WriteLine(rental.RentalId);
                }
            }
            else
            {
                System.Console.WriteLine(result.Message);
            }
           
        }

        
    }
}
