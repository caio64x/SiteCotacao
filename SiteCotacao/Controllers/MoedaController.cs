using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSharp;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Newtonsoft.Json;
using SiteCotacao.Models;

namespace SiteCotacao.Controllers
{
    public class MoedaController : Controller
    {
        [HttpGet]
        public ActionResult Converter()
        {
            ViewBag.TotalDolar = 0;
            ViewBag.TotalEuro = 0;
            ViewBag.TotalBtc = 0;

            return View();
        }

        [HttpPost]
        public ActionResult Converter(FormCollection form)
        {
            //pega o valor do campo da tela
             decimal valorReal  = Convert.ToDecimal(form["CampoValor"]);

            //pegar o valor da api
            var url = "https://economia.awesomeapi.com.br/last/USD-BRL,EUR-BRL,BTC-BRL";
            var uri = new Uri(url);
            var moeda1 = new USDBRL();


            using(WebClient client = new WebClient())
            {
                var json = client.DownloadString(uri);
                moeda1 = JsonConvert.DeserializeObject<USDBRL>(json);
            }


            ViewBag.TotalReal = valorReal;
            ViewBag.TotalDolar = valorReal/5;
            ViewBag.TotalEuro = valorReal/6;
            ViewBag.TotalBtc = valorReal/3000000;

            return View();

        }
    }
}