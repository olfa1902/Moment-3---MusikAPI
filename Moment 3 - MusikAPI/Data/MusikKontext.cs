using Microsoft.EntityFrameworkCore;
using Moment_3___MusikAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moment_3___MusikAPI.Data
{
    public class MusikKontext : DbContext
    {
        public MusikKontext(DbContextOptions<MusikKontext> options) : base(options)
        {

        }

        public DbSet<Musik> musik { get; set; } 
    }
}
