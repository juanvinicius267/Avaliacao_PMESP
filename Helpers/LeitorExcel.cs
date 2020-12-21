using Avaliação_PMESP.Dao;
using Avaliação_PMESP.Models;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Avaliação_PMESP.Helpers
{
    public class LeitorExcel
    {
        public async Task<ExcelModel> Leitor(IFormFile file, TabelaDao _context)
        {
            List<Tabela> dados = new List<Tabela>();
            
            List<ValidadorModel> validadorModel = new List<ValidadorModel>();
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream).ConfigureAwait(false);

                using (var package = new ExcelPackage(memoryStream))
                {
                    for (int i = 1; i <= package.Workbook.Worksheets.Count; i++)
                    {
                        var totalRows = package.Workbook.Worksheets[i].Dimension?.Rows;
                        var totalCollumns = package.Workbook.Worksheets[i].Dimension?.Columns;
                        for (int j = 2; j <= totalRows.Value; j++)
                        {
                            Tabela infos = new Tabela();
                            Validador validador = new Validador();
                            ValidadorModel erros = new ValidadorModel();


                            ValidadorDataEntrega validadorDataEntrega = validador.VerificaData(package.Workbook.Worksheets[i].Cells[j, 1].Value, j);
                            
                            if (validadorDataEntrega.Status.Contains("Ok"))
                            {
                                infos.DataEntrega = validadorDataEntrega.DataEntrega;
                            }
                            else
                            {
                                erros.IdLinhaExcel = j;
                                erros.TamanhoData = validadorDataEntrega.Status;
                            }
                            ValidadorNomeProduto validadorNomeProduto = validador.VerificaDescricao(package.Workbook.Worksheets[i].Cells[j, 2].Value, j); ;

                            if (validadorNomeProduto.Status.Contains("Ok"))
                            {
                                infos.NomeDoProduto = validadorNomeProduto.NomeProduto;
                            }
                            else
                            {
                                erros.IdLinhaExcel = j;
                                erros.TamanhoDescricao = validadorNomeProduto.Status;
                            }
                            ValidadorQuantidade validadorQuantidade = validador.VerificaQtd(package.Workbook.Worksheets[i].Cells[j, 3].Value, j); ;

                            if (validadorQuantidade.Status.Contains("Ok"))
                            {
                                infos.Quantidade = validadorQuantidade.Quantidade;
                            }
                            else
                            {
                                erros.IdLinhaExcel = j;
                                erros.TamanhoQtd = validadorQuantidade.Status;
                            }

                            ValidadorValor validadorValor = validador.VerificaValor(package.Workbook.Worksheets[i].Cells[j, 4].Value, j); ;

                            if (validadorValor.Status.Contains("Ok"))
                            {
                                infos.ValorUnit = validadorValor.ValorUnit;
                            }
                            else
                            {
                                erros.IdLinhaExcel = j;
                                erros.TamanhoValor = validadorValor.Status;
                            }
                           
                            dados.Add(infos);
                            if (erros.IdLinhaExcel != 0)
                            {
                                validadorModel.Add(erros);
                            }
                            
                        }
                    }
                }
            }
            ExcelModel retorno = new ExcelModel();
            retorno.DadosTabela = dados;
            
            if (validadorModel.Capacity == 0)
            {
                _context.SetDados(dados);
            }
            else
            {
                retorno.ValidadorModel = validadorModel;
            }
           
            return retorno;
        }
    }
}
