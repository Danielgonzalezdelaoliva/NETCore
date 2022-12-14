using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailVerification.Data
{
    //DbContext: representa una estancia de la bade datos declarada
    //IdentityDbContext: contexto predefinido para gestiona BD de tipo identidad

    public class AppDBContext :  IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) 
            : base(options)
        {

        }
    }
}
