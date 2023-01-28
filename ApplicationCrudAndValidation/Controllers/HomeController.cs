using ApplicationCrudAndValidation.Context;
using ApplicationCrudAndValidation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace ApplicationCrudAndValidation.Controllers
{
    public class HomeController : Controller
    {
        public readonly AppContextDb _context;

        public HomeController(AppContextDb context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        //Este metodo de crear nuevo me lleva a la vista para poder crear un nuevo plato
        public IActionResult CrearNuevo()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task <IActionResult> RestaurantMenu()
        {
            return View(await _context.MenuData.ToListAsync());
        }

        //Este metodo de crear se encarga de guardarme el plato en la base de datos
        
        public async Task<IActionResult> Crear(MenuData menuData)
        {
            if(ModelState.IsValid)
            {
                _context.MenuData.Add(menuData);
                await _context.SaveChangesAsync();
                return RedirectToAction("RestaurantMenu");
            }
            return View(menuData);
            
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dishId = await _context.MenuData.FindAsync(id);
            if(dishId == null)
            {
                return NotFound();
            }

            _context.MenuData.Remove(dishId);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("RestaurantMenu");
        }

        //Metodo de editar
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var editDish = _context.MenuData.Find(id);
            if(editDish == null)
            {
                return NotFound();
            }
            return View(editDish);
        }

        //Este metodo se encarga de crear un nuevo usuario
        public async Task<IActionResult> Edit(MenuData menuData)
        {
            if (ModelState.IsValid)
            {
                _context.Update(menuData);
                await _context.SaveChangesAsync();
                return RedirectToAction("RestaurantMenu");
            }
            return View();
        }

        //Con este controlador se recibe la informacion desde javascript y se valida si existe el usuario en la base de datos

        [HttpPost]
        public async Task<IActionResult> RegisterUser(Users users)
        {
            if (ModelState.IsValid && users != null)
            {

                bool emailExist = _context.Users.Any(u => u.Email == users.Email);
                if (emailExist)
                {
                    ViewBag.ErrorMessage = "El usuario ya se encuentra registrado!";
                    return View("Index");
                }
                else
                {
                    _context.Users.Add(users);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("RestaurantMenu");
                } 
            }
            else
            {
                return View("Index");
            }
        }

        //Metodo para poder iniciar sesion
        [HttpPost]
        public async Task<IActionResult> LogIn(Users users)
        {
            var userLogin = _context.Users.FirstOrDefault(u => u.Email == users.Email && u.Password == users.Password);
            
            if (userLogin != null)
            {
                var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, userLogin.Email)
                };

                var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("RestaurantMenu");
            }
            else
            {
                ViewBag.ErrorMessage = "Usuario o contraseña incorrectos";
                return View("Register");
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}