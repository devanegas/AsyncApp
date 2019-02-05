using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OpenWeatherMap.Standard;

namespace AsyncProgram.Services
{
    public interface IAsyncService
    {
       Task<WeatherData> GetWeatherAsync(string zipCode, string countryCode, WeatherUnits units);
    }
}
