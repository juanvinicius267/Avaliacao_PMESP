using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Avaliação_PMESP.Models
{
    public class Tabela
    {
        [Key]
        public int ID { get; set; }
        public string NomeDoProduto { get; set; }
        public int Quantidade { get; set; }
        public double ValorUnit { get; set; }
        public DateTime DataEntrega { get; set; }
    }
}
