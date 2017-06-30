using PedraPapelTesoura.Torneios;
using System.Collections.Generic;

namespace PedraPapelTesoura.Jogadas
{
    internal sealed class CompositeTorneios
    {
        private readonly List<Torneio> _torneios = new List<Torneio>();

        internal List<IJogador> ComporTorneios()
        {
            List<IJogador> vencedores = new List<IJogador>();

            _torneios.ForEach(a => vencedores.Add(a.CalcularVencedor()));

            return vencedores;
        }

        internal void IncluirTorneio(Torneio torneio)
        {
            _torneios.Add(torneio);
        }

        internal List<Torneio> ListarTorneios()
        {
            return _torneios;
        }
    }
}
