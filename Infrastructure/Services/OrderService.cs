using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class OrderService
{
    private readonly DataContext _context;

    public OrderService(DataContext context)
    {
        _context = context;
    }

    public List<OrderDto> GetOrders()
    {
        return _context.Orders.Select(x => new OrderDto()
        {
            Address = x.Customer.Address,
            Id = x.Id,
            OrderDate = x.OrderPlaced,
            CustomerId = x.CustomerId,
            FullName = string.Concat(x.Customer.FirstName, " ", x.Customer.LastName),
            ProductName = x.OrderDetail.Product.Name
        }).ToList();
    }
    
    public List<OrderDto> GetOrdersByDate(DateTime date)
    {
        
        return _context.Orders
            .Where(x=>x.OrderPlaced.Date == date.Date)
            .Select(x => new OrderDto()
        {
            Address = x.Customer.Address,
            Id = x.Id,
            OrderDate = x.OrderPlaced,
            CustomerId = x.CustomerId,
            FullName = string.Concat(x.Customer.FirstName, " ", x.Customer.LastName),
            ProductName = x.OrderDetail.Product.Name
        }).ToList();
    }

    public void TestData()
    {
        _context.Orders.Add(new Order()
        {
            CustomerId = 1,
            OrderPlaced = DateTime.UtcNow,
            Customer = new Customer()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Main St",
                Email = "test",
                City = "New York",
            },
            OrderDetail = new OrderDetail()
            {
                ProductId = 1,
                Quantity = 1,
                Product = new Product()
                {
                    Id = 1,
                    Name = "Product 1"
                },
                OrderId = 1
            }
        });

        _context.SaveChanges();
    }
}