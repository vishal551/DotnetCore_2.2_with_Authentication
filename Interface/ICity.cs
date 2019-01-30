using AuthCoreWEBAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthCoreWEBAPI.Interface
{
  public  interface ICity
    {
        IEnumerable<City> GetAllCity();
    }
}
