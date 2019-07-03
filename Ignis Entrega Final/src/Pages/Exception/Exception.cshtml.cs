using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ignis.Areas.Identity.Data;
using Ignis.Models;

namespace Ignis.Pages_Exception
{
    // Este es el controlador de la página de excepciones, el cual solo recibe
    // un mensaje de alguna excepción y lo muestra
    public class ExceptionModel : PageModel
    {

        public ExceptionModel()
        {
        }

        public string Message { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Message = id;
            return Page();
        }
    }
}