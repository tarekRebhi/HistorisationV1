using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repository;

namespace Data.Infrastructure
{
    public interface IUnitOfWork:IDisposable
    {
        IHistorisationRepository HistorisationRepository { get; }
        IEmployeRepository EmployeRepository { get; }
        IPauseRepository PauseRepository { get; }
        void CommitAsync();
        void Commit();
    }
}
