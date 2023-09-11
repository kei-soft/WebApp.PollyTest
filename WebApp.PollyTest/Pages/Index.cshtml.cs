using System.Diagnostics;

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.PollyTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        private readonly IHttpClientFactory factory;

        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory factory)
        {
            this.logger = logger;
            this.factory = factory;
        }

        public async void OnGet()
        {
            // 선언된 Client 가져오기
            var client = factory.CreateClient("apiClient");

            // API 호출
            var result = await client.GetAsync("GetWeatherForecastData");

            if (result.IsSuccessStatusCode)
            {
                Debug.WriteLine("Client Result Sucess!!");
                var data = await result.Content.ReadAsStringAsync();
            }
        }
    }
}