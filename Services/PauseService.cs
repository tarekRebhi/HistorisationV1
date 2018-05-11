using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain.Entitee;

namespace Services
{
    public class PauseService:IPauseService
    {
        IDatabaseFactory dbfactory = null;
        IUnitOfWork uow = null;
        public PauseService()
        {
            dbfactory = new DatabaseFactory();
            uow = new UnitOfWork(dbfactory);
        }
        public void Add(Pause pause)
        {
            uow.PauseRepository.Add(pause);
        }

        public void Delete(Pause pause)
        {
            uow.PauseRepository.Delete(pause);
        }

        public void Dispose()
        {
            uow.Dispose();
        }

        public Pause findPauseBy(string champ)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pause> GetAll()
        {
            return uow.PauseRepository.GetAll();
        }

        public Pause getById(string champ)
        {
            throw new NotImplementedException();
        }

        public Pause getById(int? id)
        {
            return uow.PauseRepository.GetById(id);
        }

        //public Pause getByLogout(string login)
        //{
        //    List<Pause> pauses = uow.PauseRepository.getByLoginList(login);
        //    var employe = dbfactory.DataContext.Employes.FirstOrDefault(a => a.logSortie == null);
        //    return employe;


        //}

        public void SaveChange()
        {
            uow.Commit();
        }
    }
}
