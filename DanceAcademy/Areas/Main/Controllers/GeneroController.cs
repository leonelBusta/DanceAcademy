
using Dance_MVCRepository.Models;
using Gen2_MVCRepository.AccesoDatos.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanceAcademy.Areas.Main.Controllers
{
    [Area("Main")]
    public class GeneroController : Controller

    {
        private readonly IUnitOfWork unidadTrabjo;

        public GeneroController(IUnitOfWork unit)
        {
            unidadTrabjo = unit;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]

        public IActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Genero gen)
        {
            if (ModelState.IsValid)
            {
                
                unidadTrabjo.GRepo.Add(gen);
                unidadTrabjo.save();
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        [HttpPost] //API
        public IActionResult Listar()
        {
            //Thread.Sleep(5000);
            return Json(new
            {
                data = unidadTrabjo.GRepo.GetAll()
            });

        }

        public IActionResult Eliminar(int id)
        {
            Genero gen = unidadTrabjo.GRepo.Get(id);
            if (gen == null)
            {
                return Json(new { success = false, message = "el instructor no existe" });
            }
            unidadTrabjo.GRepo.Remove(gen);
            unidadTrabjo.save();
            return Json(new { success = true, message = "Genero eliminado " });
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Genero gen = unidadTrabjo.GRepo.Get(id.Value);
            if (id == null)
            {
                return NotFound();
            }
            return View(gen);
        }

        [HttpPost]
        public IActionResult Update(Genero gen)
        {
            if (ModelState.IsValid)
            {
               
                unidadTrabjo.GRepo.Update(gen);
                unidadTrabjo.save();
                return RedirectToAction("Index");
            }
            return View("Edit");
        }

    }//end class
}
                    