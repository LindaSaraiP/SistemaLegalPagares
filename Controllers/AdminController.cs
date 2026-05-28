using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SistemaLegalPagares.Models;


[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AdminController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    // LISTA PENDIENTES
    public IActionResult UsuariosPendientes()
    {
        var usuarios = _userManager.Users
            .Where(u => !u.EstaAprobado)
            .ToList();

        return View(usuarios);
    }

    // APROBAR USUARIO
    public async Task<IActionResult> Aprobar(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
            return NotFound();

        user.EstaAprobado = true;

        await _userManager.UpdateAsync(user);
        await _userManager.AddToRoleAsync(user, "Abogado");

        return RedirectToAction(nameof(UsuariosPendientes));
    }

    // RECHAZAR USUARIO
    public async Task<IActionResult> Rechazar(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
            return NotFound();

        await _userManager.DeleteAsync(user);

        return RedirectToAction(nameof(UsuariosPendientes));
    }
}