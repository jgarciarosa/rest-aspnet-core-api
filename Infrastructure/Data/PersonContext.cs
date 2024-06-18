using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class PersonContext : DbContext
{
    public PersonContext(DbContextOptions options) : base(options) { }

    public DbSet<Person> Persons { get; set; }
}
