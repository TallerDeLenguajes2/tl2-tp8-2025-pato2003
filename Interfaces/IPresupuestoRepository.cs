using presupuesto;
public interface IPresupuestoRepository
{
    Presupuesto GetPresupuestoById(int idPresupuesto);
    List<Presupuesto> GetPresupuestos();
    void AltaPresupuesto(Presupuesto presupuestoNuevo);
    void ModificarPresupuesto(Presupuesto presupuestoModificado);
    void EliminarPresupuesto(int idPresupuesto);

}