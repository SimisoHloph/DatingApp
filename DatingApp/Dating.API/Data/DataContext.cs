using Dating.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Dating.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options){

        }
     // value is the model class and will be a table in the Databases
        public DbSet<Value> Values{get;set;}
        public DbSet<User> Users{get; set;}
        public DbSet<Photo> Photos { get; set; }
        
    }
}