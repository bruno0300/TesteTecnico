using System;
using PedraPapelTesoura.Jogadas;
using PedraPapelTesoura.Torneios;
using System.Text;

namespace PedraPapelTesoura
{
    class Program
    {
        static IJogador jogadorArmando = new Jogadas.Jogador()
        { NomeJogador = "Armando", TipoJogada = TipoJogada.Papel, GrupoJogada = 01 };

       static  IJogador jogadorDave = new Jogadas.Jogador()
        { NomeJogador = "Dave", TipoJogada = TipoJogada.Tesoura, GrupoJogada = 01 };

        static IJogador jogadorRichard = new Jogadas.Jogador()
        { NomeJogador = "Richard", TipoJogada = TipoJogada.Pedra, GrupoJogada = 01 };

        static IJogador jogadorMichael = new Jogadas.Jogador()
        { NomeJogador = "Michael", TipoJogada = TipoJogada.Tesoura, GrupoJogada = 01 };

        static IJogador jogadorAllen = new Jogadas.Jogador()
        { NomeJogador = "Allen", TipoJogada = TipoJogada.Tesoura, GrupoJogada = 02 };

        static IJogador jogadorOmer = new Jogadas.Jogador()
        { NomeJogador = "Omer", TipoJogada = TipoJogada.Papel, GrupoJogada = 02 };

        static IJogador jogadorDavidE = new Jogadas.Jogador()
        { NomeJogador = "David E", TipoJogada = TipoJogada.Pedra, GrupoJogada = 02 };

        static IJogador jogadorRichardX = new Jogadas.Jogador()
        { NomeJogador = "Richard X", TipoJogada = TipoJogada.Papel, GrupoJogada = 02 };

        static void Main(string[] args)
        {
            var composicaoTorneios = new CompositeTorneios();

            Torneio torneioCampeonato = new TorneioCampeonato();
            torneioCampeonato.IncluirJogada(jogadorArmando);
            torneioCampeonato.IncluirJogada(jogadorDave);
            torneioCampeonato.IncluirJogada(jogadorRichard);
            torneioCampeonato.IncluirJogada(jogadorMichael);
            torneioCampeonato.IncluirJogada(jogadorAllen);
            torneioCampeonato.IncluirJogada(jogadorOmer);
            torneioCampeonato.IncluirJogada(jogadorDavidE);
            torneioCampeonato.IncluirJogada(jogadorRichardX);
            
            Torneio torneioDoisJogadores = new TorneioDoisJogadores();
            torneioDoisJogadores.IncluirJogada(jogadorArmando);
            torneioDoisJogadores.IncluirJogada(jogadorDave);

            composicaoTorneios.IncluirTorneio(torneioCampeonato);
            composicaoTorneios.IncluirTorneio(torneioDoisJogadores);

            var vencedores = composicaoTorneios.ComporTorneios();

            StringBuilder mensagem = new StringBuilder();
            mensagem.AppendLine("Vencedor(es):");
            
            foreach (var item in vencedores)
            {
                mensagem.AppendLine("====================================================");
                mensagem.AppendLine(String.Format("Nome: {0}", item.NomeJogador));
                mensagem.AppendLine(string.Format("Tipo jogada: {0}", item.TipoJogada.ToString()));
            }

            Console.Write(mensagem.ToString());
            Console.ReadKey();
        }


    }
}