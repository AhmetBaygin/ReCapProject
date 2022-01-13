using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Linq;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            CarTest2();
            //BrandTest();

        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine(brandManager.GetByBrandId(1).Data.BrandName);
        }

        private static void CarTest2()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var sonuc = carManager.GetCarDetails();
            if (sonuc.Success==true)
            {
                foreach (var car in sonuc.Data)
                {
                    Console.WriteLine(car.ColorName + " - " + car.CarName + " - " + car.BrandName);
                }
            }
            
            //carManager.Delete(new Car { DailyPrice = 31,CarId=7 });
            foreach (var carr in carManager.GetAll().Data)
            {
                Console.WriteLine(carr.DailyPrice);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarsByColorId(3);
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.Description);
            }
            
            var result2 =carManager.Add(new Car { Description = "bmwm4", DailyPrice = 31, BrandId = 2, ColorId = 3, ModelYear = 2000 });
            if (result2.Success)
            {
                Console.WriteLine(result2.Message); 
            }
            
            
        }
    }
}
