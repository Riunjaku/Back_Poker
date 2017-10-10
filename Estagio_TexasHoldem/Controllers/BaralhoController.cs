using Estagio_TexasHoldem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Estagio_TexasHoldem.Controllers
{
    public class BaralhoController : ApiController
    {
        
        public Carta[] getBaralhoEmbaralhado() 
        {
            Baralho baralho = new Baralho();
            Carta[] baralhoJogo = baralho.setBaralho();

            return baralhoJogo;
        }
    }
}
