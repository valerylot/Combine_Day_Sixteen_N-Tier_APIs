using Combine_Day_Sixteen_N_Tier_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace Combine_Day_Sixteen_N_Tier_APIs.Data
{
    //The DbContext is the connection to the database
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        //here we set our tables
        //each DbSet is one table

        public DbSet<Supply> Supplies{get; set;}
    }
}