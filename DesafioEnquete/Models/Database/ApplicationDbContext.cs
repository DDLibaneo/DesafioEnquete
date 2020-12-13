using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace DesafioEnquete.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Poll> Polls { get; set; }

        public DbSet<Option> Options { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
