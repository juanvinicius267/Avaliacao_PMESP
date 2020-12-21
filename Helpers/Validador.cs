using Avaliação_PMESP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avaliação_PMESP.Helpers
{
    public class Validador
    {
        private readonly ValidadorModel _validador;
        public Validador()
        {             
            this._validador = new ValidadorModel(); ;
        }
        
    
        public bool CamposPreenchidos(Tabela dados)
        {
            bool nomeProduto = String.IsNullOrEmpty(dados.NomeDoProduto);
            bool qtdProdutos = !(dados.Quantidade == 0 || dados.Quantidade == null);
            bool valorUnit = !(dados.ValorUnit == 0 || dados.ValorUnit == null);
            bool dataEntrega = !(dados.DataEntrega == null || dados.DataEntrega == DateTime.Now);

            if (nomeProduto == true &&
                qtdProdutos == true &&
                valorUnit == true &&
                dataEntrega == true)
            {
                return true;
            }
            else
            {                
                return false;
            }
            
        }
        public ValidadorNomeProduto VerificaDescricao(object _info, int linha)
        {
            ValidadorNomeProduto validador = new ValidadorNomeProduto();
            string _data;
            try
            {
                _data = Convert.ToString(_info);
                if (String.IsNullOrEmpty(_data))
                {
                    validador.Status = "O Campo de Descrição esta vazio. Linha do Erro: " + linha.ToString();
                    return validador;
                }
                else if (_data.Length >= 50)
                {
                    validador.Status = "O Campo de Descrição Tem mais de 50 caracteres. Linha do Erro: " + linha.ToString();
                    return validador;
                }
                else if (_data.Length <= 50)
                {
                    validador.Status = "Ok";
                    validador.NomeProduto = _data;
                    return validador;
                }
                return validador;
                
            }
            catch (Exception e)
            {
                validador.Status = "O Campo de Descrição esta vazio. Linha do Erro: " + linha.ToString() + " Erro: " + e;
                return validador;
            }
           
        }
        public ValidadorQuantidade VerificaQtd(object _info, int linha)
        {
            ValidadorQuantidade validador = new ValidadorQuantidade();
            string _data;
            try
            {
                _data = Convert.ToString(_info);
                if (String.IsNullOrEmpty(_data))
                {
                    validador.Status = "O Campo de Quantidade esta nulo. Linha do Erro: " + linha.ToString();
                    return validador;
                }
                else
                {
                    int data;
                    try
                    {
                        data = Convert.ToInt32(_data);
                    }
                    catch (Exception e)
                    {
                        validador.Status = "O Campo de Quantidade está no formato errado para conversão. Linha do Erro: " + linha.ToString() + " Erro: " + e;
                        return validador;
                    }
                    if (data == null)
                    {
                        validador.Status = "O Campo de Quantidade esta nulo. Linha do Erro: " + linha.ToString();
                        return validador;
                    }
                    else if (data <= 0)
                    {
                        validador.Status = "O Campo de Quantidade tem valor negativo. Linha do Erro: " + linha.ToString();
                        return validador;
                    }
                    else if (data == 0)
                    {
                        validador.Status = "O Campo de Quantidade tem valor igual a 0. Linha do Erro: " + linha.ToString();
                        return validador;
                    }

                    validador.Status = "Ok";
                    validador.Quantidade = data;
                    return validador;
                }
            }
            catch (Exception e)
            {

                validador.Status = "O Campo de Quantidade esta vazio. Linha do Erro: " + linha.ToString() + " Erro: " + e;
                return validador;
            }
            
            
        }
        public ValidadorValor VerificaValor(object _info, int linha)
        {
            ValidadorValor validador = new ValidadorValor();
            string _data;
            try
            {
                _data = Convert.ToString(_info);
                if (String.IsNullOrEmpty(_data))
                {
                    validador.Status = "O Campo de Valor Unitario esta nulo. Linha do Erro: " + linha.ToString();
                    return validador;
                }
                else
                {
                    double data;
                    try
                    {
                        data = Convert.ToDouble(_data);
                    }
                    catch (Exception e)
                    {
                        validador.Status = "O Campo de Valor Unitario está no formato errado para conversão. Linha do Erro: " + linha.ToString() + " Erro: " + e;
                        return validador;
                    }
                    if (data == null)
                    {
                        validador.Status = "O Campo de Valor Unitario esta nulo. Linha do Erro: " + linha.ToString();
                        return validador;
                    }
                    else if (data <= 0)
                    {
                        validador.Status = "O Campo de Valor Unitario tem valor negativo. Linha do Erro: " + linha.ToString();
                        return validador;
                    }
                    else if (data == 0)
                    {
                        validador.Status = "O Campo de Valor Unitario tem valor igual a 0. Linha do Erro: " + linha.ToString();
                        return validador;
                    }

                    validador.Status = "Ok";
                    validador.ValorUnit = Math.Round(data, 2);
                    return validador;
                }
            }
            catch (Exception e)
            {

                validador.Status = "O Campo de Valor esta vazio. Linha do Erro: " + linha.ToString() + " Erro: " + e;
                return validador;
            }
           
        }
        public ValidadorDataEntrega VerificaData(object _info, int linha)
        {
            ValidadorDataEntrega validador = new ValidadorDataEntrega();
            string _data;
            try
            {
                _data = Convert.ToString(_info);
                if (String.IsNullOrEmpty(_data))
                {
                    validador.Status = "O Campo de data de entrega esta vazio. Linha do Erro: " + linha.ToString();
                    return validador;
                }
                else
                {
                    DateTime Data = new DateTime();
                    try
                    {
                        Data = Convert.ToDateTime(_data);
                        validador.DataEntrega = Data;
                    }
                    catch (Exception e)
                    {
                        validador.Status = $"O Valor da data não está no formato correto! - Linha do Erro: {linha.ToString()} - Erro: " + e;
                        return validador;
                    }
                    if (Data > DateTime.Now)
                    {
                        validador.Status = "Ok";
                    }
                    else if (Data == DateTime.Now.Date)
                    {
                        validador.Status = "Data de Entrega igual a Data atual. Entre com informações de entregas futuras. Linha do Erro: " + linha.ToString();
                    }
                    else if (Data < DateTime.Now.Date)
                    {
                        validador.Status = "Data de Entrega é menor que a Data atual. Entre com informações de entregas futuras. Linha do Erro: " + linha.ToString();
                    }
                    return validador;
                }
            }
            catch (Exception e)
            {
                validador.Status = "O Campo de Valor esta vazio. Linha do Erro: " + linha.ToString() + " Erro: " + e;
                return validador;
            }
          
            
        }
    }
}
