using System;
using Microsoft.EntityFrameworkCore;
using Entity;

namespace Data
{
    public class PulsationsContext: DbContext
    {
        public PulsationsContext(DbContextOptions options) : base(options) { }
        public DbSet<Person> Persons { get; set; }
    }
}
