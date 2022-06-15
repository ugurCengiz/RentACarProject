using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file,CarImage carImage);
        IResult Delete(CarImage carImage);
        IResult Updated(IFormFile file,CarImage carImage);

        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int id);
    }
}
