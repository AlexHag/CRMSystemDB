using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Context;

namespace temp.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{

    public CustomerContext _context;
    public CustomerController(CustomerContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetAllCustomers")]
    public IEnumerable<Customer> Get()
    {
        var people = from c in _context.Customers.Take(10) select c;
        return people;
    }

    [Route("/create")]
    [HttpPost]
    public IActionResult Create(Customer inputCustomer)
    {
        //var person = new Customer{Name = Name, Email = Email, PhoneNumber = PhoneNumber};

        _context.Customers.Add(inputCustomer);
        _context.SaveChanges();
        //Console.WriteLine(Name);
        return Ok();
    }
}
