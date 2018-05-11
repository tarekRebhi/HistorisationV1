using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entitee;

namespace Services
{
    public interface  IHistorisationService : IDisposable
    {
        
            void Add(Histo histo);
            void Delete(Histo histo);

            void SaveChange();
            Histo findAppelBy(String champ);
            Histo getById(int? id);
            Histo getById(String champ);

            void Dispose();

            IEnumerable<Histo> GetAll();
        
    }
}
