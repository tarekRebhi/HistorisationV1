using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitee
{
    public class Pause
    {
        public int PauseID{ get; set; }
        public string type { get; set; }
        public DateTime? debut { get; set; }
        public DateTime? fin { get; set; }
        public string duree { get; set; }
        public int EmployeID { get; set; }

        public virtual Employe Employe { get; set; }

        

    }
}
