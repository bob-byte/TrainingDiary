using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painkiller
{
    public interface IDialogService
    {
        public String DialogCriteria { get; }

        public void Execute(DataView dataView, out String dialogCriteria, DataGridView dataGrid = null);
    }
}
