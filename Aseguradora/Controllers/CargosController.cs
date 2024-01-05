using Aseguradora.Data;
using Aseguradora.Models;
using Aseguradora.Services.Backend;
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
        private readonly IAseguradoraService _aseguradoraService;

        public CargosController(IdentityContext context, UserManager<CustomIdentityUser> userManager, SignInManager<CustomIdentityUser> signInManager, IAseguradoraService aseguradoraService)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _aseguradoraService = aseguradoraService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> LoginCargo()
        {
            LoginViewModel model = new LoginViewModel();
            model.PhoneNumber = "2281514468";
            model.Password = "A1G2n3i4zhircon.";
            var response = await _aseguradoraService.LoginAsync(model);
            Console.WriteLine(response.AcessToken);
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginCargoAsync( )
        {
         
            if (ModelState.IsValid)
            {
                try
                {
                    
                }catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View();
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
                   
                } catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
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
