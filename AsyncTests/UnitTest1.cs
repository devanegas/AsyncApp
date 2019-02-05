using NUnit.Framework;
using MvvmCross.Tests;
using AsyncProgram.ViewModels;
using AsyncProgram.Services;
using OpenWeatherMap.Standard;
using System;

namespace Tests
{
    //[TestFixture]
    public class Tests : MvxIoCSupportingTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async System.Threading.Tasks.Task ExternalCallEqualsInternalCall()
        {

            base.Setup();
            var got = new WeatherData();
            var vm = new AsyncViewModel(new AsyncService());
            var serv = new AsyncService();
            got = await serv.GetWeatherAsync("84627", "us", WeatherUnits.Metric);

            vm.ZipCode = "84627";
            vm.CountryCode = "us";
            
            await vm.Recalculate();

            var expected = vm.Weather.WeatherDayInfo.Temperature;
            var actual = got.WeatherDayInfo.Temperature;
            Assert.AreEqual(actual, expected);
        }


        [Test]
        public async System.Threading.Tasks.Task Test()
        {

            base.Setup();
            var got = new WeatherData();
            var vm = new AsyncViewModel(new AsyncService());
            var serv = new AsyncService();

            
            try
            {
                //Failed Call
                got = await serv.GetWeatherAsync("AFSDFASDF", "us", WeatherUnits.Metric);
            }
            catch (Exception e)
            {
               if(e != null)
                    Assert.Pass();
            }

                Assert.Fail();

        }
    }
}