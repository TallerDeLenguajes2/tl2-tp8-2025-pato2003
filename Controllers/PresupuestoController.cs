using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using tl2_tp8_2025_pato2003.Models;
using tl2_tp8_2025_pato2003.Repositorios;
using tl2_tp8_2025_pato2003.ViewModels;

namespace tl2_tp8_2025_pato2003.Controllers;

public class PresupuestoController : Controller
{
    private PresupuestoRepository _repo;
    private ProductoRepository _prodRepo;
    public PresupuestoController()
    {
        _repo = new PresupuestoRepository();
        _prodRepo = new ProductoRepository();
    }

    [HttpGet]
    public IActionResult Index()
    {
        var listaPresupuestos = _repo.GetPresupuestos();
        return View(listaPresupuestos);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(PresupuestoViewModel presupuestoVM)
    {
        if (!ModelState.IsValid)
        {
            return View(presupuestoVM);
        }

        Presupuesto presupuestoNuevo = new Presupuesto
        {
            NombreDestinatario = presupuestoVM.NombreDestinatario,
            FechaCreacion = presupuestoVM.FechaCreacion

        };

        _repo.AltaPresupuesto(presupuestoNuevo);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var presupuesto = _repo.GetPresupuestoById(id);

        if (presupuesto==null)
        {
            return View(presupuesto);
        }

        var presupuestoVM = new PresupuestoViewModel(presupuesto);
        return View(presupuestoVM);
    }

    [HttpPost]
    public IActionResult Edit(PresupuestoViewModel presupuestoVM)
    {
        if (!ModelState.IsValid)return NotFound();

        if (presupuestoVM.FechaCreacion >  DateOnly.FromDateTime(DateTime.Now))
        {
            ModelState.AddModelError("Fecha de Creacion", "La fecha de creacion no puede ser una fecha futura");
        }

        var presupuesto = new Presupuesto
        {
            IdPresupuesto = presupuestoVM.IdPresupuesto,
            NombreDestinatario = presupuestoVM.NombreDestinatario,
            FechaCreacion = presupuestoVM.FechaCreacion
        };

        _repo.ModificarPresupuesto(presupuesto);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var presupuesto = _repo.GetPresupuestoById(id);
        return View(presupuesto);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var presupuesto = _repo.GetPresupuestoById(id);
        return View(presupuesto);
    }

    [HttpPost,ActionName("Delete")]
    public IActionResult DeleteConfirm(int id)
    {
        _repo.EliminarPresupuesto(id);
        return RedirectToAction("Index");
    }


    [HttpGet]
    public IActionResult AgregarProducto(int id)
    {
        List<Producto> listaProductos = _prodRepo.GetProductos();

        AgregarProductoViewModel model = new AgregarProductoViewModel
        {
            IdPresupuesto = id,
            ListaProductos = new SelectList(listaProductos,"IdProducto", "Descripcion")
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult AgregarProducto(AgregarProductoViewModel model)
    {
        if (!ModelState.IsValid)
        {
            var productos = _prodRepo.GetProductos();
            model.ListaProductos = new SelectList(productos, "IdProducto", "Descripcion");
            return View(model);
        }

        _repo.AgregarDetallePresupuesto(model.IdPresupuesto, model.IdProducto, model.Cantidad);
        return RedirectToAction("Details", new {id=model.IdPresupuesto});
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}