using System.Data.Entity;

namespace Laba8
{
    class EntityContext : DbContext
    {
        public EntityContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Database.SetInitializer(new DatabaseInit());
        }

        public DbSet<Car> Cars { get; set; }
    }
}
