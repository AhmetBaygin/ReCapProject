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
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarsByColorId(3);
            foreach (var item in result)
            {
                Console.WriteLine(item.Description);
            }
            carManager.Add(new Car { Description = "bmwm4", DailyPrice = 31 , BrandId=2,ColorId=3,ModelYear=2000});
            
            
        }
    }
}
