using CatalogoDeProductos.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoDeProductos.DAL
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly AppDbContext _contexto;

        public ProductoRepositorio(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public List<Producto> ObtengaTodosLosProductos()
        {
            return _contexto.Productos.ToList();
        }

        public Producto ObtengaElProductoPorId(int id)
        {
            return _contexto.Productos.FirstOrDefault(p => p.Id == id);
        }

        public void AgregueElProducto(Producto producto)
        {
            _contexto.Productos.Add(producto);
            _contexto.SaveChanges();
        }

        public void ActualiceElProducto(Producto producto)
        {
            _contexto.Productos.Update(producto);
            _contexto.SaveChanges();
        }

        public void ElimineElProducto(int id)
        {
            var producto = ObtengaElProductoPorId(id);
            if (producto != null)
            {
                _contexto.Productos.Remove(producto);
                _contexto.SaveChanges();
            }
        }
    }
}
