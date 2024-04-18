using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Samuel_McMasters.DataModels
{
    public class City
    {
        public int CityId { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public string CreatedBy { get; set; }
    }
}
