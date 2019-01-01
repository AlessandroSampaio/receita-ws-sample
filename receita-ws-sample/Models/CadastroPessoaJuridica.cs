using System;

using Newtonsoft.Json;

namespace ReceitaWsSample.Models
{
    public class CadastroPessoaJuridica
    {
        public int ID { get; set; }  

        [JsonProperty("nome")]
        public string RazaoSocial { get; set; }

        [JsonProperty("fantasia")]
        public string NomeFantasia { get; set; }

        [JsonProperty("uf")]
        public string Uf { get; set; }

        [JsonProperty("telefone")]
        public string Telefone { get; set; }

        [JsonProperty("situacao")]
        public string Situacao { get; set; }

        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }

        [JsonProperty("numero")]
        public string Numero { get; set; }

        [JsonProperty("cep")]
        public string Cep { get; set; }

        [JsonProperty("municipio")]
        public string Municipio { get; set; }

        [JsonProperty("abertura")]
        public string DataAbertura { get; set; }

        [JsonProperty("ultima_atualizacao")]
        public DateTime UltimaAtualizacao { get; set; }

        [JsonProperty("cnpj")]
        public string Cnpj { get; set; }

        [JsonProperty("tipo")]
        public string Tipo { get; set; }

        public DateTime DataInclusao { get; set; }
    }
}