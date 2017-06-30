using System.Collections.Generic;
using System.Linq;
using PedraPapelTesoura.Jogadas;
using PedraPapelTesoura.Funcoes;

namespace PedraPapelTesoura.Torneios
{
    class TorneioCampeonato : Torneio
    {
        public TorneioCampeonato()
        {
            QuantidadeJogadoresPermitidos = null;
        }

        internal override IJogador CalcularVencedor()
        {
            var jogadores = ListarJogadores();
            var grupos = jogadores.Select(a => a.GrupoJogada).Distinct();
            List<IJogador> vencedoresProximaRodada = new List<IJogador>();
            List<IJogador> vencedoresGrupos = new List<IJogador>();

            foreach (var grupo in grupos)
            {
                var jogadoresGrupoAtual = jogadores.Where(a => a.GrupoJogada == grupo).ToArray();
                var vencedoresGrupoAtual = jogadoresGrupoAtual;

                while (vencedoresGrupoAtual.Count() > 1)
                {
                    for (int i = 0; i < vencedoresGrupoAtual.Count(); i += 2)
                    {
                        IJogador ganhadorJogada = ExecutorRodada.RealizarJogada(vencedoresGrupoAtual[i], vencedoresGrupoAtual[i + 1]);
                        vencedoresProximaRodada.Add(ganhadorJogada);
                    }

                    vencedoresGrupoAtual = vencedoresProximaRodada.ToArray();
                    vencedoresProximaRodada.Clear();
                }

                vencedoresGrupos.Add(vencedoresGrupoAtual.First());
            }

            IJogador vencedorCampeonato = vencedoresGrupos.Count() > 1 ? ExecutorRodada.RealizarJogada(vencedoresGrupos[0], vencedoresGrupos[1]) : vencedoresGrupos[0];

            return vencedorCampeonato;
        }
    }
}
