using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CEntidades;

namespace WebApiElipgo.Data
{
    public class WebApiElipgoContext : DbContext
    {
        public WebApiElipgoContext (DbContextOptions<WebApiElipgoContext> options)
            : base(options)
        {
        }

        public DbSet<CEntidades.Contacto> Contacto { get; set; }
    }
}
