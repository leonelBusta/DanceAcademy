using DanceMVCRepository.AccesoDatos.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gen2_MVCRepository.AccesoDatos.Data.Repository
{
    public interface IUnitOfWork
    {
        public IGeneroRepository GRepo { get; set; }

        public IInstructorRepository IRepo { get; set; }

        public  IAprendizRepository ARepo { get; set; }
        public  IDireccion DRepo { get; set; }
        void save();
    }
}
