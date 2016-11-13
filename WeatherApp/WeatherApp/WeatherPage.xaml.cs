using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace WeatherApp
{
    public partial class WeatherPage : ContentPage
    {
        public WeatherPage()
        {
            InitializeComponent();

            Title = "Sample Weather App";
            BindingContext = new Weather();

            GetWeatherBtn.Clicked += async (sender, e) =>
            {
                if (string.Equals(string.Empty, ZipCodeEntry.Text)) return;

                var weather = await Core.GetWeather(ZipCodeEntry.Text);
                BindingContext = weather;
                GetWeatherBtn.Text = "Search Again";
            };
        }
    }
}
