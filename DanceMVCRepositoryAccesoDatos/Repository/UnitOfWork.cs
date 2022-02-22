using DanceMVCRepository.AccesoDatos.Repository;
using Gen2_MVCRepository.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gen2_MVCRepository.AccesoDatos.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        public IGeneroRepository GRepo { get; set; }

        public IInstructorRepository IRepo { get; set; }
        public IAprendizRepository ARepo { get; set; }
        public IDireccion DRepo { get; set; }

        public readonly ApplicationDbContext contexto;

        public UnitOfWork(ApplicationDbContext ctx)
        {
            contexto = ctx;
            GRepo = new GeneroRepository(ctx);

            IRepo = new InstructoresRepository(ctx);

            ARepo = new AprendizRepository(ctx);

            DRepo = new DireccionRepository(ctx);
        }

        public void save()
        {
            contexto.SaveChanges();
        }
    }
}
