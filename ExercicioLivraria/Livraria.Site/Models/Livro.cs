using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Livraria.Site.Models
{
    public class Livro
    {
        public virtual Guid Id { get; set; }
        public virtual string Titulo { get; set; }
        public virtual string Autor { get; set; }
        public virtual string Genero { get; set; }
        public virtual string Editora { get; set; }
        public virtual int Estoque { get; set; }
        public virtual int Ano { get; set; }
    }
}