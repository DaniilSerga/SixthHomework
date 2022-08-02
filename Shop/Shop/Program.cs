using Shop.Models;
using Shop.BusinessLogic.Services.Contracts;
using Shop.BusinessLogic.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Shop.Common.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Database
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Services
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ISaleService, SaleService>();
#endregion

#region AutoMapper
var mappingConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion

var app = builder.Build();

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
