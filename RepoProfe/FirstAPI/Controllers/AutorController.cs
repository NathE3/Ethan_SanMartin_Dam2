using FirstAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace FirstAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutorController : Controller
    {
        private readonly ILogger<AutorDTO> _logger;

        private static List<AutorDTO> Libros = new List<AutorDTO>()
        {
            new AutorDTO
            {
                Tlf="123456",
                Nombre="Ethan",
                NumPaginas=200,
                Titulo="Pocahontas"
            },
            new AutorDTO
            {
                ISBN="6666",
                Id=2,
                NumPaginas=3509,
                Titulo="El libro de la selva"
            }
        };

        public LibroController(ILogger<LibroDTO> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAllElement")]
        public IEnumerable<LibroDTO> Get()
        {
            return Libros;
        }

        [HttpGet("{id}")]
        public LibroDTO GetOne(int id)
        {
            return Libros.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public LibroDTO Post([FromBody] LibroDTO libro)
        {
            if (Libros.Any(x => x.Id == libro.Id))
            {
                return null;
            }
            Libros.Add(libro);
            return libro;
        }

        [HttpPut("{id}")]
        public LibroDTO Put([FromBody] LibroDTO libro, int id)
        {
            if (id != libro?.Id)
            {
                return null;
            }
            LibroDTO? libroBBDD = Libros.FirstOrDefault(x => x.Id == libro.Id);
            if (libroBBDD == null)
            {
                return null;
            }
            libroBBDD.ISBN = libro.ISBN;
            libroBBDD.NumPaginas = libro.NumPaginas;
            libroBBDD.Titulo = libro.Titulo;
            return libroBBDD;
        }

        [HttpDelete("{id}")]
        public bool Remove(int id)
        {
            LibroDTO? libroBBDD = Libros.FirstOrDefault(x => x.Id == id);
            if (libroBBDD == null)
            {
                return false;
            }
            return Libros.Remove(libroBBDD);
        }
    }
}
