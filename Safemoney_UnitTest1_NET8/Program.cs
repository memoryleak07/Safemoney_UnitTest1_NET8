using Client.Classes;
using Client.Controllers;
using Client.Interfaces;
using Client.Models.Safemoney.SMModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddScoped<ISafemoneyService, SafemoneyService>();
builder.Services.AddHttpClient("safemoney", (httpClient) =>
{
    string url = builder.Configuration.GetValue<string>("Safemoney:Url") ?? throw new KeyNotFoundException("Url not found");
    string username = builder.Configuration.GetValue<string>("Safemoney:Username") ?? throw new KeyNotFoundException("username not found");
    string password = builder.Configuration.GetValue<string>("Safemoney:Password") ?? throw new KeyNotFoundException("password not found");

    httpClient.BaseAddress = new Uri(url);
    // Add basic Baic Auth to httpClient RequestHeaders
    HttpUtility.AddHttpRequestHeaders(httpClient, username, password);

});

//Log4Net, NLog e Serilog

var app = builder.Build();

var client = app.Services.GetRequiredService<ISafemoneyService>();

SMPay payload = new()
{
    ToBePaid = 10,
};

var response = await client.Pay(payload);

Console.WriteLine(response.Content.Token);

//app.Run();