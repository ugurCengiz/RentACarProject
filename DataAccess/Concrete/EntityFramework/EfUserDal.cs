using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentACarContext>, IUserDal
    {
        public List<UserDetailDto> GetUserDetailDtos()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from u in context.Users
                    join c in context.Customers
                        on u.Id equals c.UsersId
                    select new UserDetailDto()
                    {
                        Id = u.Id,
                        FirstName = u.FirstName,
                        LastName = u.Lastname,
                        CompanyName = c.CompanyName,
                        CustomerId = c.CustomerId
                        
                    };
                return result.ToList();
            }
            
        }
    }
}
