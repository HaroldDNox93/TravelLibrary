using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<SelectEntity> autoresList;
        private List<SelectEntity> editorialesList;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var libros = await ServerApiService.GetLibros(page);
            var model = new IndexViewModels()
            {
                Libros = libros
            };
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            autoresList = await ServerApiService.GetAutores();
            editorialesList = await ServerApiService.GetEditoriales();
            var model = new CreateLibroViewModels()
            {
                Autores = autoresList,
                Editoriales = editorialesList
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Libro libro)
        {
            if (!Int32.TryParse(libro.N_Paginas, out var x))
                ModelState.AddModelError("N_Paginas", "El número de paginas debe ser un número.");

            if (libro.EditorialId <= 0) 
                ModelState.AddModelError("EditorialId","Editorial no valida.");

            if(libro.AutoresId == null || libro.AutoresId.Count == 0)
                ModelState.AddModelError("AutoresId", "Se requiere minimo un autor.");

            if (ModelState.IsValid)
            {
                var resp = await ServerApiService.CreateLibro(libro);
                return RedirectToAction("Detail", new { id = resp });

            }
            
            var model = new CreateLibroViewModels()
            {
                Autores = autoresList,
                Editoriales = editorialesList,
                Libro = libro
            };
            return View(model);
        }

        public async Task<IActionResult> Detail(int id)
        {
            if (id == 0) return NotFound();
            var libro = await ServerApiService.GetLibroById(id);
            return View(libro);
        }

        public IActionResult _Pagination()
        {
            return PartialView();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
