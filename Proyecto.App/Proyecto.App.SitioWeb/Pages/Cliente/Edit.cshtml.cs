using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto.App.Persistencia;
using Proyecto.App.Dominio;

namespace Proyecto.SitioWeb.App.Pages
{
    public class EditModel : PageModel
    {
        private IRepositorioCliente _repoCliente {get; set;}
        private IRepositorioPais _repoPais { get; set;}

        [BindProperty]
        public Cliente cliente {get; set;}
        
        public IEnumerable<Pais> paises {get; set;}

        public EditModel()
        {
            _repoCliente = new RepositorioCliente(new Proyecto.App.Persistencia.ApplicationContext());
            _repoPais = new RepositorioPais(new Proyecto.App.Persistencia.ApplicationContext());
        }

        public IActionResult OnGet(int id)
        {
            paises = _repoPais.ObtenerTodos();
            cliente = _repoCliente.ObtenerPorId(id);
            if (cliente == null)
            {
                return RedirectToPage("/Cliente/List");
            }
            else
            {
                return Page();
            }
        }


        public IActionResult OnPost(Cliente cliente)
        {
            _repoCliente.Modificar(cliente);
            return RedirectToPage("/Cliente/List");
        }
    }
}
