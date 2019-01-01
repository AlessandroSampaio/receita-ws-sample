﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ReceitaWsSample.Context;
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
                    cnpjModel = _service.Consulta(cnpj);

                    if (cnpjModel == null)
                    {
                        // Consulta o CNPJ na API
                        cnpjModel = _service.ConsultaWs(cnpj);
                        
                        // Testa se a API retornou dados
                        if(!string.IsNullOrEmpty(cnpjModel.Cnpj))
                        {
                            cnpjModel.DataInclusao = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "E. South America Standard Time");
                            _service.Insere(cnpjModel);
                        }
                        else
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
                catch (Exception)
                {
                    return RedirectToAction("Index");
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