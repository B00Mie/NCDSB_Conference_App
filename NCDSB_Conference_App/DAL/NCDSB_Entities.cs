using NCDSB_Conference_App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace NCDSB_Conference_App.DAL
{
    public class NCDSB_Entities : DbContext
    {
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Mileage> Mileages { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<ConferenceUser>().HasKey(cu => new { cu.ConferenceID, cu.UserID });
            modelBuilder.Entity<ConferenceUser>()
                .HasRequired(cu => cu.Conference)
                .WithMany(cu => cu.Users)
                .HasForeignKey(cu => cu.ConferenceID);

            modelBuilder.Entity<ConferenceUser>()
                .HasRequired(cu => cu.User)
                .WithMany(cu => cu.Conferences)
                .HasForeignKey(cu => cu.UserID);
        }
    }
}