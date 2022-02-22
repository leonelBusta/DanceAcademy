using Dance_MVCRepository.Models;
using Gen2_MVCRepository.AccesoDatos.Data.Repository;
using Gen2_MVCRepository.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DanceMVCRepository.AccesoDatos.Repository
{
    public class GeneroRepository : Repository<Genero>, IGeneroRepository

    {
        private readonly ApplicationDbContext cx;
        public GeneroRepository(ApplicationDbContext _cx) : base(_cx)
        {
            cx = _cx;
        }

        public IEnumerable<SelectListItem> GetListGeneros()
        {
            return cx.Generos.Select(i => new SelectListItem()
            {
                Text = i.Tipo,
                Value = i.Id.ToString()
            });
        }

        public void Update(Genero gen)
        {
            Genero catDesdeBd = cx.Generos.FirstOrDefault(s => s.Id == gen.Id);
            catDesdeBd.Tipo = gen.Tipo;
            catDesdeBd.Descripcion = gen.Descripcion;
        }
    }
}
