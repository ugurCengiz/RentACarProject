﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
       
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();

        IResult Add(User user);
        List<OperationClaim> GetClaims(User user);
        IDataResult<User> GetByMail(string email);

        IDataResult<User> GetById(int id);
    }
}
