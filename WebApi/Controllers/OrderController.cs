using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController:ControllerBase
{
    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("GetAllDatas")]
    public List<OrderDto> GetOrders()
    {
        return _orderService.GetOrders();
    }
    
    
    [HttpGet("GetOrdersByDate")]
    public List<OrderDto> GetOrdersByDate(DateTime date)
    {
        return _orderService.GetOrdersByDate(date);
    }
    
    [HttpGet("InsertTestData")]
    public void TestData()
    {
         _orderService.TestData();
    }
    
 }