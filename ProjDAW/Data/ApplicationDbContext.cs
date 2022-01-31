using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjDAW.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjDAW.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<ForHome> ForHomes { get; set; }

    }
}
