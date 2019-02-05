using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenWeatherMap.Standard;

namespace AsyncProgram.Services
{
    public class AsyncService : IAsyncService
    {
        Forecast forecast = new Forecast();
        WeatherData data = null;

        public async Task<WeatherData> GetWeatherAsync(string zipCode, string countryCode, WeatherUnits units)
        {
            try
            {
                var json = await new HttpClient().GetStringAsync($"http://api.openweathermap.org/data/2.5/weather?zip={zipCode},{countryCode}&APPID=49b6fa96350f8c676a1b763f2005960c&units=metric");
                data = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherData>(json);
                //data = await forecast.GetWeatherDataByZipAsync(appId, zipCode, countryCode,units);
            }
            catch (Exception e)
            {
                throw;
            }

            return data;
        }
    }
}
