using Microsoft.Extensions.DependencyInjection;
using UserAddressDbEf.Context;
using UserAddressDbEf.Models;
using Microsoft.EntityFrameworkCore;
using Bogus;

class Program
{

    public static void Main(string[] args)
    {
        using (var db = new CustomerContext())
        {
            var allCustomers = CreateFakes(50);

            foreach (var c in allCustomers)
            {
                db.Customers.Add(c);
            }

            db.SaveChanges();
        }
    }

    public static List<Customer> CreateFakes(int amount)
    {
        var fakeAddresses = new Faker<Address>()
            .RuleFor(p => p.StreetName, f => f.Address.StreetName())
            .RuleFor(p => p.StreetNo, f => f.Random.Number(1, 100))
            .RuleFor(p => p.City, f => f.Address.City())
            .RuleFor(p => p.Country, f => f.Address.Country());
        var allAddresses = fakeAddresses.Generate(amount);

        var index = 0;
        var fakeCustomers = new Faker<Customer>()
            .RuleFor(p => p.Name, f => f.Name.FirstName())
            .RuleFor(p => p.Email, (f, u) => f.Internet.Email(u.Name))
            .RuleFor(p => p.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(p => p.Addresses, f => new List<Address>{allAddresses[index++]});
        var allCustomers = fakeCustomers.Generate(amount);

        return allCustomers;
    }

    public static void AddNewCustomers(int amount)
    {
        using (var db = new CustomerContext())
        {
            var allCustomers = CreateFakes(amount);

            foreach (var c in allCustomers)
            {
                db.Customers.Add(c);
            }

            db.SaveChanges();
        }
    }

    public static void PrintCustomer()
    {
        using (var db = new CustomerContext())
        {
            var query = from c in db.Customers orderby c.Name select c;

            foreach (var c in query)
            {
                
            }
        }
    }
}