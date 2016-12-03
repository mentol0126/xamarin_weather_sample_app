using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace WeatherApp
{
    public class DetaService
    {
        public static async Task<dynamic> GetDataFromService(string queryString)
        {
            var client = new HttpClient();

            var json = string.Empty;

            try
            {
                var response = await client.GetAsync(new Uri(queryString));

                if (response == null) return null;

                json = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            dynamic data = JsonConvert.DeserializeObject(json);

            return data;
        }
    }
}
