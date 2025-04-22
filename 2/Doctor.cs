using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TX12
{
    public abstract class Doctor
    {
        public string ID { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Specialty { get; set; }
        public int Experience { get; set; }
        public string Mobile { get; set; }

        public abstract void Input();
        public abstract void Output();
    }

}
