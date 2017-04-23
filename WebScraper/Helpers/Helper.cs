using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScraper.Helpers
{
    public static class Helper
    {
        private static readonly IDictionary<string, string> _countries = new ConcurrentDictionary<string, string>(new Dictionary<string, string>()
        {
            { "AT", "Austria" },
            { "BE", "Belgium" },
            { "BG", "Bulgaria" },
            { "CY", "Cyprus" },
            { "CZ", "Czech Republic" },
            { "DE", "Germany" },
            { "DK", "Denkmark" },
            { "EE", "Estonia" },
            { "EL", "Greece" },
            { "ES", "Spain" },
            { "FI", "Finland" },
            { "FR", "France" },
            { "HR", "Croatia" },
            { "HU", "Hungary" },
            { "IE", "Ireland" },
            { "IT", "Italy" },
            { "LU", "Luxembourg" },
            { "LV", "Latvia" },
            { "LT", "Lithuania" },
            { "MT", "Malta" },
            { "NL", "The Netherlands" },
            { "PL", "Poland" },
            { "PT", "Portugal" },
            { "RO", "Romania" },
            { "SE", "Sweden" },
            { "SI", "Slovenia" },
            { "SK", "Slovakia" },
            { "GB", "The United Kingdom" }         
        });

        public static string GetCountry(string countryCode)
        {
            string country;
            _countries.TryGetValue(countryCode, out country);
            return country;
        }

        public static IDictionary<string, string> GetCountries()
        {
            return _countries;          
        }

        public static T[] GetEnumValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToArray<T>();
        }
    }
}
