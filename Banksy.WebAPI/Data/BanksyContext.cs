using Banksy.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banksy.WebAPI.Data
{
    public class BanksyContext : DbContext
    {
        public DbSet<Mutation> Mutations { get; set; }

        public BanksyContext() : this(new DbContextOptions<BanksyContext>()) { }

        public BanksyContext(DbContextOptions<BanksyContext> options) : base(options) { }
    }
}
