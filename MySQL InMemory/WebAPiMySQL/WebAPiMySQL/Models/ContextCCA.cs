using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using Microsoft.EntityFrameworkCore;

namespace WebAPiMySQL.Models
{

    public class ContextCCA
         : DbContext
    {
            public ContextCCA(DbContextOptions options)
            : base(options)
        {
            
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ContextCCA>(builder => { builder.HasNoKey(); 
        //                                                 builder.ToTable("ContextCCA");
        //                                                });
        //}

        public DbSet<cca_user> Usuarios { get; set; }
    }
}
