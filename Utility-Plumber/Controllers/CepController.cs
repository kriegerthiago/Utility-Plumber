using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using static System.Net.WebRequestMethods;

namespace Utility_Plumber.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CepController : Controller
    {
        public CepController()
        {

        }

        [HttpGet("ObterWebRequest")]
        public static string ObterWebRequest(string metodohttp, string url)
        {
            WebRequest webRequest = WebRequest.Create(url);

            webRequest.Method = metodohttp;

            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

            string StreamReaderResponse = string.Empty;

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader streamreader = new StreamReader(stream);
                StreamReaderResponse = streamreader.ReadToEnd();
            }

            return StreamReaderResponse;
        }

        [HttpGet("ConsultarCep")]
        public string ConsultarCep(string cep)
        {
            string url = $"https://viacep.com.br/ws/{cep}/json/";

            string metodohttp = Http.Get;

            string response = ObterWebRequest(metodohttp, url);

            if (response != null)
            {
            return response;

            }
            else
            {
                return "CEP não encontrado";
            }


        }
    }

}

