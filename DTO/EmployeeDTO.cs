using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthCoreWEBAPI.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public int ID_City { get; set; }
        public string Name { get; set; }
         public Int64 Mobile { get; set; }
        public string Gender { get; set; }
    }
}
