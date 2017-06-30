using System;

namespace PedraPapelTesoura.Excecoes
{
    class TipoJogadaInvalidaException : Exception
    {
        public TipoJogadaInvalidaException(string message) : base(message)
        {
        }
    }
}
