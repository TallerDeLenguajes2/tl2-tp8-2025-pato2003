using System.ComponentModel.DataAnnotations;
using tl2_tp8_2025_pato2003.Models;
namespace tl2_tp8_2025_pato2003.ViewModels;

public class ProductoViewModel
{
    public ProductoViewModel()
    {
    }

    public ProductoViewModel(Producto producto)
    {
        IdProducto = producto.IdProducto;
        Descripcion = producto.Descripcion;
        Precio = producto.Precio;
    }

        
    public int IdProducto { get; set; }
    [Display(Name ="Descripcion del Producto")]
    [Required(ErrorMessage ="La descripcion es obligatorio")]
    public string Descripcion { get; set; }
    [Display(Name ="Precio Unitario")]
    [Required(ErrorMessage ="El precio es obligatorio")]
    [Range(0.01, double.MaxValue, ErrorMessage ="El precio debe ser un valor positivo")]
    public int Precio { get; set; }
}