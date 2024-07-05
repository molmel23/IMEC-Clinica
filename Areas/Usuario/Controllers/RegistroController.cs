using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProyectoProgramadoLenguajes2024.Models.ApisModels;

namespace ProyectoLenguajes2024.Areas.Paciente.Controllers
{
    [Area("Usuario")]
    [EnableCors("AllowAnyOrigin")]
    public class RegistroController : Controller
    {
        //[HttpPost]
        //[EnableCors("AllowAnyOrigin")]
        //public async Task<IActionResult> RegistrarUsuario([FromBody] RegistroPaciente modelo)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var userStore = HttpContext.RequestServices.GetService<IUserStore<IdentityUser>>() as IUserStore<IdentityUser>;
        //            var userManager = HttpContext.RequestServices.GetService(typeof(UserManager<IdentityUser>)) as UserManager<IdentityUser>;
        //            var logger = HttpContext.RequestServices.GetService(typeof(ILogger<RegistroController>)) as ILogger<RegistroController>;

        //            var user = new PacienteUser
        //            {
        //                Nombre = modelo.NombreUsuario,
        //                Apellido = modelo.ApellidoUsuario,
        //                Cedula = modelo.CedulaUsuario,
        //                Email = modelo.EmailUsuario
        //            };

        //            await userStore.SetUserNameAsync(user, modelo.EmailUsuario, CancellationToken.None);


        //            var result = await userManager.CreateAsync(user, modelo.ContraUsuario);

        //            if (result.Succeeded)
        //            {
        //                logger.LogInformation("User created a new account with password.");
        //                await userManager.AddToRoleAsync(user, CentroMedicoRoles.Role_Paciente);
        //                var usuarioId = await userManager.GetUserIdAsync(user);
        //                return Ok(new { usuarioId = usuarioId });
        //            }

        //        }
        //        var errores = ModelState.Values.SelectMany(ev => ev.Errors.Select(e => e.ErrorMessage));
        //        return BadRequest(new { Errores = errores });


        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Error interno del servidor.");
        //    }
        //}

        [HttpPost]
        [EnableCors("AllowAnyOrigin")]
        public async Task<IActionResult> IngresarUsuario([FromBody] IngresarUsuario modelo)
        {
            var logger = HttpContext.RequestServices.GetService(typeof(ILogger<RegistroController>)) as ILogger<RegistroController>;
            try
            {


                if (ModelState.IsValid)
                {
                    var userManager = HttpContext.RequestServices.GetService(typeof(UserManager<IdentityUser>)) as UserManager<IdentityUser>;
                    var signInManager = HttpContext.RequestServices.GetService(typeof(SignInManager<IdentityUser>)) as SignInManager<IdentityUser>;

                    var cuenta = await signInManager.PasswordSignInAsync(modelo.EmailUsuario, modelo.ContraUsuario, false, lockoutOnFailure: false);
                    if (cuenta.Succeeded)
                    {
                        logger.LogInformation("User logged in.");

                        var usuario = await userManager.FindByEmailAsync(modelo.EmailUsuario);
                        if (usuario != null)
                        {
                            // Verificar el rol del usuario
                            var roles = await userManager.GetRolesAsync(usuario);
                            if (roles.Contains("Usuario"))
                            {
                                var usuarioId = usuario.Id;
                                
                                return Ok(new { UsuarioId = usuarioId });
                            }
                            else
                            {
                                // El usuario no tiene el rol adecuado
                                return Unauthorized("No tiene permiso para iniciar sesión como paciente.");
                            }
                        }
                        else
                        {
                            return NotFound(new { Message = "Usuario no encontrado" });
                        }
                    }

                    if (cuenta.IsLockedOut)
                    {
                        logger.LogWarning("User account locked out.");
                        return StatusCode(423, "El usuario ingresado se encuentra bloqueado.");
                    }
                    else
                    {
                        return Unauthorized("Intento de inicio de sesión no válido.");
                    }
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al procesar inicio de sesión.");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPost]
        [EnableCors("AllowAnyOrigin")]
        public async Task<IActionResult> CerrarSesion()
        {
            var _signInManager = HttpContext.RequestServices.GetService(typeof(SignInManager<IdentityUser>)) as SignInManager<IdentityUser>;
            var _logger = HttpContext.RequestServices.GetService(typeof(ILogger<IdentityUser>)) as ILogger<IdentityUser>;

            try
            {
                await _signInManager.SignOutAsync();
                _logger.LogInformation("User logged out.");
                return Ok(new { Message = "Sesión cerrada correctamente." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cerrar sesión.");
                return StatusCode(500, "Error interno del servidor al cerrar sesión.");
            }
        }

    }
}