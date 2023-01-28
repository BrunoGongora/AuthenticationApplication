using ApplicationCrudAndValidation.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCrudAndValidation.Context
{
    public class AppContextDb : DbContext
    {
        public AppContextDb(DbContextOptions<AppContextDb> options): base(options)
        {

        }
        
        public DbSet<MenuData> MenuData { get; set; } 
        public DbSet<Users> Users { get; set; }

    }
}
