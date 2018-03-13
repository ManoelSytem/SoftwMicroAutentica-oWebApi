using SoftwMicroWebApi.Models;
using SoftwMicroWebApi.Models.Interface;
using SoftwMicroWebApi.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SoftwMicroWebApi.Controlles
{
    public class FornecedorController : ApiController
    {

        static readonly FornecedorRepositorio repositorio = new FornecedorRepositorio();

        public IEnumerable<Fornecedor> GetAllFornecedors()
        {
            return repositorio.GetAll();
        }

        public Fornecedor GetFornecedor(string cnpj)
        {
            Fornecedor item = repositorio.Get(cnpj);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<Fornecedor> GetFornecedorsPorNomeFantasia(string nomeFantasia)
        {
            return repositorio.GetAll().Where(
                p => string.Equals(p.NomeFantasia, nomeFantasia, StringComparison.OrdinalIgnoreCase));
        }

        public HttpResponseMessage PostFornecedor(Fornecedor item)
        {
            item = repositorio.Add(item);
            var response = Request.CreateResponse<Fornecedor>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutFornecedor(int id, Fornecedor Fornecedor)
        {
            Fornecedor.Id = id;
            if (!repositorio.Update(Fornecedor))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteFornecedor(string cnpj)
        {
            Fornecedor item = repositorio.Get(cnpj);

            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repositorio.Remove(cnpj);
        }
    }
}
