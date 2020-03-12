using WhoLetDerHundOut.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WhoLetDerHundOut.DAL
{
    public class DogContext : DbContext
    {
        public DogContext() :base("DogContext")
        {

        }
        public DbSet<Dog>Dogs { get; set; }
        public DbSet<Users>User { get; set; }
        public DbSet<Breed>Breeds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        //public System.Data.Entity.DbSet<WhoLetDerHundOut.Models.>
    }
}