using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;

using Newtonsoft.Json;

using ReceitaWsSample.Models;
using ReceitaWsSample.Context;

namespace ReceitaWsSample.Services
{
    public class CadastroPessoaJuridicaService
    {
        private DatabaseContext _context = new DatabaseContext();

        public ICollection<CadastroPessoaJuridica> Consulta ()
        {
            return _context.CadastrosPessoaJuridica.ToList();
        }

        public CadastroPessoaJuridica Consulta (string cnpj)
        {
            return _context.CadastrosPessoaJuridica.Where(x => x.Cnpj.Equals(cnpj)).FirstOrDefault();
        }

        public CadastroPessoaJuridica ConsultaWs (string cnpj)
        {
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            string endpoint = "https://www.receitaws.com.br/v1/cnpj/" + cnpj;
            string method = "GET";

            HttpWebRequest request = WebRequest.CreateHttp(endpoint);
            request.Method = method;

            using (StreamReader responseStream = new StreamReader(request.GetResponse().GetResponseStream()))
            {
                string dadosRecuperados = responseStream.ReadToEnd();
                return JsonConvert.DeserializeObject<CadastroPessoaJuridica>(dadosRecuperados);
            }
        }

        public void Insere (CadastroPessoaJuridica model)
        {
            _context.CadastrosPessoaJuridica.Add(model);
            _context.SaveChanges();
        }
    }
}