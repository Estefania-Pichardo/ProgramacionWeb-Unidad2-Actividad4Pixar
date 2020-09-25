using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using U2Actividad4Routing.Models;

namespace U2Actividad4Routing.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("Peliculas")]
        public IActionResult Peliculas()
        {
            pixarContext context = new pixarContext();

            var peliculas = context.Pelicula.OrderBy(x => x.Nombre);

            return View(peliculas);
        }

        [Route("Peliculas/{id}")]
        public IActionResult Pelicula(string id)
        {
            pixarContext context = new pixarContext();
            var nombre = id.Replace("-", " ").ToLower();
            var pelicula = context.Pelicula.Include(x=>x.Apariciones).FirstOrDefault(x => x.Nombre.ToLower() == nombre);

            if(pelicula==null)
            {
                return RedirectToAction("Peliculas");
            }
            else
            {
                PeliculaViewModel pvm = new PeliculaViewModel();

                pvm.Id = pelicula.Id;
                pvm.Nombre = pelicula.Nombre;
                pvm.FechaEstreno = pelicula.FechaEstreno;
                pvm.Descripcion = pelicula.Descripción;
                pvm.NombreOriginal = pelicula.NombreOriginal;

                var Personajes = context.Apariciones.Include(x => x.IdPeliculaNavigation)
                    .Include(x => x.IdPersonajeNavigation).Where(x => (x.IdPelicula == pelicula.Id)).Select(x => x);
                pvm.Apariciones = Personajes;

                return View(pvm);
            } 
        }
        [Route("Cortometrajes")]
        public IActionResult Cortometrajes()
        {
            pixarContext context = new pixarContext();

            CortometrajesViewModel cvm = new CortometrajesViewModel();
            var Categorias = context.Categoria.Include(x => x.Cortometraje).OrderBy(x=>x.Nombre);

            cvm.Categorias = Categorias;
            
             return View(cvm);


        }

        [Route("Cortometrajes/{id}")]
        public IActionResult Cortometraje(string id)
        {
            pixarContext context = new pixarContext();
            var nombre = id.Replace("-", " ").ToLower();
            var corto = context.Cortometraje.FirstOrDefault(x => x.Nombre.ToLower() == nombre);

            if(corto==null)
            {
                return RedirectToAction("Cortometrajes");
            }
            else
            {
                return View(corto);
            }
            
        }
    }
}
