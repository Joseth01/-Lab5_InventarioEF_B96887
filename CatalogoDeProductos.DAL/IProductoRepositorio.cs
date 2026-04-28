using CatalogoDeProductos.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoDeProductos.DAL
{
    public interface IProductoRepositorio
    {
        List<Producto> ObtengaTodosLosProductos();
        Producto ObtengaElProductoPorId(int id);
        void AgregueElProducto(Producto producto);
        void ActualiceElProducto(Producto producto);
        void ElimineElProducto(int id);
    }
}
