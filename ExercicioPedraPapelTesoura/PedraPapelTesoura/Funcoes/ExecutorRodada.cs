using PedraPapelTesoura.Jogadas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedraPapelTesoura.Funcoes
{
    internal class ExecutorRodada
    {
        internal IJogador RealizarJogada(IJogador jogador01, IJogador jogador02)
        {
            IJogador vencedorRodada = null;

            if (jogador01.TipoJogada == jogador02.TipoJogada)
                return jogador01;

            switch (jogador01.TipoJogada)
            {
                case TipoJogada.Pedra:
                    if (jogador02.TipoJogada == TipoJogada.Tesoura)
                        vencedorRodada = jogador01;
                    break;
                case TipoJogada.Papel:
                    if (jogador02.TipoJogada == TipoJogada.Pedra)
                        vencedorRodada = jogador01;
                    break;
                case TipoJogada.Tesoura:
                    if (jogador02.TipoJogada == TipoJogada.Papel)
                        vencedorRodada = jogador01;
                    break;
                default:
                    vencedorRodada = jogador02;
                    break;
            }

            return vencedorRodada ?? jogador02;
        }
    }
}
