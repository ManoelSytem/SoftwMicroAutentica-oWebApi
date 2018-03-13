using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwMicroWebApi.Models
{
    public class Fornecedor
    {
       public int Id { get; set; }
       public string RazaoSocial { get; set; }
       public string NomeFantasia { get; set; }
       public string InscricaoEstadual { get; set; }
       public string Cnpj { get; set; }
       public string Endereco { get; set; }
       public string Email { get; set; }
       public string Telefone { get; set; }
       public string Categoria { get; set; }
    }
}