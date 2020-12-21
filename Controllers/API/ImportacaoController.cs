using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avaliação_PMESP.Dao;
using Avaliação_PMESP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Avaliação_PMESP.Controllers.API
{
   
    [ApiController]
    public class ImportacaoController : ControllerBase
    {
        private readonly TabelaDao _context;

        public ImportacaoController(TabelaDao context)
        {
            this._context = context;
        }
        // GET Importacao/GetImportacao/5        
        [HttpGet("{id}")]
        [Route("[controller]/GetImportacao/{id}")]
        public ActionResult GetImportacao(int id)
        {
            try
            {
                Tabela dados = _context.GetDadosPorId(id);
                if (dados == null)
                {
                    return NotFound();
                }
                return Ok(dados);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}