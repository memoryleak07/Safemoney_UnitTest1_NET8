using Client.Classes;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection services = new ();
IHttpClientBuilder httpClientBuilder = services.AddHttpClient("safemoney", httpClient => { });

services.AddScoped<InitClient>(provider =>
{
    var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
    return new InitClient(httpClientFactory, "safemoney");
});

ServiceProvider servicesProvider = services.BuildServiceProvider(validateScopes: true);

using (var scope = servicesProvider.CreateScope())
{
    var initClient = scope.ServiceProvider.GetRequiredService<InitClient>();

    // Test
    string baseAddress = "https://httpbin.org/";

    var client = initClient.CreateSafemoneyController(baseAddress);

    var response = await client.MyGetMethodAsync();

    Console.WriteLine(await response.Content.ReadAsStringAsync());
}