using Client.Classes;
using Client.Models.Safemoney.SMModels;
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
    string baseAddress = "http://192.168.34.212:7409/";
    string username = "pin";
    string password = "0000";

    var client = initClient.CreateSafemoneyController(baseAddress, username, password);

    SMPay payload = new()
    {
        ToBePaid = 10,
    };

    var response = await client.Pay(payload);

    Console.WriteLine(response.Content.Token);
}