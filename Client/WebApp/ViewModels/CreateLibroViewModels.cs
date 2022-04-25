using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.ViewModels
{
    public class CreateLibroViewModels
    {
        public List<SelectEntity> Autores { get; set; }
        public List<SelectEntity> Editoriales { get; set; }
        public Libro Libro { get; set; }
    }
}
