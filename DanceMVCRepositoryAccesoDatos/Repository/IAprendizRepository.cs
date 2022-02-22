using Dance_MVCRepository.Models;
using Gen2_MVCRepository.AccesoDatos.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanceMVCRepository.AccesoDatos.Repository
{
    public interface IAprendizRepository : IRepository<Aprendices>
    {
        void Update(Aprendices apr); 
    }
}
