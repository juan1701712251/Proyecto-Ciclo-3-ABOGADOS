using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto.App.Dominio;
using Proyecto.App.Persistencia;

namespace Proyecto.App.SitioWebAutogenerado.Pages_Clientes
{
    public class IndexModel : PageModel
    {
        private readonly Proyecto.App.Persistencia.ApplicationContext _context;

        public IndexModel(Proyecto.App.Persistencia.ApplicationContext context)
        {
            _context = context;
        }

        public IList<Cliente> Cliente { get;set; }

        public async Task OnGetAsync()
        {
            Cliente = await _context.Clientes
                .Include(c => c.ciudad)
                .Include(c => c.pais).ToListAsync();
        }
    }
}
