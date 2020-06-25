using System.Data.Entity;

namespace Laba8
{
    class DatabaseInit : DropCreateDatabaseIfModelChanges<EntityContext>
    {
        protected override void Seed(EntityContext context)
        {
            context.Cars.AddRange(new Car[] {
                new Car()
                {
                    Brand = "Ford",
                    Model = "Focus",
                    Year = 1998,
                    Color = "gray"
                },
                 new Car()
                {
                    Brand = "Audi",
                    Model = "Q7",
                    Year = 2010,
                    Color = "black"
                },
                  new Car()
                {
                    Brand = "Ferrari",
                    Model = "488",
                    Year = 2018,
                    Color = "red"
                }
            });
        }
    }
}
