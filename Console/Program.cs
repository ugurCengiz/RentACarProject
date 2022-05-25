using System;
using Business.Concrete;
using DataAccess.Concrete.IMemory;

namespace Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new IMemoryDal());

            foreach (var car in carManager.GetAll())
            {
                System.Console.WriteLine(car.Description);
            }
        }
    }
}
