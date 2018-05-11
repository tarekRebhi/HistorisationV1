using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entitee;

namespace Services
{
    public interface IEmployeService : IDisposable
    {
        void Add(Employe employe);
        void Delete(Employe employe);

        void SaveChange();
        Employe findEmployeBy(String champ);
        Employe getById(int? id);
        Employe getById(String champ);
        Employe getByLogout(string login);
        void Dispose();

        IEnumerable<Employe> GetAll();
    }
}
