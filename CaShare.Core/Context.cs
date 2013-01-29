using CaShare.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using WebMatrix.WebData;


namespace CaShare.Core
{
    public class Context : DbContext
    {

        public Context(string connectionString)
            : base(connectionString)
        {
        }


        public DbSet<Instance> Instances { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(x => x.UserId)
                .Property(x => x.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //Make user have natural key
        }
    }

    public class ContextInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            base.Seed(context);
        }
    }

}
