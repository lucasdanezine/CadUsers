using CadUsers.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace CadUsers.Repository.Context
{
    public class SysCadContext : DbContext
    {
        public SysCadContext(DbContextOptions options) : base(options) 
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Contact>  Contacts { get; set; }
    }
}
