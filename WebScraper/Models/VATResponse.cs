using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VATCheckerApi.Models
{
    public class VATResponse
    {
        public string CountryCode { get; set; }
        public string VATNumber { get; set; }
        public DateTime RequestDate { get; set; }
        public bool Valid { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
    }
}
