namespace webApiNetplan
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class netplanDBContext : DbContext
    {
        public netplanDBContext()
            : base("name=netplanDBContext")
        {
            base.Configuration.LazyLoadingEnabled = false;
            base.Configuration.ProxyCreationEnabled = false;

        }

        public virtual DbSet<correction> corrections { get; set; }
        public virtual DbSet<notify> notifies { get; set; }
        public virtual DbSet<requesttype> requesttypes { get; set; }
        public virtual DbSet<shiftrequest> shiftrequests { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<Shifttransfer> Shifttransfers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<workhourTemplate> workhourTemplates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<notify>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<requesttype>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<shiftrequest>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.salt)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<workhourTemplate>()
                .Property(e => e.name)
                .IsUnicode(false);
        }
    }
}
