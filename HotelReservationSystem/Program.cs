using Autofac.Extensions.DependencyInjection;
using Autofac;
using ExaminationSystem;
using HotelReservationSystem.Profiles;
using AutoMapper;
using ExaminationSystem.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
    builder.RegisterModule(new AutofacModule()));

builder.Services.AddAutoMapper(typeof(RoomProfile));

var app = builder.Build();

MapperHelper.Mapper = app.Services.GetService<IMapper>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
