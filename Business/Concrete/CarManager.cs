using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if(car.DailyPrice>0 && car.Description.Length > 2)
            {
                _carDal.Add(car);
                return new SuccessResult("ekleme başarılı");
            }
            return new SuccessResult("ekleme başarılı");
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            
            return new SuccessResult("silme başarılı");
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),"listelendi");
            
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),"detaylı listelendi");
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=>p.BrandId==id),"brandid ye göre listelendi");
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }

        public IResult Update(Car car)
        {
            if (car.Description.Length<1)
            {
                return new ErrorResult("güncelleme başarısız");
            }
            _carDal.Update(car);
            return new SuccessResult("güncelleme başarılı");
        }
    }
}
