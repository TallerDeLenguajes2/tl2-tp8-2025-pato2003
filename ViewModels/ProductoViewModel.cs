using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace tl2_tp8_2025_pato2003.ViewModels;

public class ProductoViewModel
{
    public ProductoViewModel()
    {
    }

    public ProductoViewModel(int idProducto, string descripcion, int precio)
    {
        IdProducto = idProducto;
        Descripcion = descripcion;
        Precio = precio;
    }

        
    public int IdProducto { get; set; }
    [Display(Name ="Descripcion del Producto")]
    [StringLength(250,ErrorMessage ="La descripcion no puede superar los 250 caracteres")]
    public string Descripcion { get; set; }
    [Display(Name ="Precio Unitario")]
    [Required(ErrorMessage ="El precio es obligatorio")]
    [Range(0.01, double.MaxValue, ErrorMessage ="El precio debe ser un valor positivo")]
    public int Precio { get; set; }
}