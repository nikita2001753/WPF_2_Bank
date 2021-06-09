using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_bank
{
    public class Departaments
    {
        public string DepartmentName { get; set; }
        public int DepartmentId { get; set; }

        public Departaments(string Name, int Id)
        {
            DepartmentName = Name;
            DepartmentId = Id;
        }
    }
}
