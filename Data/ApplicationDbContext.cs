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
        public DbSet<Detail> Detail { get; set; }
        public DbSet<ItemDetail> ItemDetails { get; set; }
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

            modelBuilder.Entity<Item>().HasData(
              new Item()
              {
                  ItemId = 1,
                  UserId = user.Id,
                  Description = "goes vroom",
                  Name = "toy car",
                  Quantity = 50,

              },

              new Item()
              {
                  ItemId = 2,
                  UserId = user.Id,
                  Description = "goes vroom",
                  Name = "toy car",
                  Quantity = 5,

              },

              new Item()
              {
                  ItemId = 3,
                  UserId = user.Id,
                  Description = "goes vroom",
                  Name = "toy car",
                  Quantity = 10,

              }
              );


            modelBuilder.Entity<Detail>().HasData(
                new Detail()
                {
                    DetailId = 1,
                    Label = "Book",
                },

                new Detail()
                {
                    DetailId = 2,
                    Label = "MatchBoxCar",
                },

                 new Detail()
                 {
                     DetailId = 3,
                     Label = "Clothing",
                 }
                 );

            modelBuilder.Entity<ItemDetail>().HasData(
                  new ItemDetail()
                  {
                      ItemDetailId = 1,
                      ItemId = 1,
                      DetailId =1
                     
                  },

                new ItemDetail()
                {
                    ItemDetailId = 2,
                    ItemId = 1,
                    DetailId = 2
                },

                 new ItemDetail()
                 {
                     ItemDetailId = 3,
                     ItemId = 1,
                     DetailId = 3

                 }
                 );

            modelBuilder.Entity<WishList>().HasData(

                 new WishList()
                 {
                     WishListId = 1,
                     UserId = user.Id,
                     Description = "goes vroom",
                     Name = "toy car",
                     Quantity = 10,

                 },

                  new WishList()
                  {
                      WishListId = 2,
                      UserId = user.Id,
                      Description = "goes vroom",
                      Name = "toy car",
                      Quantity = 10,

                  },

                   new WishList()
                   {
                       WishListId = 3,
                       UserId = user.Id,
                       Description = "goes vroom",
                       Name = "Clothes",
                       Quantity = 2,

                   }






                 );
        }
    }
}
