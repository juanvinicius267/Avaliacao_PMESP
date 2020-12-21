using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avaliação_PMESP.Models
{
    public class ValidadorModel
    {
        public int IdLinhaExcel { get; set; }
        public string CamposPreenchido { get; set; }
        public string TamanhoDescricao { get; set; }
        public string TamanhoQtd { get; set; }
        public string TamanhoValor { get; set; }
        public string TamanhoData { get; set; }
    }
}
