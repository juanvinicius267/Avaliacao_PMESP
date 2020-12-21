using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avaliação_PMESP.Dao;
using Avaliação_PMESP.Helpers;
using Avaliação_PMESP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Avaliação_PMESP.Controllers.API
{
    
    public class TabelaController : Controller
    {
        private readonly TabelaDao _context;

        public TabelaController(TabelaDao context)
        {
            this._context = context;
        }
        // GET: api/Tabela
        [HttpGet]
        [Route("GetImportacoes")]
        public ActionResult GetImportacoes()
        {
            return Ok(_context.GetDados());
        }

        // POST api/Tabela
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Post(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("");
            }
            LeitorExcel leitor = new LeitorExcel();
            ExcelModel infos = await leitor.Leitor(file, _context);
            if (infos.ValidadorModel == null)
            {
                return Ok();
            }
            return BadRequest(infos.ValidadorModel);
        }

        // PUT api/Tabela/5
        [HttpPut("{id}")]
        [Route("api/[controller]")]
        public ActionResult Put(Tabela dados)
        {
            try
            {
                _context.UpdateDados(dados);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }

        // DELETE api/Tabela/5
        [HttpDelete("{id}")]
        [Route("api/[controller]")]
        public ActionResult Delete(int id)
        {
            try
            {
                _context.DeleteDados(id);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
            

        }
    }
}
