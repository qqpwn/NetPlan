namespace ProjectWebAPI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBcontextNetplan : DbContext
    {
        public DBcontextNetplan()
            : base("name=DBcontextNetplan")
        {
            base.Configuration.LazyLoadingEnabled = false;
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<notify> notify { get; set; }
        public virtual DbSet<requesttype> requesttype { get; set; }
        public virtual DbSet<shiftrequests> shiftrequests { get; set; }
        public virtual DbSet<Shifts> Shifts { get; set; }
        public virtual DbSet<Shifttransfers> Shifttransfers { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<workhourTemplate> workhourTemplate { get; set; }
        public virtual DbSet<corrections> corrections { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<notify>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<requesttype>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<shiftrequests>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.salt)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<workhourTemplate>()
                .Property(e => e.name)
                .IsUnicode(false);
        }
    }
}
