using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Payme.Data.DbContexts;
using Payme.Data.IRepositories;
using Payme.Data.Repositories;
using Payme.Service.Mappers;
using Payme.Service.Services.CardServices;
using Payme.Service.Services.PaymentCategoryServices;
using Payme.Service.Services.PaymentServices;
using Payme.Service.Services.TransactionServices;
using Payme.Service.Services.UserPaymentServices;
using Payme.Service.Services.UserServices;
using Payme.WebApi.MiddleWares;
using Payme.WebApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(builder.Configuration);
builder.Services.AddSingleton<DataSession>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<IPaymentCategoryRepository, PaymentCategoryRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IUserPaymentRepository, UserPaymentRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<IPaymentCategoryService, PaymentCategoryService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IUserPaymentService, UserPaymentService>();

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new RouteTokenTransformerConvention(
                                      new ConfigurationApiUrlName()));
});

var app = builder.Build();
{
    using var scope = app.Services.CreateScope();
    var dataSession = scope.ServiceProvider.GetRequiredService<DataSession>();
    await dataSession.Init();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleWare>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
