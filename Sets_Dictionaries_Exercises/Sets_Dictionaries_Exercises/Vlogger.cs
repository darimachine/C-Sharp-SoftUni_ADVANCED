using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sets_Dictionaries_Exercises
{
    class Vlogger
    {
        public Vlogger()
        {
            this.Followers = new HashSet<string>();
            this.Following = new HashSet<string>();
        }
        public HashSet<string> Followers { get; set; }
        public HashSet<string> Following { get; set; }
    }
}
