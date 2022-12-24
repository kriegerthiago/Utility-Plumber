using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace Utility_Plumber.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelperController : Controller
    {

        public HelperController()
        {

        }
        #region Utilitarios
        [HttpGet("TransformarEmHtml")]
        public string TransformarEmHtml(string input)
        {
            try
            {
                var result = HttpUtility.HtmlEncode(input);
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("TransformarEmUrl")]
        public string TransformarEmUrl(string input)
        {
            try
            {
                var result = HttpUtility.UrlEncode(input);
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("FormatarData")]
        public string FormatarData(string input)
        {
            try
            {
                var result = DateTime.Parse(input).ToString("dd/MM/yyyy HH:mm:ss");
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GerarSenha8Digitos")]
        public string GerarSenha(int digitos)
        {
            try
            {
                var result = Guid.NewGuid().ToString().Substring(0, digitos);
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet("FormatarCPF")]
        public string FormatarCPF(string cpf)
        {
            string? result;
            try
            {
                if (cpf.Length == 11)
                {
                    result = Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
                }
                else
                {
                    result = "CPF Inválido";
                }
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("FormatarCNPJ")]
        public string FormatarCNPJ(string cnpj)
        {
            string? retorno;
            if (cnpj.Length == 14)
            {
                retorno = Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\\0000\-00");
            }
            else
            {
                retorno = "CNPJ Inválido";
            }
            return retorno;
        }
        #endregion

    }
}
