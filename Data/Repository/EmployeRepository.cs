using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain.Entitee;

namespace Data.Repository
{
    public class EmployeRepository : RepositoryBase<Employe>, IEmployeRepository
    {
    
        public EmployeRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
        HistorisationContext context = new HistorisationContext();
        /**/
        public Employe getByLogin(string login)
        {
            var employe = context.Employes.FirstOrDefault(t=>t.Login==login);
            if(employe!=null)
            {
                return employe;
            }
            else
            {
                return null;
            }
        }

        
        public List<Employe> getByLoginList(string login)
        {
            var usersquery = context.Employes.Where(a => a.Login == login);

            List<Employe> employes = new List<Employe>();

            if (usersquery != null)
            {
                foreach (Employe item in usersquery)
                {

                    employes.Add(item);
                }

                return employes;
            }


            else
            {
                return null;
            }

        }
    }
}
