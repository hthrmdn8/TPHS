using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using TPHS.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TPHS.Data
{
    public class AnimalDBContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Animal> Animals { get; set; }

        public DbSet<AnimalSpeciesType> AnimalTypes { get; set; } 

        public AnimalDBContext(DbContextOptions options)
            : base(options)
        { }
    }

}