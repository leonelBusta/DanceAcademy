using Dance_MVCRepository.Models;
using Gen2_MVCRepository.AccesoDatos.Data.Repository;
using Gen2_MVCRepository.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DanceMVCRepository.AccesoDatos.Repository
{
    [Area("Main")]
    public class AprendizRepository : Repository<Aprendices>, IAprendizRepository
    {
        private readonly ApplicationDbContext cx;

        public AprendizRepository(ApplicationDbContext _cx) : base (_cx)
        {
            cx = _cx;
        }

        public void Update(Aprendices apr)
        {
            Aprendices aprenDesBd = cx.Aprendices.FirstOrDefault(s => s.Id == apr.Id);
            aprenDesBd.Nombre = apr.Nombre;
            aprenDesBd.ApPaterno = apr.ApPaterno;
            aprenDesBd.ApMaterno = apr.ApMaterno;
            aprenDesBd.Edad = apr.Edad;
            aprenDesBd.UrlFoto = apr.UrlFoto;
        }
    }
}
