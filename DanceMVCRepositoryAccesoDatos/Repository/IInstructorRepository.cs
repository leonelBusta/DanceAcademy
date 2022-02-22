using Dance_MVCRepository.Models;
using Gen2_MVCRepository.AccesoDatos.Data.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanceMVCRepository.AccesoDatos.Repository
{
    public interface IInstructorRepository : IRepository<Instructores>
    {
        void Update(Instructores ins);
        IEnumerable<SelectListItem> GetListInstructores();

    }
}
