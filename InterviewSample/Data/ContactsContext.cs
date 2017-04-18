using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewSample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InterviewSample.Data
{
    public class ContactsContext : DbContext
    {

        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Addresses> Addresses { get; set; }
      //  public DbSet<ContactToAddress> ContactToAddress { get; set; }


        public ContactsContext(DbContextOptions<ContactsContext> options) : base(options)
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contacts>().ToTable("Contact");
            modelBuilder.Entity<Addresses>().ToTable("Address");
            //   modelBuilder.Entity<ContactToAddress>().ToTable("ContactToAddress");

           // modelBuilder.Entity<Contacts>().HasMany(d => d.Addresses).WithOne(dk => dk.Contact).OnDelete(DeleteBehavior.Cascade);// .WillCascadeOnDelete(false);
            //   var ent = modelBuilder.Entity("DateTime");
            // ent.Property<Contacts>("BirthDate");

            //    ent.HasBaseType("datetime2");

            // modelBuilder.Property("BirthDate").
            //      .Configure(c => c.HasColumnType("datetime2"));
            //   base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //builder.Entity<Contacts>()
            //.HasMany(t => t.Addresses)
            //.
            ////.WithMany(t => t.Contact)
            //.Map(m =>
            //{
            //    m.ToTable("CourseInstructor");
            //    m.MapLeftKey("CourseID");
            //    m.MapRightKey("InstructorID");
            //});
        }
    }
}
