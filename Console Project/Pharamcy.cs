using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
    class Pharamcy
    {
        // Id, Name, MinSalary, Budget, Location proplari var, ozunde Iscileri ve Dermanlari saxlayir.
        public int Id { get;}
        public string Name { get; set; }
        public int MinSalary { get; set; } = 200;
        public int Budget { get; set; } = 100;
        public string Location { get; set; }
       public List<Employe> employe;
        public Pharamcy()
        {
            employe = new();
        }
    }
}
