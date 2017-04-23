﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScraper.Models
{
    public class ServiceDetails
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public ServiceStatus Status { get; set; }
    }
}
