using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp8_2025_pato2003.Models;
using tl2_tp8_2025_pato2003.Repositorios;

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
    public IActionResult Create(Presupuesto presupuesto)
    {
        _repo.AltaPresupuesto(presupuesto);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var presupuesto = _repo.GetPresupuestoById(id);
        return View(presupuesto);
    }

    [HttpPost]
    public IActionResult Edit(Presupuesto presupuesto)
    {
        _repo.AltaPresupuesto(presupuesto);
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

    [HttpPost]
    public IActionResult DeleteConfirm(int id)
    {
        _repo.EliminarPresupuesto(id);
        return RedirectToAction("Index");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}