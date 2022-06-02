using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car , RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result =
                    from c in context.Cars
                    join b in context.Brands on c.BrandId equals b.BrandId
                    join co in context.Colors on c.ColorId equals co.ColorId
                    select new CarDetailDto
                    {
                        CarName = c.CarName,
                        BrandName = b.BrandName,
                        DailyPrice = c.DailyPrice,
                        ColorName = co.ColorName,
                        CarId = c.CarId,
                        Description = c.Description

                    };
                return result.ToList();
            }

        }
        
    }
}

