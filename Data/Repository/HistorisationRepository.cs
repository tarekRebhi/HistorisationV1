using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain.Entitee;

namespace Data.Repository
{
    public class HistorisationRepository : RepositoryBase<Histo>, IHistorisationRepository
    {
        public HistorisationRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}
