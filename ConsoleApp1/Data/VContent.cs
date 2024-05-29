using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Minden;

namespace Database.Data
{
    public class VContent : DbContext
    {
        public DbSet<Emberek> Emberek { get; set; }
        public string ConnectionString { get; set; }

        public VContent()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MsSqlLocalDb;Database=Oliver;Trusted_Connection=true");
        }
    }
}