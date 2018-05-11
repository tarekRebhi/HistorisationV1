using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitee
{
    public class Histo
    {
        public int HistoID { get; set; }
        public string poles { get; set; }
        public string mission { get; set; }
        public string tache { get; set; }
        public string site { get; set; }
        public int nbDossiersTr { get; set; }
        public DateTime? h_debut { get; set; }
        public DateTime? h_fin { get; set; }
        public string duree { get; set; }
        public string departement { get; set; }
        public int EmployeID { get; set; }

        public virtual Employe Employe { get; set; }


    }
}
