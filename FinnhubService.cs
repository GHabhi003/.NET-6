using System.Text.Json;
using ServiceContract;
using Microsoft.Extensions.Configuration;

namespace Services
{
    public class FinnhubService : IFinnhubService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public FinnhubService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        public async Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://finnhub.io/api/v1/stock/profile2?symbol={stockSymbol}&token={_configuration["FinnhubToken"]}")
                };
                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(request);
                Stream s = httpResponseMessage.Content.ReadAsStream();
                StreamReader reader = new StreamReader(s);
                string response = reader.ReadToEnd();
                
                var parsedCompanyProfile = JsonSerializer.Deserialize<Dictionary<string, object>?>(response);
                return parsedCompanyProfile;
            }
        }

        public async Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={_configuration["FinnhubToken"]}"),
                    Method = HttpMethod.Get,
                };
                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(requestMessage);
                var stream = await httpResponseMessage.Content.ReadAsStreamAsync();
                StreamReader reader = new StreamReader(stream);
                string response = reader.ReadToEnd();
                var parsedStockPriceQuote = JsonSerializer.Deserialize<Dictionary<string, object>?>(response);
                return parsedStockPriceQuote;
            }
        }
    }
}
