using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp8_2025_pato2003.Interfaces;
using tl2_tp8_2025_pato2003.Models;
using tl2_tp8_2025_pato2003.Repositorios;
using tl2_tp8_2025_pato2003.ViewModels;


namespace tl2_tp8_2025_pato2003.Controllers;

public class ProductoController : Controller
{
    private IProductoRepository _repo;
    private IAuthenticationService _authService;
    public ProductoController(IProductoRepository repo, IAuthenticationService authService)
    {
        _repo = repo;
        _authService = authService;
    }

    public IActionResult Index()
    {
        var check = CheckAdminPermissions();
        if (check != null) return check;

        var listaProductos = _repo.GetProductos();
        return View(listaProductos);
    }

    

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var check = CheckAdminPermissions();
        if (check != null) return check;

        var producto = _repo.GetProductoById(id);

        if (producto==null)
        {
            return NotFound();
        }

        var productoVM = new ProductoViewModel(producto);
        return View(productoVM);
    }

    [HttpPost]
    public IActionResult Edit(ProductoViewModel productoVM)
    {
        if (!ModelState.IsValid)
        {
            return View(productoVM);
        }

        var nuevoProd = new Producto
        {
            IdProducto = productoVM.IdProducto,
            Descripcion = productoVM.Descripcion,
            Precio = productoVM.Precio
        };
        _repo.ModificarProducto(nuevoProd);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Create()
    {
        var check = CheckAdminPermissions();
        if (check != null) return check;
        return View();
    }

    [HttpPost]
    public IActionResult Create(ProductoViewModel productoVM)
    {
        if (!ModelState.IsValid)
        {
            return View(productoVM);
        }

        var nuevoProd = new Producto
        {
            Descripcion = productoVM.Descripcion,
            Precio = productoVM.Precio
        };
        _repo.AltaProducto(nuevoProd);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var check = CheckAdminPermissions();
        if (check != null) return check;

        var producto = _repo.GetProductoById(id);

        if (producto == null)
        {
            return NotFound();
        }
        var productoVM = new ProductoViewModel(producto);

        return View(productoVM);
    }
    [HttpPost,ActionName("Delete")]
    public IActionResult DeleteConfirm(int id)
    {
        _repo.EliminarProducto(id);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult AccesoDenegado()
    {
        return View();
    }


    public IActionResult CheckAdminPermissions()
    {
        if (!_authService.IsAuthentiicated())
        {
            return RedirectToAction("Index","Login");
        }
        if (!_authService.HasAccessLevel("Administrador"))
        {
            return RedirectToAction("AccesoDenegado");
        }
        return null;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}