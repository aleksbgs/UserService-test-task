using Asp.Versioning;
using UserService.API.Extensions;
using UserService.Application.Extensions;
using UserService.Infrastructure.Data;
using UserService.InfraStructure.Data;
using UserService.InfraStructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Add Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});


builder.Services.AddControllers();
// Add API Versioning
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});

//Application Services
builder.Services.AddApplicationServices();

//Infra services
builder.Services.AddInfraServices(builder.Configuration);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "UserService.API", Version = "v1" }); });

var app = builder.Build();


//Apply db migration
app.MigrateDatabase<UserContext>((context, services) =>
{
    var logger = services.GetService<ILogger<UserContextSeed>>();
    UserContextSeed.SeedAsync(context, logger).Wait();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();