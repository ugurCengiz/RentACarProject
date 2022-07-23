using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Dtos
{
   public class CarImageDto:IDto
    {
        public int CarId { get; set; }
        public string ImagePath { get; set; }
    }
}
