using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Abstract
{
  public  interface IRentalDal:IEntityRepository<Rental>
    {
        List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null);
    }
}
