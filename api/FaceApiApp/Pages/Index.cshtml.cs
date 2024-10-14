using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FaceApiApp.Pages;

public class IndexModel : PageModel
{
    private readonly HttpClient _httpClient;

    public List<Detection> Detections { get; set; } = new List<Detection>();

    // Injeção do HttpClient nomeado "ApiClient"
    public IndexModel(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
    }

    public async Task OnGetAsync()
    {
        // Fazendo a requisição para a API usando URI relativa
        var response = await _httpClient.GetAsync("api/detections");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            Detections = JsonConvert.DeserializeObject<List<Detection>>(jsonString);
        }
    }
}


