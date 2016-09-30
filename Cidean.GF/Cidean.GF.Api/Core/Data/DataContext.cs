namespace Cidean.GF.Api.Core.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Cidean.GF.Api.Core.Domain;
    using System.Data.Entity.ModelConfiguration;


    public class BusinessesConfiguration : EntityTypeConfiguration<Business>
    {
        public BusinessesConfiguration()
        {

            HasKey(p => p.Id);

            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(p => p.Name);

            ToTable("Business");

        }
    }

  
    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<Business> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BusinessesConfiguration());
            base.OnModelCreating(modelBuilder);
            
        }
    }
}
