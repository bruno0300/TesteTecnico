using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PedraPapelTesoura.Jogadas;
using PedraPapelTesoura.Torneios;

namespace PedraPapelTesoura.TesteUnitario.Jogadas
{
    [TestClass]
    public class CompositeTorneiosTest
    {
        IJogador jogadorPapel = new Jogador() { NomeJogador = "Papel", TipoJogada = TipoJogada.Papel, GrupoJogada = 01 };
        IJogador jogadorTesoura = new Jogador() { NomeJogador = "Tesoura", TipoJogada = TipoJogada.Tesoura, GrupoJogada = 01 };

        private CompositeTorneios _composite = new CompositeTorneios();

        [TestMethod]
        public void Deve_incluir_torneios()
        {
            byte quantidadeTorneio = 2;

            var torneioCampeonato = new TorneioCampeonato();
            torneioCampeonato.IncluirJogada(jogadorPapel);
           
            var torneioDoisJogadores = new TorneioDoisJogadores();
            torneioDoisJogadores.IncluirJogada(jogadorTesoura);

            _composite.IncluirTorneio(torneioCampeonato);
            _composite.IncluirTorneio(torneioDoisJogadores);

            Assert.AreEqual(quantidadeTorneio, _composite.ListarTorneios().Count);
        }

        [TestMethod]
        public void Deve_compor_torneios()
        {
            var torneioCampeonato = new TorneioCampeonato();
            torneioCampeonato.IncluirJogada(jogadorPapel);
            torneioCampeonato.IncluirJogada(jogadorTesoura);

            var torneioDoisJogadores = new TorneioDoisJogadores();
            torneioDoisJogadores.IncluirJogada(jogadorPapel);
            torneioDoisJogadores.IncluirJogada(jogadorTesoura);

            _composite.IncluirTorneio(torneioCampeonato);
            _composite.IncluirTorneio(torneioDoisJogadores);

            var vencedores = _composite.ComporTorneios();

            Assert.AreEqual(jogadorTesoura.NomeJogador, vencedores[0].NomeJogador);
            Assert.AreEqual(jogadorTesoura.NomeJogador, vencedores[1].NomeJogador);
        }

        [TestMethod]
        public void Deve_listar_torneios()
        {
            var torneioCampeonato = new TorneioCampeonato();
            torneioCampeonato.IncluirJogada(jogadorPapel);
            _composite.IncluirTorneio(torneioCampeonato);
            
            Assert.AreEqual(torneioCampeonato, _composite.ListarTorneios()[0]);
        }
    }
}
