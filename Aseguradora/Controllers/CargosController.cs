using Aseguradora.Data;
using Aseguradora.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Aseguradora.Controllers
{

    [Authorize]
    public class CargosController : Controller
    {
        private readonly IdentityContext _context;
        private readonly UserManager<CustomIdentityUser> _userManager;
        private readonly SignInManager<CustomIdentityUser> _signInManager;

        public CargosController(IdentityContext context, UserManager<CustomIdentityUser> userManager, SignInManager<CustomIdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [AllowAnonymous]
        public IActionResult LoginCargo()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginCargoAsync(LoginCargoViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    bool signInResult = false;
                    //Esta función verifica en la bd que el correo y contraseña sean válidos
                    var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);
                    signInResult = result.Succeeded; //Regresa true si es válido

                    if (signInResult)
                    {
                        return RedirectToAction("Menu", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("UserName", "Credenciales no válidas. Inténtelo nuevamente.");
                    }
                }catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(model);
        }
        //Este atributo permite que /Cargos/Registro si pueda ser accedido aunque no este loqueado
        [AllowAnonymous]
        public async Task<IActionResult>RegistroCargo(bool creado = false)
        {
            ViewData["creado"] = creado;
            ViewData["RolesSelect"] = new SelectList(await _context.Roles.OrderBy(r => r.Name).AsNoTracking().ToListAsync(), "Name", "Name", null);
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> RegistroCargoAsync(CargoViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var cargo = await _userManager.FindByNameAsync(model.UserName);
                    if(cargo == null)
                    {
                        var cargoToCreate = new CustomIdentityUser
                        {
                            Nombres = model.Nombres,
                            ApellidoPaterno = model.ApellidoPaterno,
                            ApellidoMaterno = model.ApellidoMaterno,
                            FechaIngreso = model.FechaIngreso,
                            UserName = model.UserName,
                            NormalizedUserName = model.UserName.ToUpper(),
                        };
                        IdentityResult result = await _userManager.CreateAsync(cargoToCreate, model.Password);
                        if (result.Succeeded)
                        {
                            await _userManager.AddToRoleAsync(cargoToCreate, model.Rol);
                            return RedirectToAction("RegistroCargo", new { creado = true });
                        }

                        List<IdentityError> errorList = result.Errors.ToList();
                        var errors = string.Join(" ", errorList.Select(e => e.Description));
                        ModelState.AddModelError("Password", errors);
                    }
                    else
                    {
                        ModelState.AddModelError("UserName", $"El usuario {cargo.UserName} ya existe en el sistema");
                    }
                } catch(DbUpdateException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            ViewData["creado"] = false;
            return View();
        }

        public async Task<IActionResult> PerfilCargoAsync()
        {
            //Busca si el correo ya existe
            var identityUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var roles = _userManager.GetRolesAsync(identityUser).Result;
            var rol = string.Join(",", roles);

            CargoViewModel cargo = new()
            {
                Nombres = identityUser.Nombres,
                ApellidoPaterno = identityUser.Email,
                Rol = rol
            };

            return View(cargo);
        }

        public IActionResult LogoutCargo()
        {
            return View();
        }

        public async Task<IActionResult> LogoutCargoAsync(string returnUrl = null)
        {
            //Cierra la sesión
            await _signInManager.SignOutAsync();
            if (returnUrl != null)
            {
                // Si hay una acción a donde regresar, se realiza un redirect
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction("LoginCargo");
            }
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
