using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain.Entitee;

namespace Data.Repository
{
    public class PauseRepository:RepositoryBase<Pause>,IPauseRepository
    {
        public PauseRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}
