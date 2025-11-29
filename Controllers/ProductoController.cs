using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using producto;
using tl2_tp8_2025_pato2003.Models;

namespace tl2_tp8_2025_pato2003.Controllers;

public class ProductoController : Controller
{
    private ProductoRepository _repo;
    public ProductoController()
    {
        _repo = new ProductoRepository();
    }

    public IActionResult Index()
    {
        var listaProductos = _repo.GetProductos();
        return View(listaProductos);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var producto = _repo.GetProductoById(id);
        return View(producto);
    }

    [HttpPost]
    public IActionResult Edit(Producto producto)
    {
        _repo.ModificarProducto(producto);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Producto prod)
    {
        _repo.AltaProducto(prod);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var producto = _repo.GetProductoById(id);
        return View(producto);
    }
    [HttpPost]
    public IActionResult Delete(Producto producto)
    {
        _repo.EliminarProducto(producto.IdProducto);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}