using HtmlAgilityPack;
using System;
using System.Net.Http;

namespace Web_Scraper
{
    class Program
    {
        static void Main(String[] args)
        {
            // Send get request to weather.com
            string url = "https://weather.com/en-AU/weather/today/l/131837017d4f362c0baabb987cc709163d0107e40ec35b69add9390718373e65";
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            // Get the Temperature
            var temperatureElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='CurrentConditions--tempValue--MHmYY']");
            var temperature = temperatureElement.InnerText.Trim();
            Console.WriteLine(temperature);

            // Get the conditions
            var conditionElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='CurrentConditions--phraseValue--mZC_p']");
            var condition = conditionElement.InnerText.Trim();
            Console.WriteLine(condition);

            // Get the location
            var locationElement = htmlDocument.DocumentNode.SelectSingleNode("//h1[@class='CurrentConditions--location--1YWj_']");
            var location = locationElement.InnerText.Trim();
            Console.WriteLine(location);
        }
    }
}