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
        public DbSet<Clothing> Clothing { get; set; }
        public DbSet<ClothingType> ClothingType { get; set; }
        public DbSet<Toy> Toy { get; set; }
        public DbSet<Misc> Misc { get; set; }
        public DbSet<ToyType> ToyType { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);



            modelBuilder.Entity<ClothingType>()
               .HasMany(c => c.Clothing)
               .WithOne(i => i.ClothingType)
               .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<ToyType>()
               .HasMany(it => it.Toys)
               .WithOne(i => i.ToyType)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Status>()
            .HasMany(s => s.Books)
            .WithOne(i => i.Status)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Status>()
           .HasMany(s => s.Toys)
           .WithOne(i => i.Status)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Status>()
           .HasMany(s => s.Clothing)
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



            modelBuilder.Entity<ClothingType>().HasData(
                new ClothingType()
                {
                    ClothingTypeId = 1,
                    Label = "Shirts"
                },
                new ClothingType()
                {
                    ClothingTypeId = 2,
                    Label = "Pants"
                },
                new ClothingType()
                {
                    ClothingTypeId = 3,
                    Label = "Shorts"
                },
                 new ClothingType()
                 {
                     ClothingTypeId = 4,
                     Label = "Socks"
                 },
                  new ClothingType()
                  {
                      ClothingTypeId = 5,
                      Label = "Sweaters"
                  },
                   new ClothingType()
                   {
                       ClothingTypeId = 6,
                       Label = "Shoes"
                   },
                    new ClothingType()
                    {
                        ClothingTypeId = 7,
                        Label = "Hats"
                    },
                     new ClothingType()
                     {
                         ClothingTypeId = 8,
                         Label = "Jackets"
                     },
                    new ClothingType()
                    {
                        ClothingTypeId = 9,
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


            modelBuilder.Entity<ToyType>().HasData(
               new ToyType()
               {
                   ToyTypeId = 1,
                   Label = "Cars and Trucks"
               },
               new ToyType()
               {
                   ToyTypeId = 2,
                   Label = "Games and Puzzles"
               },
               new ToyType()
               {
                   ToyTypeId = 3,
                   Label = "Slides and outdoor things"
               }



               );

            modelBuilder.Entity<Clothing>().HasData(
              new Clothing()
              {
                  ClothingId = 1,
                  UserId = user.Id,
                  Description = "",
                  Quantity = 50,
                  ClothingTypeId = 1,
                  StatusId = 1,

              },
               new Clothing()
               {
                   ClothingId = 2,
                   UserId = user.Id,
                   Description = "",
                   Quantity = 50,
                   ClothingTypeId = 1,
                   StatusId = 1,

               },
                new Clothing()
                {
                    ClothingId = 3,
                    UserId = user.Id,
                    Description = "",
                    Quantity = 50,
                    ClothingTypeId = 2,
                    StatusId = 1,

                }
 

              );

              modelBuilder.Entity<Book>().HasData(
             new Book()
             {
                 BookId = 1,
                 UserId = user.Id,
                 Quantity = 1,
                 Author = "Tag",
                 Title = "Me",
                 StatusId = 1,

             },

              new Book()
              {
                  BookId = 2,
                  UserId = user.Id,
                  Quantity = 1,
                  Author = "Tag",
                  Title = "Me",
                  StatusId = 1,

              },
               new Book()
               {
                   BookId = 3,
                   UserId = user.Id,
                   Quantity = 2,
                   Author = "Tag",
                   Title = "Me",
                   StatusId = 1,

               }

             );


            modelBuilder.Entity<Toy>().HasData(
            new Toy()
            {
                ToyId = 1,
                UserId = user.Id,
                Quantity = 1,
                Description = "",
                ToyTypeId = 1,
                StatusId = 1,

            },

             new Toy()
             {
                 ToyId = 2,
                 UserId = user.Id,
                 Quantity = 1,
                 Description = "",
                 ToyTypeId = 3,
                 StatusId = 1,

             },

              new Toy()
              {
                  ToyId = 3,
                  UserId = user.Id,
                  Quantity = 1,
                  Description = "",
                  ToyTypeId = 2,
                  StatusId = 1,

              }

              );



            modelBuilder.Entity<Misc>().HasData(
            new Misc()
            {
                MiscId = 1,
                UserId = user.Id,
                Quantity = 1,
                Description = "",
                StatusId = 1,

            }
            );


        }
    }
}
