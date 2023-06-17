using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazorCrud.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
                 : base(options)
        {

        }

        public DbSet<Person> Person { get; set; }
    }
}
