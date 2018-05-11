using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitee
{
    public class Employe
    {
        public int EmployeID{get;set;}
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime? logEntree { get; set; }
        public DateTime? logSortie { get; set; }
        public string logDuree { get; set; }

        public virtual ICollection<Histo> Historisations { get; set; }
        public virtual ICollection<Pause> Pauses { get; set; }
    }
}
