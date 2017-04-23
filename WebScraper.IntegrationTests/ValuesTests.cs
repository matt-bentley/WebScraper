using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Helpers;
using WebScraper.Models;
using Xunit;

namespace WebScraper.IntegrationTests
{
    public class ValuesTests : IDisposable
    {
        TestServer _host;
        HttpClient _client;

        public ValuesTests()
        {
            var webHostBuilder = new WebHostBuilder()
                .UseStartup<Startup>();

            _host = new TestServer(webHostBuilder);
            _client = _host.CreateClient();
        }

        [Fact]
        public async Task CountryStatusCodeOK()
        {
            var response = await _client.GetAsync("api/values");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CountryStatusCount()
        {
            var response = await _client.GetAsync("api/values");
            string stringData = response.Content.ReadAsStringAsync().Result;
            List<ServiceDetails> data = JsonConvert.DeserializeObject<List<ServiceDetails>>(stringData);
            IDictionary<string, string> checkData = Helper.GetCountries();
            Assert.Equal(data.Count, checkData.Count);
        }

        [Fact]
        public async Task CountryStatusChecks()
        {
            var response = await _client.GetAsync("api/values");
            string stringData = response.Content.ReadAsStringAsync().Result;
            List<ServiceDetails> data = JsonConvert.DeserializeObject<List<ServiceDetails>>(stringData);
            IDictionary<string, string> checkData = Helper.GetCountries();

            bool missingKey = false;

            for(int i = 0; i < data.Count; i++)
            {
                if (!checkData.ContainsKey(data[i].CountryCode))
                    missingKey = true;
            }

            Assert.False(missingKey);
        }

        public void Dispose()
        {
            _host.Dispose();
            _client.Dispose();
        }
    }
}
