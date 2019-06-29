using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Ignis.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

//RegisterModel es la clase que se encarga de crear los usuarios y guardarlos en la base de datos.
//Esta clase cumple con el patrón Creator ya que RegisterModel es un experto con respecto a crear
//a Client o Technician (tiene los datos que serán provistos para crear dichos usuarios) y además los
//usa de forma cercana (por ejemplo cuando verifica si el email es correcto)
namespace Ignis.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,IdentityContext context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }
        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Full name")]
            public string Name { get; set; }

            [Required]
            [Display(Name = "Birth Date")]
            [DataType(DataType.Date)]
            public DateTime DOB { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public string Role { get; set; }
            
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            //Aquí tuvimos que preguntar con un if si el rol del usuario es de Technician o Client.
            //Si bien esto puede ser considerado como "bad smell", decidimos hacerlo de esta forma ya
            //que la aplicación necesita saber si el usuario que se registra es de tipo Technician o Client
            //y de esta forma se instancia como uno de esos tipos y no como ApplicationUser.
            returnUrl = returnUrl ?? Url.Content("~/");
            Admin admin = new Admin();
            foreach(Admin u in _context.Admin)
            {
                if (u.Role == IdentityData.AdminRoleName)
                {
                    admin = u;
                }
            }
            if (ModelState.IsValid)
            {   
                if (Input.Role=="Tecnico"){
                var user = new Ignis.Models.Technician {
                    Name = Input.Name,
                    DOB = Input.DOB,
                    UserName = Input.Email,
                    Email = Input.Email,
                    Role = Input.Role,
                    Available = true,
                    TotalPoints = 0,
                    TotalWorks = 0
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    admin.ListaTechnicians.Add(user);
                    _context.SaveChanges();
                    return LocalRedirect(returnUrl);
                }
                
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                }
            if (Input.Role=="Cliente"){
                var user = new Ignis.Models.Client {
                    Name = Input.Name,
                    DOB = Input.DOB,
                    UserName = Input.Email,
                    Email = Input.Email,
                    Role = Input.Role
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
