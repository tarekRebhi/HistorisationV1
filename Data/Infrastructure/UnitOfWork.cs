using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repository;

namespace Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        private HistorisationContext dataContext;

        IDatabaseFactory dbFactory;
        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;

        }
        protected HistorisationContext DataContext
        {
            get
            {
                return dataContext = dbFactory.DataContext;
            }
        }


        public void Commit()
        {
            DataContext.SaveChanges();
        }
        public void CommitAsync()
        {
            DataContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            dbFactory.Dispose();
        }

        private IHistorisationRepository historisationRepository;
        public IHistorisationRepository HistorisationRepository
        {
            get { return historisationRepository = new HistorisationRepository(dbFactory); }
        }
        private IEmployeRepository employeRepository;
        public IEmployeRepository EmployeRepository
        {
            get { return employeRepository = new EmployeRepository(dbFactory); }
        }
        private IPauseRepository pauseRepository;
        public IPauseRepository PauseRepository
        {
            get { return pauseRepository = new PauseRepository(dbFactory); }
        }


    }
}
