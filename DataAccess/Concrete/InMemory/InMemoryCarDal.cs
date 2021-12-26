using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,dailyPrice=1000,modelYear=2000,description="bmw"},
                new Car{Id=2,BrandId=1,ColorId=2,dailyPrice=2000,modelYear=2010,description="merso"},
                new Car{Id=3,BrandId=1,ColorId=3,dailyPrice=4000,modelYear=2020,description="ford"},
                new Car{Id=4,BrandId=2,ColorId=4,dailyPrice=7000,modelYear=2004,description="hyundai"},
                new Car{Id=5,BrandId=2,ColorId=5,dailyPrice=3000,modelYear=1998,description="tofas"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            //Car carToDelete=null;
            //foreach (var crr in _cars)
            //{
            //    if (car.Id==crr.Id)
            //    {
            //        carToDelete = crr;
            //    }
            //}
            //_cars.Remove(carToDelete);
            //******alttaki linq ile üstteki normal
            var cartooDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(cartooDelete);

        }
        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.modelYear = car.modelYear;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.dailyPrice = car.dailyPrice;
            carToUpdate.description = car.description;

        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int brandId)
        {
            //List<int> result=new List<int>();
            //foreach (var carr in _cars)
            //{
            //    result.Add(carr.Id);
            //}
            //return result;
            var resultt = _cars.Where(c => c.BrandId==brandId);
            return resultt.ToList();
        }

        
    }
}
