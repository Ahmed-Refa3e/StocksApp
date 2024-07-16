using serviceContracts;
using System.Text.Json;
using Microsoft.Extensions.Configuration;


namespace Services;

public class Finhubservice(IHttpClientFactory httpClientFactory, IConfiguration configuration) : IFinnhubService
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly IConfiguration _configuration = configuration;

    public async Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol)
    {
        HttpClient httpClient = _httpClientFactory.CreateClient();

        string requestUrl = $"https://finnhub.io/api/v1/stock/profile2?symbol={stockSymbol}&token={_configuration["FinnhubToken"]}";

        HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(requestUrl);

        httpResponseMessage.EnsureSuccessStatusCode();

        string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

        Dictionary<string, object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(responseBody);

        if (responseDictionary == null)
        {
            throw new InvalidOperationException("No response from server");
        }

        if (responseDictionary.ContainsKey("error"))
        {
            throw new InvalidOperationException(Convert.ToString(responseDictionary["error"]));
        }
        return responseDictionary;
    }

    public async Task<Dictionary<string, object>?> GetStockQuote(string stockSymbol)
    {
        try
        {
            // Create HttpClient using the factory
            HttpClient httpClient = _httpClientFactory.CreateClient();

            // Construct the request URL
            string requestUrl = $"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={_configuration["FinnhubToken"]}";

            // Send the request asynchronously
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(requestUrl);

            // Ensure we get a successful response
            httpResponseMessage.EnsureSuccessStatusCode();

            // Read the response content as a string asynchronously
            string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

            // Deserialize the JSON response into a dictionary
            Dictionary<string, object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(responseBody);

            if (responseDictionary == null)
            {
                throw new InvalidOperationException("No response from server");
            }

            if (responseDictionary.ContainsKey("error"))
            {
                throw new InvalidOperationException(Convert.ToString(responseDictionary["error"]));
            }

            // Return the response dictionary back to the caller
            return responseDictionary;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
            return null;
        }
        catch (JsonException e)
        {
            Console.WriteLine($"JSON parsing error: {e.Message}");
            return null;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected error: {e.Message}");
            return null;
        }

    }
}
