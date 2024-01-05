using Aseguradora.Data;
using Aseguradora.Models;
using Aseguradora.Services.Backend;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Aseguradora.Controllers
{

  
    public class ConductorController : Controller
    {
        private readonly IdentityContext _context;
        private readonly UserManager<CustomIdentityUser> _userManager;
        private readonly SignInManager<CustomIdentityUser> _signInManager;
        private readonly IAseguradoraService _aseguradoraService; //Poner siempre

        public ConductorController(IdentityContext context, UserManager<CustomIdentityUser> userManager, SignInManager<CustomIdentityUser> signInManager, IAseguradoraService aseguradoraService)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _aseguradoraService = aseguradoraService;
        }

        public async Task<IActionResult> VerPoliza()
        {
            LoginViewModel model = new LoginViewModel();
            model.PhoneNumber = "2281514468";
            model.Password = "A1G2n3i4zhircon.";
            var response = await _aseguradoraService.LoginAsync(model);
            Console.WriteLine(response.AcessToken);
            return View();
        }

        [AllowAnonymous]
            public async Task<IActionResult> LoginConductor(LoginViewModel model)
            {
            var response = await _aseguradoraService.LoginAsync(model);
            if (response != null)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, response.Nombre),
                new Claim(ClaimTypes.GivenName, response.Nombre),
                new Claim("token", response.AcessToken),
                new Claim(ClaimTypes.Role,response.rol),
                new Claim(ClaimTypes.Sid, response.Id),
                new Claim("IdConductor", response.IdConductor)
            };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
            }
            //var token = User.FindFirstValue("token");
            //var IdUser = User.FindFirstValue(ClaimTypes.Sid);
            //var IdConductor = User.FindFirstValue("IdConductor");
            //Console.WriteLine(IdUser+" " +IdConductor);
            return View();
            }

        

        [AllowAnonymous]
        public async Task<IActionResult> RegistroConductor(ConductorUserViewModel model, bool creado)
        {
            if (ModelState.IsValid)
            {
                ConductorViewModel conductorViewModel = new ConductorViewModel
                {
                    Id = model.Id,
                    UserId = model.UserId,
                    Nombres = model.Nombres,
                    ApellidoPaterno = model.ApellidoPaterno,
                    ApellidoMaterno = model.ApellidoMaterno,
                    Nombrecompleto = model.Nombres + ' ' + model.ApellidoPaterno + ' ' + model.ApellidoMaterno,
                    Licencia = model.Licencia,
                    Edad = model.Edad
                };
                SignInViewModel signInViewModel = new SignInViewModel
                {
                    UserName = model.Nombres.ToString(),
                    Email = "sinemail@gmail.com",
                    PasswordHash = model.PasswordHash.ToString(),
                    PhoneNumber = model.PhoneNumber.ToString(),
                    Nombre = model.Nombres.ToString(),
                    Roles = new List<String> { "Usuario General" },
                };
                var responseSingIn = await _aseguradoraService.SignInAsync(signInViewModel);
                var responseLogin = await _aseguradoraService.LoginAsync(new LoginViewModel { PhoneNumber = signInViewModel.PhoneNumber, Password = signInViewModel.PasswordHash });
                conductorViewModel.UserId = responseSingIn.UsuarioId;
                var response = await _aseguradoraService.PostConductorAsync(conductorViewModel);
                Console.WriteLine(conductorViewModel.Nombres);
                Console.WriteLine(conductorViewModel.ApellidoPaterno);
                Console.WriteLine(conductorViewModel.ApellidoMaterno);
                Console.WriteLine(conductorViewModel.Licencia);
                Console.WriteLine(conductorViewModel.Edad);
               
                if (response != null)
                {
                    creado = true;
                }
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]





        public IActionResult AcessDenied()
        {
            return View();
        }

        public async Task <IActionResult> MenuConductor(LoginViewModel model)
        {
            
            //var response = await _aseguradoraService.LoginAsync(model);
            //Console.WriteLine(response.AcessToken);
            return View();
        }

        [Authorize]
        public async Task<IActionResult> ComprarPoliza(bool creado = false)
        {
            ViewData["creado"] = creado;
            ViewData["RolesSelect"] = new SelectList(await _context.Roles.OrderBy(r => r.Name).AsNoTracking().ToListAsync(), "Name", "Name", null);
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ComprarPolizaAsync(PolizaSeguroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
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
              
            };

            return View(cargo);
        }



    }
}
