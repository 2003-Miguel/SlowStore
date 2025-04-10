using Microsoft.AspNetCore.Mvc;
using SlowStore.DataContext;
using SlowStore.Models;

namespace SlowStore.Controllers
{
    public class ProductoController : Controller
    {
        private readonly AppDbContext _context;

        public ProductoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Consulta optimizada: filtra y pagina directamente en la base de datos
            var productosCaros = _context.Productos
                .Where(p => p.Precio > 1000)
                .OrderBy(p => p.Id) // Recomendado para paginación consistente
                .Skip(0)
                .Take(10)
                .ToList();

            return View(productosCaros);
        }
    }
}
