using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=1000,ModelYear=2000,Description="bmw"},
                new Car{CarId=2,BrandId=1,ColorId=2,DailyPrice=2000,ModelYear=2010,Description="merso"},
                new Car{CarId=3,BrandId=1,ColorId=3,DailyPrice=4000,ModelYear=2020,Description="ford"},
                new Car{CarId=4,BrandId=2,ColorId=4,DailyPrice=7000,ModelYear=2004,Description="hyundai"},
                new Car{CarId=5,BrandId=2,ColorId=5,DailyPrice=3000,ModelYear=1998,Description="tofas"}
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
            var cartooDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(cartooDelete);

        }
        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

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

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
