using Client.Classes;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection services = new ();
IHttpClientBuilder httpClientBuilder = services.AddHttpClient("safemoney", httpClient => { });

//  create the HttpClient using the IHttpClientFactory,
//  the settings are encapsulated within the TestRestClient itself. 
services.AddScoped<InitClient>(provider =>
{
    var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
    return new InitClient(httpClientFactory, "safemoney");
});

var servicesProvider = services.BuildServiceProvider(validateScopes: true);
using (var scope = servicesProvider.CreateScope())
{
    var client = scope.ServiceProvider.GetRequiredService<InitClient>();

    // Test
    string baseAddress = "https://httpbin.org/";

    var smClient = client.CreateSafemoneyController(baseAddress);

    var response = await smClient.PayDelete("/get");

    Console.WriteLine(response.Content.ToString());

}