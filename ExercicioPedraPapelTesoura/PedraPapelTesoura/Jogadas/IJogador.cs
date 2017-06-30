namespace PedraPapelTesoura.Jogadas
{
    internal interface IJogador
    {
        string NomeJogador { get; set; }
        TipoJogada TipoJogada { get; }
        int GrupoJogada { get; set; }
    }
}