using System;
using PedraPapelTesoura.Excecoes;
using PedraPapelTesoura.Jogadas;
using PedraPapelTesoura.Funcoes;

namespace PedraPapelTesoura.Torneios
{
    class TorneioDoisJogadores : Torneio
    {
        public TorneioDoisJogadores()
        {
            QuantidadeJogadoresPermitidos = 2;
        }

        internal override IJogador CalcularVencedor()
        {
            var jogadores = ListarJogadores();

            if (jogadores.Count != QuantidadeJogadoresPermitidos)
                throw new QuantidadeJogadoresException(String.Format("Quantidade de jogadores diferente de {0}!", QuantidadeJogadoresPermitidos));

            IJogador vencedor = ExecutorRodada.RealizarJogada(jogadores[0], jogadores[1]);
            
            return vencedor;
        }
    }
}
