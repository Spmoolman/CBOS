using Microsoft.EntityFrameworkCore;

namespace CBOS.DataModels
{    
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contact { get; set; }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {            
            base.OnModelCreating(builder);
            //builder.Seed();
        }
    }
}