// See https://aka.ms/new-console-template for more information   
using Client.Classes;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection services = new ();
IHttpClientBuilder httpClientBuilder = services.AddHttpClient("test", httpClient => { });
//{
//    httpClient.BaseAddress = new Uri("https://localhost");
//});

//  creating the HttpClient using the IHttpClientFactory,
//  and the settings are encapsulated within the TestRestClient itself. 
services.AddScoped<TestRestClient>(provider =>
{
    var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
    return new TestRestClient(httpClientFactory, "test");
});

var servicesProvider = services.BuildServiceProvider(validateScopes: true);
using (var scope = servicesProvider.CreateScope())
{
    var client = scope.ServiceProvider.GetRequiredService<TestRestClient>();

    // Test

    // Use the RestClient and its encapsulated HttpClient and HttpRequestManager
    var httpClient = client.HttpClient;
    var requestManager = client.RequestManager;

    // Now you can use httpClient for making requests and requestManager for managing requests.
    string url = "https://httpbin.org/";
    httpClient.BaseAddress = new Uri(url);
    var response = await httpClient.GetAsync("/get");
    Console.WriteLine(response);
    // You can use requestManager for any additional request management if needed.


}