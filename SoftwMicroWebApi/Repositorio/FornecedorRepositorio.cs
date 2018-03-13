using SoftwMicroWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwMicroWebApi.Repositorio
{
    public class FornecedorRepositorio
    {
        private List<Fornecedor> fornecedor = new List<Fornecedor>();
        private int _nextId = 1;


        public FornecedorRepositorio()
        {
            Add(new Fornecedor
            {
                RazaoSocial = "Companhia de Eletricidade do Estado da Bahia Coelba",
                NomeFantasia = "Coelba",
                InscricaoEstadual = "",
                Cnpj = "15.139.629/0403-07",
                Endereco = "Rod Br 135 Km-18, S/N, Usina Alto Femeas, Br, Sao Desiderio, BA, CEP 47820-000, Brasil",
                Email = "torp@coelba.com.br",
                Telefone = "(77) 8119-935",
            });

            Add(new Fornecedor
            {
                NomeFantasia = "Coelba",
                Cnpj = "84.805.205/0001-34",
                Categoria = "Energia Elétrica"
            });

            Add(new Fornecedor
            {
                NomeFantasia = "Stefanini",
                Cnpj = "65.182.980/0001-36",
                Categoria = "Tecnologia"
            });

            Add(new Fornecedor
            {
                NomeFantasia = "Plug Locação Informática ",
                Cnpj = "31.148.188/0001-43",
                Categoria = "Audiovisual"
            });

            Add(new Fornecedor
            {
                NomeFantasia = "Fulltime Brasil",
                Cnpj = "24.725.217/0001-27",
                Categoria = "Agência Propaganda e Marketing"
            });

            Add(new Fornecedor
            {
                NomeFantasia = "Frigelar",
                Cnpj = "55.151.506/0001-93",
                Categoria = "Ar Condicionado"
            });


            Add(new Fornecedor
            {
                NomeFantasia = "VitalMed",
                Cnpj = "15.138.645/0001-62",
                Categoria = "Serviços de Saúde"
            });

             Add(new Fornecedor
             {
                 NomeFantasia = "Epj Promoções e Eventos",
                 Cnpj = "35.138.645/0001-62",
                 Categoria = "Buffets Alimentação"
             });


        }

        public Fornecedor Add(Fornecedor empresa)
        {

            if (empresa == null)
            {
                throw new ArgumentNullException("empresa");
            }

            empresa.Id = _nextId++;
            fornecedor.Add(empresa);
            return empresa;

        }

        public Fornecedor Get(string cnpj)
        {
            return fornecedor.Find(p => p.Cnpj == cnpj);
        }

        public IEnumerable<Fornecedor> GetAll()
        {
            return fornecedor;
        }

        public void Remove(string cnpj)
        {
            fornecedor.RemoveAll(p => p.Cnpj == cnpj);
        }

        public bool Update(Fornecedor empresa)
        {
            if (empresa == null)
            {
                throw new ArgumentNullException("empresa");
            }
            int index = fornecedor.FindIndex(p => p.Id == empresa.Id);
            if (index == -1)
            {
                return false;

            }

            fornecedor.RemoveAt(index);

            fornecedor.Add(empresa);
            return true;
        }
    }

}
