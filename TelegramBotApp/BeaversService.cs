using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using API.Models;
using static System.Net.WebRequestMethods;

public class BeaversService(HttpClient httpClient)
{
    public async Task<IEnumerable<BeaverModel>> GetBeaversAsync()
    {
        var response = await httpClient.GetAsync("api/Beavers");
        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var beavers = JsonSerializer.Deserialize<IEnumerable<BeaverModel>>(responseContent, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });
            return beavers;
        }
        return null; // or throw an exception
    }
}