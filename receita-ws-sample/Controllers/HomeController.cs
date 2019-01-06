using System;
using System.Web.Mvc;
using System.Net;

using ReceitaWsSample.Models;
using ReceitaWsSample.Services;

namespace ReceitaWsSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly CadastroPessoaJuridicaService _service = new CadastroPessoaJuridicaService();

        // GET: Home/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/Consulta
        [HttpGet]
        public ActionResult Consulta (string cnpj)
        {
            if(!string.IsNullOrEmpty(cnpj))
            {
                CadastroPessoaJuridica cnpjModel = null;

                try
                {
                    // Consulta o CNPJ no banco de dados
                    cnpjModel = _service.Consulta(cnpj.ToCnpjFormat());

                    if (cnpjModel == null)
                    {
                        // Consulta o CNPJ na API
                        cnpjModel = _service.ConsultaWs(cnpj);
                        
                        // Testa se a API retornou dados
                        if(!string.IsNullOrEmpty(cnpjModel.Cnpj))
                        {
                            cnpjModel.DataInclusao = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "E. South America Standard Time");

                            if (cnpjModel.Socios.Count != 0)
                            {
                                foreach (var socio in cnpjModel.Socios)
                                    socio.CadastroPessoaJuridica = cnpjModel;

                                _service.Insere(cnpjModel, true);
                            }
                            else
                            {
                                _service.Insere(cnpjModel);
                            }
                        }
                        else
                        {
                            return HttpNotFound("O CNPJ informado não foi encontrado");
                        }
                    }
                }
                catch (Exception e)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Conflict, e.Message);
                }

                return View(cnpjModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}