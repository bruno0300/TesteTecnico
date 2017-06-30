using Microsoft.VisualStudio.TestTools.UnitTesting;
using PedraPapelTesoura.Jogadas;
using PedraPapelTesoura.Torneios;
using PedraPapelTesoura.Excecoes;

namespace PedraPapelTesoura.TesteUnitario.Torneio
{
    [TestClass]
    public class TorneioDoisJogadoresTest
    {
        IJogador jogadorArmando = new Jogador() { NomeJogador = "Armando", TipoJogada = TipoJogada.Papel, GrupoJogada = 01 };
        IJogador jogadorDave = new Jogador() { NomeJogador = "Dave", TipoJogada = TipoJogada.Tesoura, GrupoJogada = 01 };
        IJogador jogadorRichard = new Jogador() { NomeJogador = "Richard", TipoJogada = TipoJogada.Papel, GrupoJogada = 01 };
        IJogador jogadorDavidE = new Jogador() { NomeJogador = "David E", TipoJogada = TipoJogada.Pedra, GrupoJogada = 02 };

        [TestMethod]
        public void Deve_classificar_Dave_como_vencedor()
        {
            var campeonato = new TorneioDoisJogadores();
            campeonato.IncluirJogada(jogadorArmando);
            campeonato.IncluirJogada(jogadorDave);
            var vencedor = campeonato.CalcularVencedor();

            Assert.AreEqual(jogadorDave.NomeJogador, vencedor.NomeJogador);
        }
        
        [TestMethod, ExpectedException(typeof(QuantidadeJogadoresException))]
        public void Deve_retornar_excecao_numeroJogadores_acima_capacidade()
        {
            var campeonato = new TorneioDoisJogadores();
            campeonato.IncluirJogada(jogadorArmando);
            campeonato.IncluirJogada(jogadorDave);
            campeonato.IncluirJogada(jogadorRichard);
            var vencedor = campeonato.CalcularVencedor();
        }

        [TestMethod, ExpectedException(typeof(QuantidadeJogadoresException))]
        public void Deve_retornar_excecao_quantidade_jogadores_diferente_capacidade()
        {
            var campeonato = new TorneioDoisJogadores();
            campeonato.IncluirJogada(jogadorArmando);
            var vencedor = campeonato.CalcularVencedor();
        }
        
        [TestMethod]
        public void Deve_incluir_jogador_na_lista_e_ocupar_capacidade()
        {
            byte quantidadeIncluida = 2;

            var campeonato = new TorneioDoisJogadores();
            campeonato.IncluirJogada(jogadorArmando);
            campeonato.IncluirJogada(jogadorDave);

            Assert.AreEqual(quantidadeIncluida, campeonato.QuantidadeJogadoresParticipantes);
            Assert.AreEqual(quantidadeIncluida, campeonato.Jogadores.Count);
        }
    }
}
