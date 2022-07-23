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

namespace DataAccess.Concrete.EntityFramework
{
   public class EfCarImageDal:EfEntityRepositoryBase<CarImage,RentACarContext>,ICarImageDal
    {
        public List<CarImageDto> GetCarImageDetails(Expression<Func<CarImage, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from cari in filter == null ? context.CarImages : context.CarImages.Where(filter)
                    join c in context.Cars on cari.CarId equals c.CarId
                    select new CarImageDto
                    {
                        CarId = c.CarId,
                        ImagePath = cari.ImagePath
                    };
                return result.ToList();
            }
        }
    }
}
