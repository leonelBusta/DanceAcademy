using Dance_MVCRepository.Models;
using Gen2_MVCRepository.AccesoDatos.Data.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanceMVCRepository.AccesoDatos.Repository
{
    public interface IGeneroRepository : IRepository<Genero>
    {
        void Update(Genero gen);

        IEnumerable<SelectListItem> GetListGeneros();
    }
}
