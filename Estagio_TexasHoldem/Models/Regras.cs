using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estagio_TexasHoldem.Models
{
    public enum Mao
    {
        [Description("Carta Alta")]
        nothing,
        [Description("Um Par")]
        OnePair,
        [Description("Dois Pares")]
        TwoPair,
        [Description("Trinca")]
        ThreeKind,
        [Description("Sequência")]
        Straight,
        Flush,
        [Description("Full House")]
        FullHouse,
        [Description("Quadra")]
        FourKind,
        [Description("Straight Flush")]
        StraightFlush,
        [Description("Royal Flush")]
        RoyalFlush
    }

    public struct ValorDaMao
    {
        public int Total { get; set; }
        public int HighCard { get; set; }
    }

    class Regras : Carta
    {
        private int copasSoma;
        private int ouroSoma;
        private int espadasSoma;
        private int pausSoma;
        private Carta[] cartas;
        private ValorDaMao valorDaMao;

        public Regras(Carta[] maoOrganizada)
        {
            copasSoma = 0;
            ouroSoma = 0;
            espadasSoma = 0;
            pausSoma = 0;
            cartas = new Carta[5];
            Cartas = maoOrganizada;
            valorDaMao = new ValorDaMao();
        }

        public ValorDaMao ValordasMaos
        {
            get { return valorDaMao; }
            set { valorDaMao = value; }
        }

        public Carta[] Cartas
        {
            get { return cartas; }
            set
            {
                cartas[0] = value[0];
                cartas[1] = value[1];
                cartas[2] = value[2];
                cartas[3] = value[3];
                cartas[4] = value[4];
            }
        }

        public Mao MaoVerificada()
        {
            getNumberOfSuit();
            if (RoyalFlush())
                return Mao.RoyalFlush;
            else if (StraightFlush())
                return Mao.StraightFlush;
            else if (FourOfKind())
                return Mao.FourKind;
            else if (FullHouse())
                return Mao.FullHouse;
            else if (Flush())
                return Mao.Flush;
            else if (Straight())
                return Mao.Straight;
            else if (ThreeOfKind())
                return Mao.ThreeKind;
            else if (TwoPairs())
                return Mao.TwoPair;
            else if (OnePair())
                return Mao.OnePair;

            valorDaMao.HighCard = (int)cartas[4].Mvalor;
            return Mao.nothing ;
        }

        private void getNumberOfSuit()
        {
            foreach (var element in Cartas)
            {
                if (element.Mnaipe == Carta.NAIPE.COPAS)
                    copasSoma++;
                else if (element.Mnaipe == Carta.NAIPE.ESPADAS)
                    espadasSoma++;
                else if (element.Mnaipe == Carta.NAIPE.OUROS)
                    ouroSoma++;
                else if (element.Mnaipe == Carta.NAIPE.PAUS)
                    pausSoma++;
            }
        }

        private bool RoyalFlush()
        {
            //sequencia acima de 10
            if (cartas[0].Mvalor == VALOR.DEZ && cartas[1].Mvalor == VALOR.VALETES && cartas[2].Mvalor == VALOR.RAINHA
                && cartas[3].Mvalor == VALOR.REI && cartas[4].Mvalor == VALOR.AS)
            {
                valorDaMao.Total = ((int)cartas[0].Mvalor + (int)cartas[1].Mvalor + (int)cartas[2].Mvalor
                    + (int)cartas[3].Mvalor + (int)cartas[4].Mvalor);
                valorDaMao.HighCard = (int)cartas[4].Mvalor;
            }
            return false;
        }

        private bool StraightFlush()
        {
            //sequencia abaixo de 10
            // 2 3 4 5 6
            // 3 4 5 6 7
            // 4 5 6 7 8
            // 5 6 7 8 9
            // 10 11 12 13 14
            if (cartas[0].Mvalor == VALOR.DOIS && cartas[1].Mvalor == VALOR.TRES && cartas[2].Mvalor == VALOR.QUATRO
               && cartas[3].Mvalor == VALOR.CINCO && cartas[4].Mvalor == VALOR.SEIS)
            {
                valorDaMao.Total = ((int)cartas[0].Mvalor + (int)cartas[1].Mvalor + (int)cartas[2].Mvalor
                    + (int)cartas[3].Mvalor + (int)cartas[4].Mvalor);
                valorDaMao.HighCard = (int)cartas[4].Mvalor;
            }
            else if (cartas[0].Mvalor == VALOR.TRES && cartas[1].Mvalor == VALOR.QUATRO && cartas[2].Mvalor == VALOR.CINCO
              && cartas[3].Mvalor == VALOR.SEIS && cartas[4].Mvalor == VALOR.SETE)
            {
                valorDaMao.Total = ((int)cartas[0].Mvalor + (int)cartas[1].Mvalor + (int)cartas[2].Mvalor
                    + (int)cartas[3].Mvalor + (int)cartas[4].Mvalor);
                valorDaMao.HighCard = (int)cartas[4].Mvalor;
            }
            else if (cartas[0].Mvalor == VALOR.QUATRO && cartas[1].Mvalor == VALOR.CINCO && cartas[2].Mvalor == VALOR.SEIS
             && cartas[3].Mvalor == VALOR.SETE && cartas[4].Mvalor == VALOR.OITO)
            {
                valorDaMao.Total = ((int)cartas[0].Mvalor + (int)cartas[1].Mvalor + (int)cartas[2].Mvalor
                    + (int)cartas[3].Mvalor + (int)cartas[4].Mvalor);
                valorDaMao.HighCard = (int)cartas[4].Mvalor;
            }
            else if (cartas[0].Mvalor == VALOR.CINCO && cartas[1].Mvalor == VALOR.SEIS && cartas[2].Mvalor == VALOR.SETE
             && cartas[3].Mvalor == VALOR.OITO && cartas[4].Mvalor == VALOR.NOVE)
            {
                valorDaMao.Total = ((int)cartas[0].Mvalor + (int)cartas[1].Mvalor + (int)cartas[2].Mvalor
                    + (int)cartas[3].Mvalor + (int)cartas[4].Mvalor);
                valorDaMao.HighCard = (int)cartas[4].Mvalor;
            }

            return false;
        }

        private bool FourOfKind()
        {
            if (cartas[0].Mvalor == cartas[3].Mvalor)
            {
                valorDaMao.Total = (int)cartas[1].Mvalor * 4;
                valorDaMao.HighCard = (int)cartas[4].Mvalor;
                return true;
            }
            else if (cartas[1].Mvalor == cartas[4].Mvalor)
            {
                valorDaMao.Total = (int)cartas[1].Mvalor * 4;
                valorDaMao.HighCard = (int)cartas[0].Mvalor;
                return true;
            }

            return false;
        }

        private bool FullHouse()
        {
            if ((cartas[0].Mvalor == cartas[2].Mvalor && cartas[3].Mvalor == cartas[4].Mvalor) ||
              (cartas[0].Mvalor == cartas[2].Mvalor && cartas[3].Mvalor == cartas[4].Mvalor))
            {
                valorDaMao.Total = (int)(cartas[0].Mvalor) + (int)(cartas[1].Mvalor) + (int)(cartas[2].Mvalor)
                    + (int)(cartas[3].Mvalor) + (int)(cartas[4].Mvalor);
                return true;
            }
            return false;
        }

        private bool Flush()
        {
            if (copasSoma == 5 || pausSoma == 5 || ouroSoma == 5 || espadasSoma == 5)
            {
                valorDaMao.Total = (int)cartas[4].Mvalor;
                return true;
            }
            return false;
        }

        private bool Straight()
        {
            if (cartas[0].Mvalor + 1 == cartas[1].Mvalor &&
                cartas[1].Mvalor + 1 == cartas[2].Mvalor &&
                cartas[2].Mvalor + 1 == cartas[3].Mvalor &&
                cartas[3].Mvalor + 1 == cartas[4].Mvalor)
            {
                valorDaMao.Total = (int)cartas[4].Mvalor;
                return true;
            }
            return false;
        }

        private bool ThreeOfKind()
        {
            if ((cartas[0].Mvalor == cartas[1].Mvalor && cartas[0].Mvalor == cartas[2].Mvalor) ||
                (cartas[1].Mvalor == cartas[2].Mvalor && cartas[1].Mvalor == cartas[3].Mvalor))
            {
                valorDaMao.Total = (int)cartas[2].Mvalor * 3;
                valorDaMao.HighCard = (int)cartas[4].Mvalor;
                return true;
            }
            else if (cartas[2].Mvalor == cartas[3].Mvalor && cartas[2].Mvalor == cartas[4].Mvalor)
            {
                valorDaMao.Total = (int)cartas[2].Mvalor * 3;
                valorDaMao.HighCard = (int)cartas[1].Mvalor;
                return true;
            }
            return false;
        }

        private bool TwoPairs()
        {
            if (cartas[0].Mvalor == cartas[1].Mvalor && cartas[2].Mvalor == cartas[3].Mvalor)
            {
                valorDaMao.Total = ((int)cartas[1].Mvalor * 2) + ((int)cartas[3].Mvalor * 2);
                valorDaMao.HighCard = (int)cartas[4].Mvalor;
                return true;
            }
            else if (cartas[0].Mvalor == cartas[1].Mvalor && cartas[3].Mvalor == cartas[4].Mvalor)
            {
                valorDaMao.Total = ((int)cartas[1].Mvalor * 2) + ((int)cartas[3].Mvalor * 2);
                valorDaMao.HighCard = (int)cartas[2].Mvalor;
                return true;
            }
            else if (cartas[1].Mvalor == cartas[2].Mvalor && cartas[3].Mvalor == cartas[4].Mvalor)
            {
                valorDaMao.Total = ((int)cartas[1].Mvalor * 2) + ((int)cartas[3].Mvalor * 2);
                valorDaMao.HighCard = (int)cartas[0].Mvalor;
                return true;
            }
            return false;

        }

        private bool OnePair()
        {
            if (cartas[0].Mvalor == cartas[1].Mvalor)
            {
                valorDaMao.Total = (int)cartas[0].Mvalor * 2;
                valorDaMao.HighCard = (int)cartas[4].Mvalor;
                return true;
            }
            else if (cartas[1].Mvalor == cartas[2].Mvalor)
            {
                valorDaMao.Total = (int)cartas[1].Mvalor * 2;
                valorDaMao.HighCard = (int)cartas[4].Mvalor;
                return true;
            }
            else if (cartas[2].Mvalor == cartas[3].Mvalor)
            {
                valorDaMao.Total = (int)cartas[2].Mvalor * 2;
                valorDaMao.HighCard = (int)cartas[4].Mvalor;
                return true;
            }
            else if (cartas[3].Mvalor == cartas[4].Mvalor)
            {
                valorDaMao.Total = (int)cartas[3].Mvalor * 2;
                valorDaMao.HighCard = (int)cartas[2].Mvalor;
                return true;
            }
            return false;
        }


    }
}