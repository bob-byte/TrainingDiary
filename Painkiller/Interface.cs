using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painkiller
{
    public interface IPainKiller
    {
        public void Exercises();
        public void Reps(out int min, out int max);
        public void Sets(out int min, out int max);
    }

}
