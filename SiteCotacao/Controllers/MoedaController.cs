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
            decimal valorReal;
           
            try
            {
                valorReal = Convert.ToDecimal(form["CampoValor"]);
            }
            catch 
            {
                valorReal = Convert.ToDecimal("0.00");
            }


            //pegar o valor da api
            var url = "https://economia.awesomeapi.com.br/last/USD-BRL,EUR-BRL,BTC-BRL";
            var uri = new Uri(url);
            var moeda1 = new USDBRL();
            Moeda moeda = new Moeda();


            using(WebClient client = new WebClient())
            {
                var json = client.DownloadString(uri);
                moeda = JsonConvert.DeserializeObject<Moeda>(json);
            }


            ViewBag.TotalReal = valorReal;
            ViewBag.TotalDolar = (valorReal / moeda.USDBRL.ask).ToString("N2");
            ViewBag.TotalEuro = (valorReal / moeda.EURBRL.ask).ToString("N2");
            ViewBag.TotalBtc = (valorReal / (moeda.BTCBRL.ask * 1000)).ToString("N4");

            return View();

        }
    }
}