using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OuterWebApiDataReceiverService : IOuterWebApiDataReceiverService
    {
        private const string baseUrl = "https://api.exchangerate.host/";

        public async Task<string> GetResponseFromOuterWebAPI()
        {
            HttpClient client = new();

            client.BaseAddress = new Uri(baseUrl);

            HttpResponseMessage response = await client.GetAsync("timeseries?start_date=2022-05-07&end_date=2022-05-10&base=USD&symbols=EUR,USD,PLN");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
