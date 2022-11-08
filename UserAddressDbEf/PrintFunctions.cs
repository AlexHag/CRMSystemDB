using UserAddressDbEf.Context;
using UserAddressDbEf.Models;
using Bogus;

namespace UserAddressDbEf;

public class PrintFunctions
{
    private static List<Customer> CreateFakes(int amount)
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

    public void AddNewCustomers(int amount)
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
    
    public void PrintCustomerName()
    {
        using (var db = new CustomerContext())
        {
            var query = from c in db.Customers orderby c.Name select c;
            
            Console.WriteLine("Name:".PadRight(16) + "Email:".PadRight(41) + "Phone Number:".PadRight(26) + "Id:");
            foreach (var c in query)
            {
                Console.WriteLine($"{c.Name.PadRight(15)} {c.Email.PadRight(40)} {c.PhoneNumber.PadRight(25)} {c.Id}");
            }
        }
    }
    
    public void PrintCustomerAndAddress()
    {
        using (var db = new CustomerContext())
        {
            var person = (from p in db.Customers
                join e in db.Addresses
                    on p.Id equals e.Id
                select new { 
                    Name = p.Name, 
                    Email = p.Email, 
                    PhoneNumber = p.PhoneNumber, 
                    StreetName = e.StreetName,
                    StreetNo = e.StreetNo,
                    City = e.City,
                    Country = e.Country
                }).ToList();

            Console.WriteLine("Name:".PadRight(16) + "Email:".PadRight(36) + "Phone Number:".PadRight(26) + "Street Name:".PadRight(26) + "Street Number:".PadRight(20) + "City:".PadRight(26) + "Country:".PadRight(21));
            
            foreach (var c in person)
            {
                Console.WriteLine(@$"{c.Name.PadRight(15)} {c.Email.PadRight(35)} {c.PhoneNumber.PadRight(25)} {c.StreetName.PadRight(25)} {c.StreetNo.ToString().PadRight(20)} {c.City.PadRight(25)} {c.Country.PadRight(20)}");
            }
        }
    }

    public void PrintCustomerNameFilter(string filter)
    {
        using (var db = new CustomerContext())
        {
            var query = from c in db.Customers where c.Name.StartsWith(filter) orderby c.Name select c;
            
            Console.WriteLine("Name:".PadRight(16) + "Email:".PadRight(36) + "Phone Number:".PadRight(26) + "Id:");
            foreach (var c in query)
            {
                Console.WriteLine($"{c.Name.PadRight(15)} {c.Email.PadRight(35)} {c.PhoneNumber.PadRight(25)} {c.Id}");
            }
        }
    }

    public void PrintCustomerNameAndAddressFilter(string filter)
    {
        using (var db = new CustomerContext())
        {
            var person = (from p in db.Customers
                join e in db.Addresses
                    on p.Id equals e.Id
                where p.Name.StartsWith(filter)
                select new { 
                    Name = p.Name, 
                    Email = p.Email, 
                    PhoneNumber = p.PhoneNumber, 
                    StreetName = e.StreetName,
                    StreetNo = e.StreetNo,
                    City = e.City,
                    Country = e.Country
                }).ToList();

            Console.WriteLine("Name:".PadRight(16) + "Email:".PadRight(36) + "Phone Number:".PadRight(26) + "Street Name:".PadRight(26) + "Street Number:".PadRight(20) + "City:".PadRight(26) + "Country:".PadRight(21));
            
            foreach (var c in person)
            {
                Console.WriteLine(@$"{c.Name.PadRight(15)} {c.Email.PadRight(35)} {c.PhoneNumber.PadRight(25)} {c.StreetName.PadRight(25)} {c.StreetNo.ToString().PadRight(20)} {c.City.PadRight(25)} {c.Country.PadRight(20)}");
            }
        }
    }
    
    public void PrintCustomerNameById(int id)
    {
        using (var db = new CustomerContext())
        {
            var query = from c in db.Customers where c.Id == id orderby c.Name select c;
            
            Console.WriteLine("Name:".PadRight(16) + "Email:".PadRight(36) + "Phone Number:".PadRight(26) + "Id:");
            foreach (var c in query)
            {
                Console.WriteLine($"{c.Name.PadRight(15)} {c.Email.PadRight(35)} {c.PhoneNumber.PadRight(25)} {c.Id}");
            }
        }
    }
    
    public void PrintCustomerNameAndAddressById(int id)
    {
        using (var db = new CustomerContext())
        {
            var person = (from p in db.Customers
                join e in db.Addresses
                    on p.Id equals e.Id
                where p.Id == id
                select new { 
                    Name = p.Name, 
                    Email = p.Email, 
                    PhoneNumber = p.PhoneNumber, 
                    StreetName = e.StreetName,
                    StreetNo = e.StreetNo,
                    City = e.City,
                    Country = e.Country
                }).ToList();

            Console.WriteLine("Name:".PadRight(16) + "Email:".PadRight(36) + "Phone Number:".PadRight(26) + "Street Name:".PadRight(26) + "Street Number:".PadRight(20) + "City:".PadRight(26) + "Country:".PadRight(21));
            
            foreach (var c in person)
            {
                Console.WriteLine(@$"{c.Name.PadRight(15)} {c.Email.PadRight(35)} {c.PhoneNumber.PadRight(25)} {c.StreetName.PadRight(25)} {c.StreetNo.ToString().PadRight(20)} {c.City.PadRight(25)} {c.Country.PadRight(20)}");
            }
        }
    }
}