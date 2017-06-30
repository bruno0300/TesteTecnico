using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PedraPapelTesoura.Jogadas;
using PedraPapelTesoura.Excecoes;

namespace PedraPapelTesoura.Funcoes
{
    class ConversorJogadas
    {
        private readonly Dictionary<string, TipoJogada> _tiposJogadas = new Dictionary<string, TipoJogada>()
        {
            { "R", TipoJogada.Pedra },
            { "S", TipoJogada.Tesoura },
            { "P", TipoJogada.Papel }

        };

        public List<IJogador> Converter(string jogadas)
        {
            jogadas = jogadas.Trim();
            RetirarQuebraLinha(ref jogadas);

            var separador = jogadas.Split(',');
            //int quantidadeGrupos = separador.ToList().ToString().Split(']').Count();
            List<IJogador> jogadores = new List<IJogador>();
            int grupoJogada = 1;

            //List<string> teste = separador.ToList();
            int i = 0;

            do
            {
                if (separador[i].Equals("]"))
                {
                    grupoJogada++;
                    i++;
                }
                else
                {
                    string nomeJogador = separador[i].Replace("[", String.Empty).Replace("]", String.Empty).Replace("'", String.Empty);
                    string letraJogada = separador[i + 1].Replace("[", String.Empty).Replace("]", String.Empty).Replace("'", String.Empty);

                    var jogador = new Jogador();
                    jogador.NomeJogador = nomeJogador;
                    jogador.GrupoJogada = grupoJogada;
                    try
                    {
                        TipoJogada tipoJogada = _tiposJogadas[letraJogada];
                        jogador.TipoJogada = tipoJogada;
                    }
                    catch
                    {
                        throw new TipoJogadaInvalidaException("Tipo de jogada inválida! Inclua 'R' para Pedra, 'S' para Tesoura ou 'P' para Papel.");
                    }

                    jogadores.Add(jogador);
                    i += 2;
                }

            } while (i < separador.Count());

            //for (int i = 0; i < separador.Count(); i += 2)
            //{
            //    if (separador[i].Equals("]"))
            //    {
            //        grupoJogada++;
            //        i++;
            //    }
            //    else
            //    {
            //        string nomeJogador = separador[i].Replace("[", String.Empty).Replace("]", String.Empty).Replace("'", String.Empty);
            //        string letraJogada = separador[i + 1].Replace("[", String.Empty).Replace("]", String.Empty).Replace("'", String.Empty);

            //        var jogador = new Jogador();
            //        jogador.NomeJogador = nomeJogador;
            //        jogador.GrupoJogada = grupoJogada;
            //        try
            //        {
            //            TipoJogada tipoJogada = _tiposJogadas[letraJogada];
            //            jogador.TipoJogada = tipoJogada;
            //        }
            //        catch
            //        {
            //            throw new TipoJogadaInvalidaException("Tipo de jogada inválida! Inclua 'R' para Pedra, 'S' para Tesoura ou 'P' para Papel.");
            //        }

            //        jogadores.Add(jogador);
            //    }
            //}

            return jogadores;
        }

        private void RetirarQuebraLinha(ref string texto)
        {
            texto = string.Join("", Regex.Split(texto, @"(?:\r\n|\n|\r)")).Replace(" ", "").Replace("\t", "");
        }

        private void RemoverPrimeiroEUltimoColchete(ref string texto)
        {
            texto = texto.Substring(1, texto.Length - 1);
        }

    }
}