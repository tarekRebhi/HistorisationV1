using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entitee;

namespace Services
{
    public interface IPauseService:IDisposable
    {
        void Add(Pause pause);
        void Delete(Pause pause);

        void SaveChange();
        Pause findPauseBy(String champ);
        Pause getById(int? id);
        Pause getById(String champ);
        //Pause getByLogout(string login);
        void Dispose();

        IEnumerable<Pause> GetAll();
    }
}
