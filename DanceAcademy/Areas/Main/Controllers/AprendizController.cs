using Dance_MVCRepository.Models;
using Gen2_MVCRepository.AccesoDatos.Data.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DanceAcademy.Areas.Main.Controllers
{
    [Area("Main")]
    public class AprendizController : Controller
    {
        private readonly IUnitOfWork unidadTrabajo;
        private readonly IWebHostEnvironment hosting;
        public AprendizController(IUnitOfWork unit, IWebHostEnvironment env)
        {
            unidadTrabajo = unit;
            hosting = env;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Json(
                new
                {
                    data = unidadTrabajo.ARepo.GetAll()
                });
        }

        [HttpPost]
        public IActionResult Insert(Aprendices apr)
        {
            //obtener la imagen seleccionada y grardas u na copia en nuestro servidor 
            if (ModelState.IsValid)
            {
                String rutaPrincipal = hosting.WebRootPath;
                var imagen = HttpContext.Request.Form.Files;
                string nombreNuevo = Guid.NewGuid().ToString();
                var folder = Path.Combine(rutaPrincipal, @"imagenes\Aprendices");
                var extension = Path.GetExtension(imagen[0].FileName);
                using (var stream = new FileStream(Path.Combine(folder, nombreNuevo + extension), FileMode.Create))
                {
                    imagen[0].CopyTo(stream);
                }
                //actualizar el calor
                apr.UrlFoto = @"imagenes\Aprendices" + nombreNuevo + extension;


                unidadTrabajo.ARepo.Add(apr);
                unidadTrabajo.save();
                return RedirectToAction(nameof(Index));
            }
            return View("Create", apr);
        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            Aprendices apr = unidadTrabajo.ARepo.Get(id);
            if (apr == null)
            {
                return Json(new { success = false, message = "el instructor no existe" });
            }
            unidadTrabajo.ARepo.Remove(apr);
            unidadTrabajo.save();
            return Json(new { success = true, message = "Aprendiz eliminado " });
        }

        [HttpGet]

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Aprendices apr = unidadTrabajo.ARepo.Get(id.Value);
            if (id == null)
            {
                return NotFound();
            }
            return View(apr);
        }


        [HttpPost]
        public IActionResult Update(Aprendices apr)
        {
            if (ModelState.IsValid)
            {
                /* String rutaPrincipal = hosting.WebRootPath;
                 var imagen = HttpContext.Request.Form.Files;
                 string nombreNuevo = Guid.NewGuid().ToString();
                 var folder = Path.Combine(rutaPrincipal, @"imagenes\instructores");
                 var extension = Path.GetExtension(imagen[0].FileName);
                 using (var stream = new FileStream(Path.Combine(folder, nombreNuevo + extension), FileMode.Create))
                 {
                     imagen[0].CopyTo(stream);
                 }
                 ins.UrlFoto = @"imagenes\instructores" + nombreNuevo + extension; */

                unidadTrabajo.ARepo.Update(apr);
                unidadTrabajo.save();
                return RedirectToAction("Index");
            }
            return View("Edit", apr);
        }
    }
}
