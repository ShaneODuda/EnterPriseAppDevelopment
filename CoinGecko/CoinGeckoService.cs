using CoinGecko;
using System.Net.Http.Json;

public class CoinGeckoService
{
    private readonly HttpClient _httpClient;

    public CoinGeckoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Crypto>> GetCryptosAsync()
    {
        string url = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd";
        return await _httpClient.GetFromJsonAsync<IEnumerable<Crypto>>(url)
               ?? Enumerable.Empty<Crypto>(); // Ensure it won't return null
    }
    public async Task<Crypto?> GetCryptoDetailsAsync(string id)
    {
        string url = $"https://api.coingecko.com/api/v3//coins/{id}";
        return await _httpClient.GetFromJsonAsync<Crypto>(url);
    }
}