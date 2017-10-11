using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estagio_TexasHoldem.Models
{
    public class Carta
    {
        public enum NAIPE
        {
            COPAS,
            ESPADAS,
            PAUS,
            OUROS
        }

        public enum VALOR
        {
            DOIS = 2, TRES, QUATRO, CINCO, SEIS, SETE, OITO,
            NOVE, DEZ, VALETES, RAINHA, REI, AS
        }


        public NAIPE Mnaipe { get; set; }
        public VALOR Mvalor { get; set; }

        public string TrocaLetra(string x)
        {
            if (x == "11")
            {

                return x = "J";
            }
            else if (x == "12")
            {

                return x = "Q";
            }
            else if (x == "13")
            {

                return x = "K";
            }
            else if (x == "14")
            {

                return x = "A";
            }
            return x;
        }
    }
}
