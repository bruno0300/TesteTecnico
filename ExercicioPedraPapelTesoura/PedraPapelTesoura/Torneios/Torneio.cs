using System.Collections.Generic;
using PedraPapelTesoura.Jogadas;
using PedraPapelTesoura.Funcoes;
using PedraPapelTesoura.Excecoes;

namespace PedraPapelTesoura.Torneios
{
    internal abstract class Torneio
    {
        public Torneio()
        {
            _jogadores = new List<IJogador>();
            ExecutorRodada = new ExecutorRodada();
        }

        internal int? QuantidadeJogadoresPermitidos { get; set; }
        internal int QuantidadeJogadoresParticipantes { get; set; }
        private List<IJogador> _jogadores { get; set; }
        internal abstract IJogador CalcularVencedor();
        internal ExecutorRodada ExecutorRodada;

        internal virtual void IncluirJogada(IJogador jogador)
        {
            if (QuantidadeJogadoresPermitidos.HasValue && !PermiteMaisJogadores())
                throw new QuantidadeJogadoresException("Capacidade de jogadores esgotada!");

            QuantidadeJogadoresParticipantes++;
            _jogadores.Add(jogador);
        }

        internal virtual List<IJogador> ListarJogadores()
        {
            return _jogadores;
        }

        private bool PermiteMaisJogadores()
        {
            return (QuantidadeJogadoresPermitidos - QuantidadeJogadoresParticipantes) > 0;
        }
    }
}
