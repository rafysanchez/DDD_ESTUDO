using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Config
{
    public class ContextBase : DbContext
    {

        public IConfigurationRoot Configuration { get; set; }

        public ContextBase(DbContextOptions<ContextBase> option) : base(option)
        {
            Database.EnsureCreated();
        }

        public DbSet<Produto> Produto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!optionBuilder.IsConfigured)
                optionBuilder.UseSqlServer(RetornaUrlConection());
        }

        public string RetornaUrlConection()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            string conexao = Configuration.GetConnectionString("DefaultConnection");
            return conexao;
        }


    }
}
