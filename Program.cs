using Microsoft.EntityFrameworkCore;
using WebAPIAssignment.DBContext;
using WebAPIAssignment.Repositories;
using WebAPIAssignment.RepositoryContracts;
using WebAPIAssignment.ServiceContracts;
using WebAPIAssignment.Services.OrderService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<OrderDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddScoped<IOrderAdderService,AddOrderService>();
builder.Services.AddScoped<IOrderDeleterService, DeleteOrderService>();
builder.Services.AddScoped<IOrderGetterService, GetOrderService>();
builder.Services.AddScoped<IOrderUpdateService, UpdateOrderService>();

builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<IOrderItemsRepository, OrderItemsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler("/Error");
app.UseHsts();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();