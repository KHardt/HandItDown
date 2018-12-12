using System;
using System.Collections.Generic;
using System.Text;
using HandItDown.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HandItDown.Data
{
    public class ApplicationDbContext : IdentityDbContext

    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)

        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}
