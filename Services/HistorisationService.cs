using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain.Entitee;

namespace Services
{
    public class HistorisationService : IHistorisationService
    {
        IDatabaseFactory dbfactory = null;
        IUnitOfWork uow = null;
        public HistorisationService()
        {
            dbfactory = new DatabaseFactory();
            uow = new UnitOfWork(dbfactory);
        }
        public void Add(Histo histo)
        {
            uow.HistorisationRepository.Add(histo);
        }

        public void Delete(Histo histo)
        {
            uow.HistorisationRepository.Delete(histo);
        }

        public void Dispose()
        {
            uow.Dispose();
        }

        public Histo findAppelBy(string champ)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Histo> GetAll()
        {
            return uow.HistorisationRepository.GetAll();
        }

        public Histo getById(string champ)
        {
            throw new NotImplementedException();
        }

        public Histo getById(int? id)
        {
            return uow.HistorisationRepository.GetById(id);
        }

        public void SaveChange()
        {
            uow.Commit();
        }
    }
}
