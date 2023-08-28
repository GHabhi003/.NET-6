using Microsoft.EntityFrameworkCore;
using WebAPIAssignment.Entities;

namespace WebAPIAssignment.DBContext
{
    public class OrderDbContext: DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        
        public OrderDbContext()
        {

        }
        public OrderDbContext(DbContextOptions<OrderDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderItem>().ToTable("OrderItem");

            modelBuilder.Entity<Order>().HasData(new Order[] { new Order { OrderId = Guid.Parse("5D5C9AAA-C3CD-4A06-A631-19A4AE558459"), OrderNumber = "ORDER_2023_1", CustomerName = "Abhishek", OrderDate = DateTime.Parse("2023-08-19"), TotalAmount = 1000 }, new Order { OrderId = Guid.Parse("ADE6E76F-51D7-4D9B-BDEE-2BE594F6A26E"), OrderNumber = "ORDER_2023_2", CustomerName = "Sahil", OrderDate = DateTime.Parse("2023-08-20"), TotalAmount = 2000 } 
            });

            modelBuilder.Entity<OrderItem>().HasData(new OrderItem[] { new OrderItem { OrderItemId = Guid.NewGuid(), OrderId = Guid.Parse("5D5C9AAA-C3CD-4A06-A631-19A4AE558459"), ProductName = "ITC Shampoo", Quantity = 2, UnitPrice = 500, TotalPrice = 1000 }, new OrderItem { OrderItemId = Guid.NewGuid(), OrderId = Guid.Parse("ADE6E76F-51D7-4D9B-BDEE-2BE594F6A26E"), ProductName = "Hair Dryer", Quantity = 1, UnitPrice = 1000, TotalPrice = 1000 }, new OrderItem { OrderItemId = Guid.NewGuid(), OrderId = Guid.Parse("ADE6E76F-51D7-4D9B-BDEE-2BE594F6A26E"), ProductName = "Soap", Quantity = 10, UnitPrice = 100, TotalPrice = 1000 }
            });

        }
    }
}
