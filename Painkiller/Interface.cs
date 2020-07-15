using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painkiller
{
    public interface IPainKiller
    {
        public String[] Exercises();
        public void Reps(out Int32 min, out Int32 max);
        public void Sets(out Int32 min, out Int32 max);
    }

}
