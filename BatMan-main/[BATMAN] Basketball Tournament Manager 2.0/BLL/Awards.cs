using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BATMAN__Basketball_Tournament_Manager_2._0.BLL
{
   public class Awards
    {
        public int    awardID        { get; set; }
        public string awardChampionship { get; set; }
        public string awardFirstRunnerUp { get; set; }
        public string awardMVP { get; set; }
        public string awardSF { get; set; }
        public string awardPF { get; set; }
        public string awardPG { get; set; }
        public string awardSG { get; set; }
        public string awardC { get; set; }
        public Tournament    tournament   { get; set; }

        public Awards()
        {
            this.tournament = new Tournament();
        }
   }
}
