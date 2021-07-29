using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventOrganizer> EventOrganizers { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventType>(e =>
            {
                e.Property(t => t.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();
                e.Property(t => t.Type).IsRequired().HasMaxLength(100);
                
            });
            modelBuilder.Entity<EventOrganizer>(e =>
            {
                e.Property(o => o.Id).IsRequired().ValueGeneratedOnAdd();
                e.Property(o => o.Organizer).IsRequired().HasMaxLength(100);
            });
            modelBuilder.Entity<Event>(e =>
            {
                e.Property(ev => ev.Id).IsRequired().ValueGeneratedOnAdd();
                e.Property(ev => ev.Name).IsRequired().HasMaxLength(100);
                e.Property(ev => ev.Location).IsRequired().HasMaxLength(100);
                e.Property(ev => ev.Venue).IsRequired();
                e.Property(ev => ev.Price).IsRequired();
                e.Property(ev => ev.Date).IsRequired();
                e.HasOne(ev => ev.EventType).WithMany().HasForeignKey(ev => ev.EventTypeId);
                e.HasOne(ev => ev.EventOrganizer).WithMany().HasForeignKey(ev => ev.EventOrganizerId);
            });
        }
    }
}
