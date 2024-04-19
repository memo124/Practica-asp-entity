using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SitioWeb.Models;

namespace SitioWeb.Controllers
{
    public class EstudiantesController : Controller
    {
        // GET: EstudiantesController
        public ActionResult Index()
        {
            var estudiantes = from estud in RecuperaEstudiantes()
                              orderby estud.idEstudiante
                              select estud;
            return View(estudiantes);
        }

        // GET: EstudiantesController/Details/5
        public ActionResult Details(int idEstudiante)
        {
            var estudiante = RecuperaEstudiante(idEstudiante);
            return View(estudiante);

        }

        // GET: EstudiantesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstudiantesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                using (var context = new Cinexion())
                {
                    var nuevoEstudiante = new Estudiante();

                    // Asignar los valores del formulario al objeto Estudiante
                    nuevoEstudiante.Nombre = collection["Nombre"];
                    nuevoEstudiante.ApelPaterno = collection["ApelPaterno"];
                    nuevoEstudiante.ApelMaterno = collection["ApelMaterno"];
                    nuevoEstudiante.FechaInscrip = DateTime.Parse(collection["FechaInscrip"]);
                    nuevoEstudiante.Edad = int.Parse(collection["Edad"]);

                    // Insertar el nuevo estudiante en la base de datos
                    context.estudiantes.Add(nuevoEstudiante);
                    context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: EstudiantesController/Edit/5    
        public ActionResult Edit(int idEstudiante)
        {
            var estudiante = RecuperaEstudiante(idEstudiante);
            return View(estudiante);
        }

        // POST: EstudiantesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int idEstudiante, IFormCollection collection)
        {
            try
            {
                using (var context = new Cinexion())
                {
                    var estudiante = context.estudiantes.Find(idEstudiante);
                   
                    estudiante.Nombre = collection["Nombre"];
                    estudiante.ApelPaterno = collection["ApelPaterno"];
                    estudiante.ApelMaterno = collection["ApelMaterno"];
                    estudiante.FechaInscrip = DateTime.Parse(collection["FechaInscrip"]);
                    estudiante.Edad = int.Parse(collection["Edad"]);

                    context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EstudiantesController/Delete/5
        public ActionResult Delete(int idEstudiante)
        {
            var estudiante = RecuperaEstudiante(idEstudiante);
           
            return View(estudiante);
        }

        // POST: EstudiantesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int idEstudiante, IFormCollection collection)
        {
            try
            {
                using (var context = new Cinexion())
                {
                    var estudiante = context.estudiantes.Find(int.Parse(collection["idEstudiante"]));
                    context.estudiantes.Remove(estudiante);
                    context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }

        [NonAction]
        public List<Estudiante> RecuperaEstudiantes()
        {
            using (var context = new Cinexion())
            {
                var lista = context.estudiantes.ToList();
                return lista;
            }
        }

        [NonAction]
        public Estudiante  RecuperaEstudiante(int id)
        {
            using (var context = new Cinexion())
            {
                var lista = context.estudiantes.Find(id);
                return lista;
            }
        }
    }
}
