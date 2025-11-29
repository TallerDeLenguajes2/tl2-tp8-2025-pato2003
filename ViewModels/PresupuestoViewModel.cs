using System.ComponentModel.DataAnnotations;
using System.Timers;

namespace tl2_tp8_2025_pato2003.ViewModels;


public class PresupuestoViewModel
{
    public PresupuestoViewModel()
    {
    }

    public PresupuestoViewModel(int idPresupuesto, string nombreDestinatario, DateOnly fechaCreacion)
    {
        IdPresupuesto = idPresupuesto;
        NombreDestinatario = nombreDestinatario;
        FechaCreacion = fechaCreacion;
    }

    
    public int IdPresupuesto{ get; set; }
    [Display(Name ="Email del Destinatario")]
    [Required(ErrorMessage ="El email del destinatario es obligatorio")]
    [EmailAddress(ErrorMessage ="El formato del email no es valido")]
    public string NombreDestinatario{ get; set; }
    [Display(Name ="Fecha de Creacion")]
    [Required(ErrorMessage ="La fecha de generacion es obligatoria")]
    [DataType(DataType.Date)]
    public DateOnly FechaCreacion{ get; set; }
}