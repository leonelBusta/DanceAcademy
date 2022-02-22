using Dance_MVCRepository.Models;
using Gen2_MVCRepository.AccesoDatos.Data.Repository;
using Gen2_MVCRepository.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DanceMVCRepository.AccesoDatos.Repository
{
    [Area("Main")]
    public class DireccionRepository : Repository<Direccion>, IDireccion
    {
        private readonly ApplicationDbContext cx;

        public DireccionRepository(ApplicationDbContext _cx) : base(_cx)
        {
            cx = _cx;
        }
        public void Update(Direccion dir)
        {
            Direccion direcDesBd =cx.Direccion.FirstOrDefault(s => s.Id == dir.Id);

            direcDesBd.Calle = dir.Calle;
            direcDesBd.Numero = dir.Numero;
            direcDesBd.Ciudad = dir.Ciudad;
            direcDesBd.Colonia = dir.Colonia;
            direcDesBd.Estado = dir.Estado;
        }
    }
}
