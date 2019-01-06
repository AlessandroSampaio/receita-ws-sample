using Newtonsoft.Json;

namespace ReceitaWsSample.Models
{
    public class SocioAdministrador
    {
        public int ID { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("qual")]
        public string Ocupacao { get; set; }

        public CadastroPessoaJuridica CadastroPessoaJuridica { get; set; }
    }
}