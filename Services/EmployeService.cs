using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entitee;
using Data.Infrastructure;

namespace Services
{
    public class EmployeService : IEmployeService
    {
        IDatabaseFactory dbfactory = null;
        IUnitOfWork uow = null;
        public EmployeService()
        {
            dbfactory = new DatabaseFactory();
            uow = new UnitOfWork(dbfactory);
        }
        public void Add(Employe employe)
        {
            uow.EmployeRepository.Add(employe);
        }

        public void Delete(Employe employe)
        {
            uow.EmployeRepository.Delete(employe);
        }

        public void Dispose()
        {
            uow.Dispose();
        }

        public Employe findEmployeBy(string champ)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employe> GetAll()
        {
            return uow.EmployeRepository.GetAll();
        }

        public Employe getById(string champ)
        {
            throw new NotImplementedException();
        }

        public Employe getById(int? id)
        {
            return uow.EmployeRepository.GetById(id);
        }

        /**/
        public Employe getByLogout(string login)
        {
            List<Employe> users = uow.EmployeRepository.getByLoginList(login);
            var employe = dbfactory.DataContext.Employes.FirstOrDefault(a => a.logSortie == null);
            return employe;
            

        }

        public void SaveChange()
        {
            uow.Commit();
        }
    }
}
