using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string city = wCity.Text.Trim();
            HttpClient client = new HttpClient();
            string url = $"https://api.weatherapi.com/v1/current.json?key=d7799ebf325c4e29bfd173617243001&q={city}&aqi=yes";
            string result = await client.GetStringAsync(url);
            var json = JObject.Parse(result);
            string temp = json["current"]["temp_c"].ToString();
            wResult.Text = $"In {city} is {temp} °C";
        }
    }
}
