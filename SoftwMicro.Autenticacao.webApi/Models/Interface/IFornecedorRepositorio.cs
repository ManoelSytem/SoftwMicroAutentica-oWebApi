using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwMicro.Autenticacao.webApi.Models.Interface
{
    public interface IFornecedorRepositorio
    {
       IEnumerable<Fornecedor> GetAll();
       Fornecedor Get(int id);
       Fornecedor Add(Fornecedor empresa);
       void Remove(int id);
       bool Update(Fornecedor fornecedor);
    }
}
