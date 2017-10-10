﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estagio_TexasHoldem.Models
{
    public class Dealer : Baralho
    {
        private Carta[] jogadorMao;
        private Carta[] computadorMao;
        private Carta[] jogadorMaoOrganizada;
        private Carta[] computadorMaoOrganizada;
        public string ganhador;

        public Dealer()
        {
            jogadorMao = new Carta[5];
            computadorMao = new Carta[5];
            jogadorMaoOrganizada = new Carta[5];
            computadorMaoOrganizada = new Carta[5];
        }

        public Carta[] darMaoJogador() {
            setBaralho();
            Carta[] x = getMaoJogador();
            x = organizarCartasJogador(x);

            return x;

        }

        public Carta[] darMaoComputador()
        {
            setBaralho();
            Carta[] x = getMaoComputador();
            x = organizarCartasInimigo(x);

            return x;

        }

        public Carta[] getMaoJogador()
        {

            for (int i = 0; i < 5; i++)
                jogadorMao[i] = getBaralho[i];

            return jogadorMao;

        }

        public Carta[] getMaoComputador()
        {

            for (int i = 0; i < 5; i++)
                computadorMao[i] = getBaralho[i+5];

            return computadorMao;

        }


        public Carta[] organizarCartasJogador(Carta[] carta)
        {

            var queryJogador = from mao in carta
                               orderby mao.Mvalor
                               select mao;


            var index = 0;

            foreach (var element in queryJogador.ToList())
            {
                jogadorMaoOrganizada[index] = element;
                index++;
            }

            return jogadorMaoOrganizada;

        }

        public Carta[] organizarCartasInimigo(Carta[] carta)
        {
            var queryComputador = from mao in computadorMao
                                  orderby mao.Mvalor
                                  select mao;

            var index = 0;

            foreach (var element in queryComputador.ToList())
            {
                computadorMaoOrganizada[index] = element;
                index++;
            }

            return computadorMaoOrganizada;
        }

    public string verificarMaos(Carta[]x, Carta[]y)
        {
            Regras jogadorMaoVerificada = new Regras(x);
            Regras computadorMaoVerificada = new Regras(y);

            Mao jogadorMao = jogadorMaoVerificada.MaoVerificada();
            Mao computadorMao = computadorMaoVerificada.MaoVerificada();

            if (jogadorMao > computadorMao)
            {
               return ganhador = "player ganhou";
            }
            else if (jogadorMao < computadorMao)
            {
                return ganhador = "computador ganhou"; //computador ganhou
            }
            else
            {
                if (jogadorMaoVerificada.ValordasMaos.Total > computadorMaoVerificada.ValordasMaos.Total)
                {
                    return ganhador = "player ganhou";
                }
                else if (jogadorMaoVerificada.ValordasMaos.Total > computadorMaoVerificada.ValordasMaos.Total)
                {
                    return ganhador = "computador ganhou";//computador ganhou
                }
                else if (jogadorMaoVerificada.ValordasMaos.HighCard > computadorMaoVerificada.ValordasMaos.HighCard)
                {
                    return ganhador = "player ganhou";
                }
                else if (jogadorMaoVerificada.ValordasMaos.HighCard < computadorMaoVerificada.ValordasMaos.HighCard)
                {
                    return ganhador = "computador ganhou";//Computador ganhou
                }
                else
                {
                    return ganhador = "player e computador ganhou"; //ningem ganhou, ou todos ganharam nunca aconteceu antes
                }
            }
        }
    }
}