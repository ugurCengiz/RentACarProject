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
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result =
                    from c in filter == null ? context.Cars : context.Cars.Where(filter)
                    join b in context.Brands on c.BrandId equals b.BrandId
                    join co in context.Colors on c.ColorId equals co.ColorId
                    
                    select new CarDetailDto
                    {
                        CarName = c.CarName,
                        BrandName = b.BrandName,
                        DailyPrice = c.DailyPrice,
                        ColorName = co.ColorName,
                        CarId = c.CarId,
                        Description = c.Description,
                        ModelYear = c.ModelYear,
                        BrandId = c.BrandId,
                        ColorId = c.ColorId,
                        Images = (from i in context.CarImages where (c.CarId == i.CarId) select i.ImagePath).ToList()
                    };
                return result.ToList();
            }

        }

        public CarDetailDto GetCarDetail(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result =
                    from c in filter == null ? context.Cars : context.Cars.Where(filter)
                    join b in context.Brands on c.BrandId equals b.BrandId
                    join co in context.Colors on c.ColorId equals co.ColorId

                    select new CarDetailDto
                    {
                        CarName = c.CarName,
                        BrandName = b.BrandName,
                        DailyPrice = c.DailyPrice,
                        ColorName = co.ColorName,
                        CarId = c.CarId,
                        Description = c.Description,
                        ModelYear = c.ModelYear,
                        BrandId = c.BrandId,
                        ColorId = c.ColorId,
                        Images = (from i in context.CarImages where (c.CarId == i.CarId) select i.ImagePath).ToList()
                    };
                return result.SingleOrDefault();
            }
        }
    }
}

