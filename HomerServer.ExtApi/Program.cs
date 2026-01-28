using HomerServer.ExtApi.models;
using Microsoft.AspNetCore.Mvc;
using HomerServer.ExtApi.Clients;
using HomeServer.ExtApi.Models;
using HomeServer.ExtApi.Models.Config;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
// builder.Services.AddControllers();
builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = true;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCors", policy =>
    {
        policy
        .AllowAnyOrigin()
            // .WithOrigins("http://localhost:8100," +
            //             "http://coolserver.oryx-cirius.ts.net," +
            //             "huaweiserver.oryx-cirius.ts.net" +
            //             "iphone-15-pro.oryx-cirius.ts.net")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});


builder.Services.AddSingleton<NetdataClient>(sp =>
{
    var config = builder.Configuration.GetSection("Netdata").Get<NetdataOptions>();
    var client = new NetdataClient(new HttpClient());
    client.Configure(config!.BaseUrl, config.BearerToken, config.XAuthToken);
    return client;
});

var app = builder.Build();

// 🔴 ORDER MATTERS
app.UseCors("DevCors");        // ✅ MUST be here
app.UseHttpsRedirection();

app.MapControllers();

// Swagger can be anywhere after Build()
app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
