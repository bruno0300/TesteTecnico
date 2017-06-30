using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PedraPapelTesoura.Funcoes;
using PedraPapelTesoura.Jogadas;

namespace PedraPapelTesoura.TesteUnitario.Funcoes
{
    [TestClass]
    public class ExecutorRodadaTest
    {
        private ExecutorRodada executorRodada = new ExecutorRodada();
        IJogador jogadorPapel = new Jogador() { NomeJogador = "Papel", TipoJogada = TipoJogada.Papel, GrupoJogada = 01 };
        IJogador jogadorTesoura = new Jogador() { NomeJogador = "Tesoura", TipoJogada = TipoJogada.Tesoura, GrupoJogada = 01 };
        IJogador jogadorPedra = new Jogador() { NomeJogador = "Pedra", TipoJogada = TipoJogada.Pedra, GrupoJogada = 01 };
       
        [TestMethod]
        public void Pedra_deve_ganhar_de_tesoura()
        {
            var vencedor = executorRodada.RealizarJogada(jogadorPedra, jogadorTesoura);

            Assert.AreEqual(jogadorPedra.NomeJogador, vencedor.NomeJogador);
        }

        [TestMethod]
        public void Papel_deve_ganhar_de_pedra()
        {
            var vencedor = executorRodada.RealizarJogada(jogadorPedra, jogadorPapel);

            Assert.AreEqual(jogadorPapel.NomeJogador, vencedor.NomeJogador);
        }

        [TestMethod]
        public void Tesoura_deve_ganhar_de_papel()
        {
            var vencedor = executorRodada.RealizarJogada(jogadorTesoura, jogadorPapel);

            Assert.AreEqual(jogadorTesoura.NomeJogador, vencedor.NomeJogador);
        }

        [TestMethod]
        public void Deve_classificar_primeiro_jogador_quando_empate()
        {
            var vencedor = executorRodada.RealizarJogada(jogadorTesoura, jogadorPapel);

            Assert.AreEqual(jogadorTesoura.NomeJogador, vencedor.NomeJogador);
        }   
    }
}
