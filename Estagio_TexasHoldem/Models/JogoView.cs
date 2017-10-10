using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estagio_TexasHoldem.Models
{
    public class JogoView
    {
        public Carta[] maoJogadorView { get; set; }
        public Carta[] maoComputadorView { get; set; }

        public string ganhador { get; set; }
    }
}