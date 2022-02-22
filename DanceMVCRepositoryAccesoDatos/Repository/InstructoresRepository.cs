using Dance_MVCRepository.Models;
using Gen2_MVCRepository.AccesoDatos.Data.Repository;
using Gen2_MVCRepository.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DanceMVCRepository.AccesoDatos.Repository
{
    class InstructoresRepository : Repository<Instructores>,IInstructorRepository
    {
        private readonly ApplicationDbContext cx;
        public InstructoresRepository(ApplicationDbContext _cx) : base(_cx)
        {
            cx = _cx;
        }
        public IEnumerable<SelectListItem> GetListInstructores()
        {
            return cx.Instructores.Select(ins => new SelectListItem()
            {
                Text = ins.CodigoInstructor + " -> " + ins.Nombre,
                Value = ins.Id.ToString()

            });
        }

        public void Update(Instructores ins)
        {
            Instructores insDesdeBd = cx.Instructores.FirstOrDefault(s => s.Id == ins.Id);
            insDesdeBd.Nombre = ins.Nombre;
            insDesdeBd.ApPaterno = ins.ApPaterno;
            insDesdeBd.ApMaterno = ins.ApMaterno;
            insDesdeBd.CodigoInstructor = ins.CodigoInstructor;
        }
    }
}
