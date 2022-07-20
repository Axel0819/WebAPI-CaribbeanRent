using AutoMapper;
using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

var myCors = "_myAllowOrigins";
var azureKeys = builder.Configuration.GetConnectionString("azureStorageKeys");
BlobServiceClient blobService=new BlobServiceClient(azureKeys);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//BD Service
builder.Services.AddDbContext<caribbeanrentContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("caribbeanrentContext"));
});

builder.Services.AddTransient<BlobServiceClient>(x => blobService);
builder.Services.AddTransient<ServiceStorageBlobs>();

// mapper
IMapper mapper = WebAPI.MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myCors,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                          .AllowAnyHeader().AllowAnyMethod();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(myCors);

app.UseAuthorization();

app.MapControllers();

app.Run();
