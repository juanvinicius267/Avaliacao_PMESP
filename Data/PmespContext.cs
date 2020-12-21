using Avaliação_PMESP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avaliação_PMESP.Data
{
    public class PmespContext : DbContext
    {
        public PmespContext(DbContextOptions<PmespContext> options)
           : base(options)
        {
        }
        public DbSet<Tabela> tb_tabela { get; set; }
        
    }
}
