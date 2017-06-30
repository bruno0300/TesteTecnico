using Microsoft.VisualStudio.TestTools.UnitTesting;
using PedraPapelTesoura.Funcoes;
using PedraPapelTesoura.Jogadas;

namespace PedraPapelTesoura.TesteUnitario.Funcoes
{
    [TestClass]
    public class ConversorJogadasTest
    {
        IJogador jogadorArmando = new Jogador() { NomeJogador = "Armando", TipoJogada = TipoJogada.Papel, GrupoJogada = 1 };
        IJogador jogadorDave = new Jogador() { NomeJogador = "Dave", TipoJogada = TipoJogada.Tesoura, GrupoJogada = 1 };

        [TestMethod]
        public void Deve_retornar_jogadas_Armando_Dave()
        {
            string jogadores = @"[['Armando', 'P'], ['Dave', 'S']]";
            byte quantidadeJogadas = 2;

            var conversorJogadas = new ConversorJogadas();
            var jogadas = conversorJogadas.Converter(jogadores);
            
            Assert.AreEqual(jogadorArmando.NomeJogador, jogadas[0].NomeJogador);
            Assert.AreEqual(jogadorArmando.TipoJogada, jogadas[0].TipoJogada);
            Assert.AreEqual(jogadorDave.NomeJogador, jogadas[1].NomeJogador);
            Assert.AreEqual(jogadorDave.TipoJogada, jogadas[1].TipoJogada);
            Assert.IsTrue(quantidadeJogadas == jogadas.Count);
        }

        [TestMethod]
        public void Deve_retornar_jogadores_campeonato()
        {
            string campeonato = "[ [ [ ['Armando', 'P'], ['Dave', 'S'] ], [ ['Richard', 'R'], ['Michael', 'S'] ], ], [ [ ['Allen', 'S'], ['Omer', 'P'] ], [ ['David E.', 'R'], ['Richard X.', 'P'] ] ] ]";
            byte quantidadeJogadas = 8;

            var conversorJogadas = new ConversorJogadas();
            var jogadas = conversorJogadas.Converter(campeonato);

            Assert.AreEqual(jogadorArmando.NomeJogador, jogadas[0].NomeJogador);
            Assert.AreEqual(jogadorArmando.TipoJogada, jogadas[0].TipoJogada);
            Assert.AreEqual(jogadorDave.NomeJogador, jogadas[1].NomeJogador);
            Assert.AreEqual(jogadorDave.TipoJogada, jogadas[1].TipoJogada);
            Assert.IsTrue(quantidadeJogadas == jogadas.Count);
        }
    }
}
