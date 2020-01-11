using Newtonsoft.Json;
using System.Net;

namespace App01_ConsultarCEP.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Modelo.Endereco BuscarEnderecoViaCEP(string cep)
        {
            string novoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(novoEnderecoURL);

            Modelo.Endereco end = JsonConvert.DeserializeObject<Modelo.Endereco>(conteudo);

            if (end.cep == null) return null;

            return end;            
        }
    }
}
