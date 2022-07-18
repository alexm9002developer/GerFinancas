using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerFinancas.Models;

namespace GerFinancas.Data
{
    public class GerFinancasContext : DbContext
    {
        public GerFinancasContext(DbContextOptions<GerFinancasContext> options) : base(options)
        {
        }
        public DbSet<Cartoes> Cartoes { get; set; }
        public DbSet<TipoLancamento> TipoLancamento { get; set; }
        public DbSet<FormatoLancamento> FormatoLancamento { get; set; }
        public DbSet<Lancamentos> Lancamentos { get; set; }
        public DbSet<UsuarioLogin> UsuarioLogin { get; set; }
    }
}
