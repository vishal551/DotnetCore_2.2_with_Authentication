using AuthCoreWEBAPI.DTO;
using AuthCoreWEBAPI.Entities;
using AuthCoreWEBAPI.Helpers;
using AuthCoreWEBAPI.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthCoreWEBAPI.Services
{
    public class CityServices : ICity
    {
        private DataContext _context;
        public CityServices(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<City> GetAllCity()
        {
            return _context.Citys;
        }

    }
}
