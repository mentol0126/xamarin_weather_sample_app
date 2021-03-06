﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace WeatherApp
{
    public partial class WeatherPage : ContentPage
    {
        static public bool RegOK { get; set; } = false;

        public WeatherPage()
        {
            InitializeComponent();

            Title = "Sample Weather App";
            BindingContext = new Weather();

            ZipCodeEntry.Text = string.Empty;

            GetWeatherBtn.Clicked += async (sender, e) =>
            {
                if (string.Equals(string.Empty, ZipCodeEntry.Text)) return;

                // くるくる表示
                Working.IsVisible = true;

                // 郵便番号チェック
                if (!RegOK)
                {
                    GetWeatherBtn.Text = "Re: Input";
                    return;
                }

                var weather = await Core.GetWeather(ZipCodeEntry.Text);
                BindingContext = weather;

                // くるくる非表示
                Working.IsVisible = false;

                // ポップアップで結果を簡易表示
                await DisplayAlert("Result", weather.Title + " " + weather.Temperature, "OK");

                GetWeatherBtn.Text = "Search Again";
            };
        }
    }
}
