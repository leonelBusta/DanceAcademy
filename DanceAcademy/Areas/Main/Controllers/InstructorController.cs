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
    public class InstructorController : Controller
    {
        private readonly IUnitOfWork unidadTrabajo;
        private readonly IWebHostEnvironment hosting;

        public InstructorController(IUnitOfWork unit, IWebHostEnvironment env)
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
                    data = unidadTrabajo.IRepo.GetAll()
                });
        }

        [HttpPost]
        public IActionResult Insert(Instructores ins)
        {
            //obtener la imagen seleccionada y grardas u na copia en nuestro servidor 
            if (ModelState.IsValid)
            {
                String rutaPrincipal = hosting.WebRootPath;
                var imagen = HttpContext.Request.Form.Files;
                string nombreNuevo = Guid.NewGuid().ToString();
                var folder = Path.Combine(rutaPrincipal, @"imagenes\instructores");
                var extension = Path.GetExtension(imagen[0].FileName);
                using (var stream = new FileStream(Path.Combine(folder, nombreNuevo + extension), FileMode.Create))
                {
                    imagen[0].CopyTo(stream);
                }
                //actualizar el calor
                ins.UrlFoto = @"imagenes\instructores\" + nombreNuevo + extension;


                unidadTrabajo.IRepo.Add(ins);
                unidadTrabajo.save();
                return RedirectToAction(nameof(Index));
            }
            return View("Create", ins);
        }
        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            Instructores ins = unidadTrabajo.IRepo.Get(id);
            if (ins == null)
            {
                return Json(new { success = false, message = "el instructor no existe" });
            }
            unidadTrabajo.IRepo.Remove(ins);
            unidadTrabajo.save();
            return Json(new { success = true, message = "Instructor eliminado " });
        }

        [HttpGet]

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Instructores ins = unidadTrabajo.IRepo.Get(id.Value);
            if (id == null)
            {
                return NotFound();
            }
            return View(ins);
        }

        [HttpPost]
        public IActionResult Update(Instructores ins)
        {
            if (ModelState.IsValid)
            {
                var imagen = HttpContext.Request.Form.Files;
                if (imagen.Count > 0) //pregunta si el usuario selecciono una nueva imagen 
                {
                    String rutaPrincipal = hosting.WebRootPath;

                    string nombreNuevo = Guid.NewGuid().ToString();
                    var folder = Path.Combine(rutaPrincipal, @"imagenes\instructores");
                    var extension = Path.GetExtension(imagen[0].FileName);
                    if (extension.ToLower() != ".jpg" && extension.ToLower() != ".png")
                    {
                        ModelState.AddModelError("UrlFoto", "Foto no es valida");
                        return View("Create", ins);
                    }
                    using (var stream = new FileStream(Path.Combine(folder, nombreNuevo + extension), FileMode.Create))
                    {
                        imagen[0].CopyTo(stream);
                    }
                    //actualizar el calor
                    ins.UrlFoto = @"imagenes\instructores\" + nombreNuevo + extension;

                }
                else //el usuario no selecciono una nueva imagen, por lo tanto, se conserva a actual
                {
                    Instructores insFromDB = unidadTrabajo.IRepo.Get(ins.Id);
                    ins.UrlFoto = insFromDB.UrlFoto;
                }
                

                unidadTrabajo.IRepo.Update(ins);
                unidadTrabajo.save();
                return RedirectToAction(nameof(Index));
            }
            return View("Create", ins);
        }
    }
}
