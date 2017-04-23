using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HtmlAgilityPack;
using System.Net;
using System.IO;
using WebScraper.Models;
using System.Collections;
using WebScraper.Helpers;

namespace WebScraper.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task<List<ServiceDetails>> Get()
        {
            List<ServiceDetails> details = new List<ServiceDetails>();

            try
            {
                HtmlDocument doc = new HtmlDocument();

                var webRequest = HttpWebRequest.Create("http://ec.europa.eu/taxation_customs/vies/monitoring.html");
                WebResponse response = await webRequest.GetResponseAsync();
                using (Stream stream = response.GetResponseStream())
                {
                    doc.Load(stream);
                }

                HtmlNode availability = doc.DocumentNode.SelectNodes("//div[@class='availability']").First();
                HtmlNode chart = availability.SelectSingleNode("//div[@class='chart']");

                ServiceStatus[] serviceStatuses = Helper.GetEnumValues<ServiceStatus>();

                for (int i = 0; i < serviceStatuses.Length; i++)
                {
                    HtmlNodeCollection services = chart.SelectNodes(".//span[@class='" + serviceStatuses[i].ToString() + "']");

                    if(services != null)
                    {
                        for (int s = 0; s < services.Count; s++)
                        {
                            details.Add(new ServiceDetails()
                            {
                                CountryCode = services[s].InnerHtml,
                                CountryName = Helper.GetCountry(services[s].InnerHtml),
                                Status = serviceStatuses[i]
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return details;
        }
    }
}
