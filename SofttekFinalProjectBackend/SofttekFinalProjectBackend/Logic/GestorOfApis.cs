

using System.Text.Json;

namespace SofttekFinalProjectBackend.Logic
{
    public class GestorOfApis
    {
        public GestorOfApis()
        {
        }

        public async Task<double> GetDollarValueAsync()
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string apiUrl = "https://dolarapi.com/v1/dolares/blue";
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = await response.Content.ReadAsStringAsync();
                        var blueDollarData = JsonSerializer.Deserialize<BlueDollarData>(jsonContent);
                        double sellValue = blueDollarData.venta;
                        return sellValue;
                    }
                        return -1;

                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<double> GetCryptoToDollarValueAsync(string crypto)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string apiUrl = $"https://api.coingecko.com/api/v3/coins/{crypto}/tickers";
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = await response.Content.ReadAsStringAsync();

                        using (JsonDocument document = JsonDocument.Parse(jsonContent))
                        {
                            JsonElement root = document.RootElement;
                            JsonElement tickers = root.GetProperty("tickers")[0];
                            double usdValue = tickers.GetProperty("converted_last").GetProperty("usd").GetDouble();
                            return usdValue;
                        }
                    }
                    return -1;

                }
            }
            catch (Exception ex)
            {
                return -1;

            }
        }

        public class BitcoinData
        {
            public string Name { get; set; }
            public List<Ticker> Tickers { get; set; }
        }

        public class Ticker
        {
            public double Last { get; set; }
            public double Volume { get; set; }
            public ConvertedLast ConvertedLast { get; set; }
        }

        public class ConvertedLast
        {
            public double Usd { get; set; }
        }

    }


}
