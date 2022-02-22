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
    public class DireccionController : Controller
    {
        private readonly IUnitOfWork unidadTrabajo;
        private readonly IWebHostEnvironment hosting;

        public DireccionController(IUnitOfWork unit, IWebHostEnvironment env)
        {
            unidadTrabajo = unit;
            hosting = env;

        }
        public IActionResult Index()
        {
            return View();
        }
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
                    data = unidadTrabajo.DRepo.GetAll()
                });
        }

        [HttpPost]
        public IActionResult Insert(Direccion dir)
        {
            //obtener la imagen seleccionada y grardas u na copia en nuestro servidor 
            if (ModelState.IsValid)
            {
                
                unidadTrabajo.DRepo.Add(dir);
                unidadTrabajo.save();
                return RedirectToAction(nameof(Index));
            }
            return View("Create");
        }
        public IActionResult Eliminar(int id)
        {
            Direccion dir = unidadTrabajo.DRepo.Get(id);
            if (dir == null)
            {
                return Json(new { success = false, message = "la direccion no existe" });
            }
            unidadTrabajo.DRepo.Remove(dir);
            unidadTrabajo.save();
            return Json(new { success = true, message = "Direccion eliminada " });
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Direccion dir = unidadTrabajo.DRepo.Get(id.Value);
            if (id == null)
            {
                return NotFound();
            }
            return View(dir);
        }

        [HttpPost]
        public IActionResult Update(Direccion dir)
        {
            if (ModelState.IsValid)
            {

                unidadTrabajo.DRepo.Update(dir);
                unidadTrabajo.save();
                return RedirectToAction("Index");
            }
            return View("Edit");
        }

    }
}
