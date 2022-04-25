using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp.Helpers;
using WebApp.Models;
using WebApp.Models.Common;

namespace WebApp.Services
{
    public class ServerApiService
    {
        public static async Task<int> CreateLibro(Libro libro)
        {
            var resp = await RequestHttp.CallMethod<int>
                ("ServerApi", "createLibro", HttpMethod.Post, RequestHttp.TypeBody.Body, libro);
            return resp;
        }

        public static async Task<LibroDetail> GetLibroById(int id)
        {
            var entity = await RequestHttp.CallMethod<LibroDetail>
                ("ServerApi", "getLibroById", HttpMethod.Get, id);
            return entity;
        }

        public static async Task<PaginatedList<LibroPaged>> GetLibros(int page)
        {
            var model = new PagedRequest()
            {
                PageNumber = page.ToString()
            };
            var list = await RequestHttp.CallMethod<PaginatedList<LibroPaged>>
                ("ServerApi", "getLibros", HttpMethod.Get, RequestHttp.TypeBody.Query, model);
            return list;
        }

        public static async Task<List<SelectEntity>> GetAutores()
        {
            var list = await RequestHttp.CallMethod<Response<List<SelectEntity>>>
                ("ServerApi", "getAutores", HttpMethod.Get);
            return list.Data;
        }

        public static async Task<List<SelectEntity>> GetEditoriales()
        {
            var list = await RequestHttp.CallMethod<Response<List<SelectEntity>>>
                ("ServerApi", "getEditoriales", HttpMethod.Get);
            return list.Data;
        }
    }
}
