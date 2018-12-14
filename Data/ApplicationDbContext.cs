using System;
using System.Collections.Generic;
using System.Text;
using HandItDown.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HandItDown.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<WishList> WishLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            modelBuilder.Entity<Item>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<WishList>()
              .Property(b => b.DateCreated)
              .HasDefaultValueSql("GETDATE()");


            modelBuilder.Entity<ItemType>()
               .HasMany(it => it.Items)
               .WithOne(i => i.ItemType)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Status>()
            .HasMany(s => s.Items)
            .WithOne(i => i.Status)
            .OnDelete(DeleteBehavior.Restrict);

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "admin",
                LastName = "admin",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

           

            modelBuilder.Entity<ItemType>().HasData(
                new ItemType()
                {
                    ItemTypeId = 1,
                    Label = "Toys"
                },
                new ItemType()
                {
                    ItemTypeId = 2,
                    Label = "Books"
                },
                new ItemType()
                {
                    ItemTypeId = 3,
                    Label = "Clothes"
                },
                 new ItemType()
                 {
                     ItemTypeId = 4,
                     Label = "Misc"
                 }
                );

            modelBuilder.Entity<Status>().HasData(
                   new Status()
                {
                    StatusId = 1,
                    Label = "Has"
                },
                new Status()
                {
                    StatusId = 2,
                    Label = "Needs"
                },
                 new Status()
                 {
                     StatusId = 3,
                     Label = "Donatable"
                 }

                );

            modelBuilder.Entity<Item>().HasData(
             new Item()
             {
                 ItemId = 1,
                 UserId = user.Id,
                 Description = "goes vroom",
                 Name = "toy car",
                 Quantity = 50,
                 ItemTypeId = 1,
                 StatusId = 1,

             },

             new Item()
             {
                 ItemId = 2,
                 UserId = user.Id,
                 Description = "goes vroom",
                 Name = "toy car",
                 Quantity = 5,
                 ItemTypeId = 2,
                 StatusId = 1,

             },

             new Item()
             {
                 ItemId = 3,
                 UserId = user.Id,
                 Description = "goes vroom",
                 Name = "toy car",
                 ItemTypeId = 3,
                 Quantity = 10,
                 StatusId = 1,

             }
             );





        }
    }
}
