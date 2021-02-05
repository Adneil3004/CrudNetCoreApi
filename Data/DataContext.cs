using Microsoft.EntityFrameworkCore;
using CrudApi.Models;

namespace CrudApi.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options){}

        public DbSet<Cliente> Clientes {get; set;}
    }
}