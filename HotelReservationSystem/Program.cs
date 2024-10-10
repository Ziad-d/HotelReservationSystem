using Autofac.Extensions.DependencyInjection;
using Autofac;
using ExaminationSystem;
using HotelReservationSystem.Profiles;
using AutoMapper;
using ExaminationSystem.Helpers;
using ExaminationSystem.Middlewares;
using HotelReservationSystem.Repositories.UnitOfWork;
using HotelReservationSystem.Data;
using Microsoft.EntityFrameworkCore;
using HotelReservationSystem.Repositories;

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
builder.Services.AddAutoMapper(typeof(FacilityProfile));
builder.Services.AddAutoMapper(typeof(ReservationProfile));

var app = builder.Build();

MapperHelper.Mapper = app.Services.GetService<IMapper>();

app.UseMiddleware<GlobalErrorHandlerMiddleware>();
app.UseMiddleware<TransactionMiddleware>();

#region Apply All Pending Migrations[Update-Database] and Data Seeding
using var scoped = app.Services.CreateScope();
var services = scoped.ServiceProvider;
var _dbcontext = services.GetRequiredService<Context>();
var loggerFactory = services.GetRequiredService<ILoggerFactory>();
var _unitOfWork = services.GetRequiredService<IUnitOfWork>();
try
{
    await _dbcontext.Database.MigrateAsync();
    await ContextSeed.SeedRolesAsync(_unitOfWork, builder.Configuration);
}
catch (Exception ex)
{
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex, "an error has been occured during apply the migration");
}
#endregion
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
