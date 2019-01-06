using System;
using System.Collections.Generic;

namespace ReceitaWsSample.Models.ViewModel
{
    public class HomeViewModel
    {
        public ICollection<CadastroPessoaJuridica> CadastrosPessoaJuridica { get; set; }

        public HomeViewModel ()
        {
            CadastrosPessoaJuridica = new List<CadastroPessoaJuridica>();
        }
    }
}