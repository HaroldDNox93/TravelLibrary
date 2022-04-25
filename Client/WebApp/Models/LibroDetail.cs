using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class LibroDetail
    {
        public int Isbn { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string N_Paginas { get; set; }
        public string Editorial { get; set; }
        public List<string> Autores { get; set; }
    }
}
