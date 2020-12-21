using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avaliação_PMESP.Models
{
    public class ExcelModel
    {
        public List<Tabela> DadosTabela { get; set; }
        public List<ValidadorModel> ValidadorModel { get; set; }
    }
}
