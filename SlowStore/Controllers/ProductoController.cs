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
            // Mal rendimiento: carga todos los productos con ToList() y luego filtra
            var productos = _context.Productos.ToList();

            var productosCaros = new List<Producto>();
            foreach (var p in productos)
            {
                if (p.Precio > 1000)
                {
                    productosCaros.Add(p); // lógica ineficiente
                }
            }

            return View(productosCaros);
        }
    }
}
