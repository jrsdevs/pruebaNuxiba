using Microsoft.EntityFrameworkCore;
using nuxibaService.Model;
using System;

namespace nuxibaService.Contexto
{
    public class NuxibaContext : DbContext
    {
        public NuxibaContext(DbContextOptions<NuxibaContext> options) : base(options)
        {
        }

        public DbSet<Ccloglogin> ccloglogins { get; set; }
        public DbSet<Login> login { get; set; }
        public DbSet<CcUsers> users { get; set; }

    }
}
