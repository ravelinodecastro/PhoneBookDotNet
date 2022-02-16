using Microsoft.EntityFrameworkCore;
using PhoneBookDotNet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookDotNet
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option) : base(option)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            ModelConfig(mb);
        }
        private void ModelConfig(ModelBuilder modelBuilder)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
