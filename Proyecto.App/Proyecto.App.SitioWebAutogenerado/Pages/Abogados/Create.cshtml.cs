using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto.App.Dominio;
using Proyecto.App.Persistencia;

namespace Proyecto.App.SitioWebAutogenerado.Pages_Abogados
{
    public class CreateModel : PageModel
    {
        private readonly Proyecto.App.Persistencia.ApplicationContext _context;

        public CreateModel(Proyecto.App.Persistencia.ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Abogado Abogado { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Abogados.Add(Abogado);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
