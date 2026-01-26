var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCors", policy =>
    {
        policy
            .WithOrigins("http://localhost:8100")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
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
