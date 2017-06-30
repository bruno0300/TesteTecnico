namespace PedraPapelTesoura.Jogadas
{
    class Jogador : IJogador
    {
        public string NomeJogador { get; set; }
        public TipoJogada TipoJogada { get; set; }
        public int GrupoJogada { get; set; }

    }
}
