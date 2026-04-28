using CatalogoDeProductos.Model;
using CatalogoDeProductos.DAL;
namespace CatalogoDeProductos.BL
{
    public class GestorProductos
    {
        private readonly IProductoRepositorio _productoRepositorio;

        public GestorProductos(IProductoRepositorio productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
        }

        public List<Producto> ObtengaTodosLosProductos()
        {
            return _productoRepositorio.ObtengaTodosLosProductos();
        }

        public Producto ObtengaElProductoPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El id del producto no es válido");

            return _productoRepositorio.ObtengaElProductoPorId(id);
        }

        public void AgregueElProducto(Producto producto)
        {
            if (producto == null)
                throw new ArgumentException("El producto no puede ser nulo");

            if (string.IsNullOrWhiteSpace(producto.Nombre))
                throw new ArgumentException("El nombre del producto es obligatorio");

            if (producto.Precio <= 0)
                throw new ArgumentException("El precio debe ser mayor a 0");

            _productoRepositorio.AgregueElProducto(producto);
        }

        public void ActualiceElProducto(Producto producto)
        {
            if (producto == null)
                throw new ArgumentException("El producto no puede ser nulo");

            if (producto.Id <= 0)
                throw new ArgumentException("El id del producto no es válido");

            _productoRepositorio.ActualiceElProducto(producto);
        }

        public void ElimineElProducto(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El id del producto no es válido");

            _productoRepositorio.ElimineElProducto(id);
        }
    }
}
