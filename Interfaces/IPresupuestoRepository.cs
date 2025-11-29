using tl2_tp8_2025_pato2003.Models;

namespace tl2_tp8_2025_pato2003.Interfaces;
public interface IPresupuestoRepository
{
    Presupuesto GetPresupuestoById(int idPresupuesto);
    List<Presupuesto> GetPresupuestos();
    void AltaPresupuesto(Presupuesto presupuestoNuevo);
    void ModificarPresupuesto(Presupuesto presupuestoModificado);
    void EliminarPresupuesto(int idPresupuesto);

}