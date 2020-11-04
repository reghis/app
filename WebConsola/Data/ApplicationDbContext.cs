using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CEntidades;

namespace WebConsola.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CEntidades.stores> stores { get; set; }
        public DbSet<CEntidades.articles> articles { get; set; }
        public DbSet<CEntidades.Contacto> Contacto { get; set; }
    }
}
