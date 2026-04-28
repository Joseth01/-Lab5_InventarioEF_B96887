using CatalogoDeProductos.BL;
using CatalogoDeProductos.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoDeProductos.Web.Controllers
{
    public class ProductosController : Controller
    {
        private readonly GestorProductos _gestorProductos;

        public ProductosController(GestorProductos gestorProductos)
        {
            _gestorProductos = gestorProductos;
        }

        // GET: ProductosController
        public ActionResult Index()
        {
            var listaDeProductos = _gestorProductos.ObtengaTodosLosProductos();

            return View(listaDeProductos);
        }

        // GET: ProductosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producto producto)
        {
            if (!ModelState.IsValid)
                return View(producto);

            try
            {
                _gestorProductos.AgregueElProducto(producto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(producto);
            }
        }

        // GET: ProductosController/Edit/5
        public ActionResult Edit(int id)
        {
            var producto = _gestorProductos.ObtengaElProductoPorId(id);

            if (producto == null)
                return NotFound();

            return View(producto);
        }

        // POST: ProductosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Producto producto)
        {
            if (id != producto.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(producto);

            try
            {
                _gestorProductos.ActualiceElProducto(producto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(producto);
            }
        }

        // GET: ProductosController/Delete/5
        public ActionResult Delete(int id)
        {
            var producto = _gestorProductos.ObtengaElProductoPorId(id);

            if (producto == null)
                return NotFound();
            return View(producto);
        }

        // POST: ProductosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _gestorProductos.ElimineElProducto(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
