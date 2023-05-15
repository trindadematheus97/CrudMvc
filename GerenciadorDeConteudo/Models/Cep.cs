using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciadorDeConteudo.Models
{
    public class Cep
    {
        public int CEP { get; set; }
        public int Estado { get; set; }
        public int Endereco { get; set; }
        public int Bairro { get; set; }
        public int Cidade { get; set; }
    }
}