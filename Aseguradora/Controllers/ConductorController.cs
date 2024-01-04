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
    public class ConductorController : Controller
    {
        private readonly IdentityContext _context;
        private readonly UserManager<CustomIdentityUser> _userManager;
        private readonly SignInManager<CustomIdentityUser> _signInManager;

        public ConductorController(IdentityContext context, UserManager<CustomIdentityUser> userManager, SignInManager<CustomIdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult LoginConductor()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginConductorAsync(LoginConductorViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool signInResult = false;
                    //Esta función verifica en la bd que el correo y contraseña sean válidos
                    var result = await _signInManager.PasswordSignInAsync(model.Nombres, model.Password, isPersistent: false, lockoutOnFailure: false);
                    signInResult = result.Succeeded; //Regresa true si es válido

                    if (signInResult)
                    {
                        return RedirectToAction("MenuConductor", "Conductor");
                    }
                    else
                    {
                        //return RedirectToAction("Index", "Home");
                        ModelState.AddModelError("PhoneNumber", "Credenciales no válidas. Inténtelo nuevamente.");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> RegistroConductor(bool creado = false)
        {
            ViewData["creado"] = creado;
            ViewData["RolesSelect"] = new SelectList(await _context.Roles.OrderBy(r => r.Name).AsNoTracking().ToListAsync(), "Name", "Name", null);
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> RegistroConductorAsync(ConductorViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var conductor = await _userManager.FindByNameAsync(model.PhoneNumber);
                    if (conductor == null)
                    {
                        var conductorToCreate = new CustomIdentityUser
                        {
                            Nombres = model.Nombres,
                            ApellidoPaterno = model.ApellidoPaterno,
                            ApellidoMaterno = model.ApellidoMaterno,
                            NumeroDeLicencia = model.NumeroDeLicencia,
                            PhoneNumber = model.PhoneNumber,
                            FechaNacimiento = model.FechaNacimiento,
                            UserName = model.Nombres,
                            NormalizedUserName = model.Nombres.ToUpper(),
                        };
                        IdentityResult result = await _userManager.CreateAsync(conductorToCreate, model.Password);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("RegistroConductor", new { creado = true });
                        }

                        List<IdentityError> errorList = result.Errors.ToList();
                        var errors = string.Join(" ", errorList.Select(e => e.Description));
                        ModelState.AddModelError("Password", errors);
                    }
                    else
                    {
                        ModelState.AddModelError("UserName", $"El usuario {conductor.UserName} ya existe en el sistema");
                    }
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            ViewData["creado"] = false;
            return View();
        }



        public IActionResult AcessDenied()
        {
            return View();
        }
       
        public IActionResult MenuConductor()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> ComprarPoliza(bool creado = false)
        {
            ViewData["creado"] = creado;
            ViewData["RolesSelect"] = new SelectList(await _context.Roles.OrderBy(r => r.Name).AsNoTracking().ToListAsync(), "Name", "Name", null);
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ComprarPolizaAsync(PolizaSeguroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var poliza = await _userManager.FindByNameAsync(model.Placas);
                    if (poliza == null)
                    {
                        var polizaToCreate = new CustomIdentityUser
                        {
                            
                            Serie = model.Serie,
                            Marca = model.Marca,
                            Modelo = model.Modelo,
                            Ano = model.Ano,
                            Color = model.Color,
                            Placas = model.Placas,                         
                        };
                       
                        return RedirectToAction("ComprarPoliza", new { creado = true });
                    }
                    else
                    {
                        ModelState.AddModelError("Placas", $"El usuario {poliza.Placas} ya existe en el sistema");
                    }
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

          
            ViewData["creado"] = false;
            return View(); 
        }

        public async Task<IActionResult> PagarPoliza(bool creado = false)
        {
            ViewData["creado"] = creado;
            ViewData["RolesSelect"] = new SelectList(await _context.Roles.OrderBy(r => r.Name).AsNoTracking().ToListAsync(), "Name", "Name", null);
            return View();
        }

        public IActionResult VerPoliza()
        {
            return View();
        }

        public IActionResult LevantarReporte()
        {
            return View();
        }

        public async Task<IActionResult> VerReportesAsync()
        {
            //Busca si el correo ya existe
            var identityUser = await _userManager.FindByNameAsync(User.Identity.Name);
            

            ConductorViewModel cargo = new()
            {
                Nombres = identityUser.Nombres,
                ApellidoPaterno = identityUser.PhoneNumber,
            };

            return View(cargo);
        }

    }
}
