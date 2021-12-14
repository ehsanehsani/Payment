using Microsoft.EntityFrameworkCore;
using PaymentProject.Core.Interfaces;
using PaymentProject.Infrastructure;
using PaymentProject.Infrastructure.Data;
using PaymentProject.Infrastructure.Repositories;
using PaymentProject.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IPaymentRepository, PaymentRepository>();
builder.Services.AddTransient<IPaymentService, PaymentServices>();

//Add DbContext
var folder = Environment.SpecialFolder.LocalApplicationData;
var path = Environment.GetFolderPath(folder);
var dbPath = System.IO.Path.Join(path, "payment.db");

builder.Services.AddDbContext<PaymentDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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