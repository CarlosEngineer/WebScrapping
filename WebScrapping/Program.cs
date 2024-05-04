using HtmlAgilityPack;
using System;
using System.Net.Http;


namespace WebScrapping
{
    class Program
    {
        static void Main(string[] args)
        {

            //Envia requisição para weather.com:

            string url = "https://weather.com/pt-BR/clima/hoje/l/3917934a4e55cfd3bafca3c09d4628a2a174f78bf67f67874bac5673e25e2ddf";
            var HttpClient = new HttpClient();
            var html = HttpClient.GetStringAsync(url).Result;

            var htmlDocument =  new HtmlDocument();
            htmlDocument.LoadHtml(html);

            //captura temperatura:
            var TemperaturaElemento = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='CurrentConditions--tempValue--MHmYY']");
            var Temperatura = TemperaturaElemento.InnerText.Trim();
            Console.WriteLine("Temperatura:" + Temperatura);



            //captura conndições:
            var CondicaoElemento = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='CurrentConditions--phraseValue--mZC_p']");
            var Condicao = CondicaoElemento.InnerText.Trim();
            Console.WriteLine("Condição: " + Condicao);


            //captura Localização:

            var LocalizacaoElemento = htmlDocument.DocumentNode.SelectSingleNode("//h1[@class='CurrentConditions--location--1YWj_']");
            var Localizacao = LocalizacaoElemento.InnerText.Trim();
            Console.WriteLine("Localização: " + Localizacao);

        }
    }
}
