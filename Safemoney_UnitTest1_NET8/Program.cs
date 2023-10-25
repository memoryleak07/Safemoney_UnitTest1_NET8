using Client.Classes;
using Client.Controllers;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

ServiceCollection services = new ();
IHttpClientBuilder httpClientBuilder = services.AddHttpClient("safemoney", httpClient => { });

// Create the HttpClient using the IHttpClientFactory,
// encapsulate settings within the TestRestClient itself.
services.AddScoped<InitClient>(provider =>
{
    var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
    return new InitClient(httpClientFactory, "safemoney");
});

var servicesProvider = services.BuildServiceProvider(validateScopes: true);

using (var scope = servicesProvider.CreateScope())
{
    var client = scope.ServiceProvider.GetRequiredService<SafemoneyController>();

    // Test
    string baseAddress = "https://httpbin.org/";


    var response = await client.Reboot();

    Console.WriteLine(response.Content.ToString());
}
