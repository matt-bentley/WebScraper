using System;
using WebScraper.Helpers;
using WebScraper.Models;
using Xunit;

namespace WebScraper.Tests
{
    public class HelperTests
    {
        [Fact]
        public void CountryCount()
        {
            int validCount = 28;
            int testCount = Helper.GetCountries().Count;
            Assert.Equal(validCount, testCount);
        }

        [Fact]
        public void GetCountryMatch()
        {
            string countryCode = "AT";
            string validCountry = "Austria";
            string testCountry = Helper.GetCountry(countryCode);
            Assert.Equal(validCountry, testCountry);
        }

        [Fact]
        public void CountryCountNoMatch()
        {
            string countryCode = "UK";
            string testCountry = Helper.GetCountry(countryCode);
            Assert.Null(testCountry);
        }

        [Fact]
        public void ServiceStatusCount()
        {
            ServiceStatus[] serviceStatuses = Helper.GetEnumValues<ServiceStatus>();
            int validCount = 3;
            Assert.Equal(validCount, serviceStatuses.Length);
        }
    }
}
