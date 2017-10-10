using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estagio_TexasHoldem.Models
{
     public class Baralho : Carta
    {
        const int NUM_DE_CARTAS = 52; // quantidade total de cartas
        private Carta[] baralho; //array de cartas

        public Baralho()
        {
            baralho = new Carta[NUM_DE_CARTAS];
        }

        public Carta[] getBaralho { get { return baralho; } } // recupera o deck atual

        //criar um deck com 4 naipes e 13 valores

        public Carta[] setBaralho()
        {
            int i = 0;
            foreach (NAIPE n in Enum.GetValues(typeof(NAIPE)))
            {
                foreach (VALOR v in Enum.GetValues(typeof(VALOR)))
                {
                    baralho[i] = new Carta { Mnaipe = n, Mvalor = v };
                    i++;
                }
            }
            var baralhoEmbaralhado = embaralharCartas();
            return baralhoEmbaralhado;
        }

        //embaralha o baralho
        public Carta[] embaralharCartas()
        {
            Random random = new Random();
            Carta temp;
            int embaralhar;

            for (embaralhar = 0; embaralhar < 45; embaralhar++)
            {
                for (int i = 0; i < NUM_DE_CARTAS; i++)
                {
                    int baralhoSecundario = random.Next(13);
                    temp = baralho[i];
                    baralho[i] = baralho[baralhoSecundario];
                    baralho[baralhoSecundario] = temp;
                }
            }
            return baralho;

        }
    }
}