using Microsoft.VisualStudio.TestTools.UnitTesting;
using PedraPapelTesoura.Jogadas;
using PedraPapelTesoura.Torneios;

namespace PedraPapelTesoura.TesteUnitario.Torneio
{
    [TestClass]
    public class TorneioCampeonatoTest
    {
        IJogador jogadorArmando = new Jogador() { NomeJogador = "Armando", TipoJogada = TipoJogada.Papel, GrupoJogada = 01 };
        IJogador jogadorDave = new Jogador() { NomeJogador = "Dave", TipoJogada = TipoJogada.Tesoura, GrupoJogada = 01 };
        IJogador jogadorRichard = new Jogador() { NomeJogador = "Richard", TipoJogada = TipoJogada.Pedra, GrupoJogada = 01 };
        IJogador jogadorMichael = new Jogador() { NomeJogador = "Michael", TipoJogada = TipoJogada.Tesoura, GrupoJogada = 01 };
        IJogador jogadorAllen = new Jogador() { NomeJogador = "Allen", TipoJogada = TipoJogada.Tesoura, GrupoJogada = 02 };
        IJogador jogadorOmer = new Jogador() { NomeJogador = "Omer", TipoJogada = TipoJogada.Papel, GrupoJogada = 02 };
        IJogador jogadorDavidE = new Jogador() { NomeJogador = "David E", TipoJogada = TipoJogada.Pedra, GrupoJogada = 02 };
        IJogador jogadorRichardX = new Jogador() { NomeJogador = "Richard X", TipoJogada = TipoJogada.Papel, GrupoJogada = 02 };

        [TestMethod]
        public void Deve_classificar_Richard_como_vencedor_8_jogadores_2_grupos()
        {
            var campeonato = new TorneioCampeonato();
            campeonato.IncluirJogada(jogadorArmando);
            campeonato.IncluirJogada(jogadorDave);
            campeonato.IncluirJogada(jogadorRichard);
            campeonato.IncluirJogada(jogadorMichael);
            campeonato.IncluirJogada(jogadorAllen);
            campeonato.IncluirJogada(jogadorOmer);
            campeonato.IncluirJogada(jogadorDavidE);
            campeonato.IncluirJogada(jogadorRichardX);
            var vencedor = campeonato.CalcularVencedor();

            Assert.AreEqual(jogadorRichard.NomeJogador, vencedor.NomeJogador);
        }

        [TestMethod]
        public void Deve_classificar_Allen_como_vencedor_4_jogadores_1_grupos()
        {
            var campeonato = new TorneioCampeonato();
            campeonato.IncluirJogada(jogadorAllen);
            campeonato.IncluirJogada(jogadorOmer);
            campeonato.IncluirJogada(jogadorDavidE);
            campeonato.IncluirJogada(jogadorRichardX);
            var vencedor = campeonato.CalcularVencedor();

            Assert.AreEqual(jogadorAllen.NomeJogador, vencedor.NomeJogador);
        }

        [TestMethod]
        public void Deve_classificar_Dave_como_vencedor_4_jogadores_2_grupos()
        {
            var campeonato = new TorneioCampeonato();
            campeonato.IncluirJogada(jogadorArmando);
            campeonato.IncluirJogada(jogadorOmer);
            var vencedor = campeonato.CalcularVencedor();

            Assert.AreEqual(jogadorArmando.NomeJogador, vencedor.NomeJogador);
        }

        [TestMethod]
        public void Deve_classificar_Dave_como_vencedor_2_jogadores_2_grupos()
        {
            var campeonato = new TorneioCampeonato();
            campeonato.IncluirJogada(jogadorDave);
            campeonato.IncluirJogada(jogadorRichardX);
            var vencedor = campeonato.CalcularVencedor();

            Assert.AreEqual(jogadorDave.NomeJogador, vencedor.NomeJogador);
        }

        [TestMethod]
        public void Deve_classificar_primeiro_jogador_quando_empate()
        {
            var campeonato = new TorneioCampeonato();
            campeonato.IncluirJogada(jogadorArmando);
            campeonato.IncluirJogada(jogadorDave);
            campeonato.IncluirJogada(jogadorDavidE);
            campeonato.IncluirJogada(jogadorRichardX);
            var vencedor = campeonato.CalcularVencedor();

            Assert.AreEqual(jogadorDave.NomeJogador, vencedor.NomeJogador);
        }

        [TestMethod]
        public void Deve_incluir_jogadores_participantes()
        {
            byte quantidadeIncluida = 4;

            var campeonato = new TorneioCampeonato();
            campeonato.IncluirJogada(jogadorArmando);
            campeonato.IncluirJogada(jogadorDave);
            campeonato.IncluirJogada(jogadorDavidE);
            campeonato.IncluirJogada(jogadorRichardX);
            
            Assert.AreEqual(quantidadeIncluida, campeonato.QuantidadeJogadoresParticipantes);
            Assert.AreEqual(quantidadeIncluida, campeonato.Jogadores.Count);
        }
    }
}

/*
 * Grupo 01:
 [ ["Armando", "P"], ["Dave", "S"] ],
 [ ["Richard", "R"], ["Michael", "S"] ],

 * Grupo 02:
 [ ["Allen", "S"], ["Omer", "P"] ],
 [ ["David E.", "R"], ["Richard X.", "P"] 

 Letras:
 Rock (R) = Pedra, 
 Paper (P) = Papel e
 Scissors (S) = Tesoura.
*/
