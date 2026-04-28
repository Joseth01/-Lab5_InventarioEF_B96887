using System.ComponentModel.DataAnnotations;

namespace CatalogoDeProductos.Model
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(1, 9999999, ErrorMessage = "El precio debe estar entre 1 y 9,999,999")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria")]
        public string Categoria { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaIngreso { get; set; } = DateTime.Now;
    }
}
