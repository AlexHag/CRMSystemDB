using UserAddressDbEf.Models;
using Microsoft.EntityFrameworkCore;

namespace UserAddressDbEf.Context;

public class CustomerContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
    {
        optionBuilder.UseSqlServer(@"Server=localhost, 1433;Database=CRMSystem;User Id=SA;Password=Password_2_Change_4_Real_Cases_&;TrustServerCertificate=true");
    }
}