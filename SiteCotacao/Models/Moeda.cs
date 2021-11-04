using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteCotacao.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class USDBRL
    {
        public string code { get; set; }
        public string codein { get; set; }
        public string name { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string varBid { get; set; }
        public string pctChange { get; set; }
        public string bid { get; set; }
        public decimal ask { get; set; }
        public string timestamp { get; set; }
        public string create_date { get; set; }
    }

    public class EURBRL
    {
        public string code { get; set; }
        public string codein { get; set; }
        public string name { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string varBid { get; set; }
        public string pctChange { get; set; }
        public string bid { get; set; }
        public decimal ask { get; set; }
        public string timestamp { get; set; }
        public string create_date { get; set; }
    }

    public class BTCBRL
    {
        public string code { get; set; }
        public string codein { get; set; }
        public string name { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string varBid { get; set; }
        public string pctChange { get; set; }
        public string bid { get; set; }
        public decimal ask { get; set; }
        public string timestamp { get; set; }
        public string create_date { get; set; }
    }

    public class Moeda
    {
        public USDBRL USDBRL { get; set; }
        public EURBRL EURBRL { get; set; }
        public BTCBRL BTCBRL { get; set; }
    }


}