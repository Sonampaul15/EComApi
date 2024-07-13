using ApiAmazon.Models;
using ApiAmazon.Repository;
using ApiAmazon.Services;
using ApiAmazon.Utility;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AmazonDbContext>(Options=> Options.UseSqlServer(builder.Configuration.GetConnectionString("Amazon")));
builder.Services.Configure<JWTOptions>(builder.Configuration.GetSection("JWTSetting:JWTOptions"));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AmazonDbContext>().AddDefaultTokenProviders();
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICosmeticRepo, CosmeticService>();
builder.Services.AddScoped<IHomeFurnishingRepo,HomeFurnishingService>();
builder.Services.AddScoped<IBookRepo,BookService>();
builder.Services.AddScoped<IClothesRepo,ClothingService>();
builder.Services.AddScoped<IJwelleryRepo,JwelleryService>();
builder.Services.AddScoped<IKitchenRepo,KitchenService>();
builder.Services.AddScoped<IHomeDecorRepo,HomeDecoreService>();
builder.Services.AddScoped<IGroceryRepo,GroceryService>();
builder.Services.AddScoped<IElectronicsRepo, ElectronicService>();
builder.Services.AddScoped<IAuthRepository,AuthService>();
builder.Services.AddScoped<IJwtTokenGenerator,JwtTokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
