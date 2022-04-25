using WebApp.Models;
using WebApp.Models.Common;

namespace WebApp.ViewModels
{
    public class IndexViewModels
    {
        public PaginatedList<LibroPaged> Libros { get; set; }
    }
}
