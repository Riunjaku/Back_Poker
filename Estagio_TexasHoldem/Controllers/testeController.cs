using Estagio_TexasHoldem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Estagio_TexasHoldem.Controllers
{
    public class testeController : Controller
    {
        Dealer dealer = new Dealer();

       

        [HttpGet]
        public string Jogo()
        {

            Carta[] maoJogador = dealer.darMaoJogador();


            Carta[] maoComputador = dealer.darMaoComputador();

    
            var x = verificaGanhador(maoJogador, maoComputador);

            JogoView jogoView = new JogoView();
            jogoView.maoJogadorView = maoJogador;
            jogoView.maoComputadorView = maoComputador;
            jogoView.ganhador = x;

            var jsonSerialiser = new JavaScriptSerializer();
            var retorno = jsonSerialiser.Serialize(jogoView);

            return retorno;


        }

       
        public string verificaGanhador(Carta[]x, Carta[]y)
        {
            var retorno = dealer.verificarMaos(x, y);
            return retorno;
        }
    }
}