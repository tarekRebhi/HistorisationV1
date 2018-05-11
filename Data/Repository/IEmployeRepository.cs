using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entitee;
using Data.Infrastructure;

namespace Data.Repository
{
    public interface IEmployeRepository : IRepositoryBase<Employe>
    {
        Employe getByLogin(string login);
        List<Employe> getByLoginList(string login);

    }
}
