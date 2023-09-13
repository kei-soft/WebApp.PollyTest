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
            // Polly 재시도 및 SSL 무시 동시 처리
            //var retryPolicy = HttpPolicyExtensions
            //                    .HandleTransientHttpError()
            //                    .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            //var sslOptions = new SslClientAuthenticationOptions
            //{
            //    RemoteCertificateValidationCallback = delegate { return true; },
            //};

            //var socketHandler = new SocketsHttpHandler { PooledConnectionLifetime = TimeSpan.FromMinutes(15), SslOptions = sslOptions };
            //var pollyHandler = new PolicyHttpMessageHandler(retryPolicy)
            //{
            //    InnerHandler = socketHandler,
            //};
            //var httpClient = new HttpClient(socketHandler);

            // ▼▼ SSL 무시 ▼▼

            // ● SocketsHttpHandler
            //var sslOptions = new SslClientAuthenticationOptions
            //{
            //    RemoteCertificateValidationCallback = delegate { return true; },
            //};
            //var handler = new SocketsHttpHandler { PooledConnectionLifetime = TimeSpan.FromMinutes(15), SslOptions = sslOptions };

            // ● HttpClientHandler
            //var handler = new HttpClientHandler();
            //handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            //handler.ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true;

            //var httpClient = new HttpClient(handler);
            //httpClient.BaseAddress = new Uri("https://localhost:7018/WeatherForecast/");

            // ▲▲ SSL 무시 ▲▲

            // 선언된 Client 가져오기
            var httpClient = factory.CreateClient("apiClient");

            // API 호출
            var result = await httpClient.GetAsync("GetWeatherForecastData");

            if (result.IsSuccessStatusCode)
            {
                Debug.WriteLine("Client Result Sucess!!");
                var data = await result.Content.ReadAsStringAsync();
            }
        }
    }
}