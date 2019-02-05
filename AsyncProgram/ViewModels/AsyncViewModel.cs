using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using AsyncProgram.Services;
using MvvmCross.ViewModels;
using MvvmCross.Commands;
using OpenWeatherMap.Standard;
using System.Threading.Tasks;

namespace AsyncProgram.ViewModels
{
    public class AsyncViewModel : MvxViewModel
    {
        private readonly IAsyncService _asyncService;

        public AsyncViewModel(IAsyncService asyncService)
        {
            _asyncService = asyncService;
            //_zipCode = "84627";
            _countryCode = "us";
        }

        private WeatherData _weather;
        public WeatherData Weather
        {
            get => _weather;
            set
            {
                SetField(ref _weather, value);
                RaisePropertyChanged(nameof(Weather));
            }
        }

        private string _appId;
        public string AppId
        {
            get => _appId;
            set
            {
                SetField(ref _appId, value);
                Recalculate();
                //RaisePropertyChanged(nameof(Weather));
            }
        }

        private string _zipCode;
        public string ZipCode
        {
            get => _zipCode;
            set
            {
                SetField(ref _zipCode, value);
                Recalculate();
                //RaisePropertyChanged(nameof(Weather));
            }
        }


        private string _countryCode;
        public string CountryCode
        {
            get => _countryCode;
            set
            {
                SetField(ref _countryCode, value);
                Recalculate();
                //RaisePropertyChanged(nameof(Weather));
            }
        }

        public async Task Recalculate()
        {
            Weather = await  _asyncService.GetWeatherAsync(ZipCode, CountryCode, WeatherUnits.Metric);
        }


        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            RaisePropertyChanged(propertyName);
            return true;
        }
    }

}
