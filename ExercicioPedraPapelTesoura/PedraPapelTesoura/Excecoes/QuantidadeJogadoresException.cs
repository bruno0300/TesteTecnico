using System;

namespace PedraPapelTesoura.Excecoes
{
    internal class QuantidadeJogadoresException : Exception
    {
        public QuantidadeJogadoresException(string message) : base(message)
        {
        }
    }
}
