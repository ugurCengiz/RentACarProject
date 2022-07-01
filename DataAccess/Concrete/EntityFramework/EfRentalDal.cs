using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
  public  class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                    join cu in context.Customers on r.CustomerId equals cu.CustomerId
                    join c in context.Cars on r.CarId equals c.CarId
                    join b in context.Brands on c.BrandId equals b.BrandId
                    join col in context.Colors on c.ColorId equals col.ColorId
                    join u in context.Users on cu.UserId equals u.Id
                    select new RentalDetailDto
                    {
                        RentalId = r.Id,
                        BrandName = b.BrandName,
                        ColorName = col.ColorName,
                        CustomerName = u.FirstName +" "+u.LastName,
                        RentDate = r.RentDate,
                        ReturnDate = r.ReturnDate
                        
                    };
                return result.ToList();
            }
        }
    }
}
