using Avaliação_PMESP.Data;
using Avaliação_PMESP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avaliação_PMESP.Dao
{
    public class TabelaDao
    {
        private readonly PmespContext _context;
        public TabelaDao(PmespContext context)
        {
            this._context = context;
        }

        public List<Tabela> GetDados()
        {
            return this._context.tb_tabela.OrderBy(e => e.ID).ToList();
        }

        public Tabela GetDadosPorId(int id)
        {
            return this._context.tb_tabela.Where(a => a.ID == id).OrderBy(e => e.ID).FirstOrDefault();
        }
        public void SetDados(List<Tabela> dados)
        {
            for (int i = 0; i < dados.Count; i++)
            {
                this._context.tb_tabela.Add(dados[i]);
                this._context.SaveChanges();
            }
            
        }
        public void UpdateDados(Tabela dados)
        {            
            this._context.tb_tabela.Update(dados);
            this._context.SaveChanges();
        }
        public void DeleteDados(int id)
        {
            this._context.tb_tabela.Remove(this._context.tb_tabela.Find(id));
            this._context.SaveChanges();
        }
    }
}
