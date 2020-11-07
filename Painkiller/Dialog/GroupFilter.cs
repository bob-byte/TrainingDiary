using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painkiller
{
    public partial class GroupFilter : Form
    {
        public GroupFilter()
        {
            InitializeComponent();
        }

        private void GroupFilter_FormClosed(object sender, FormClosedEventArgs e)
        {
            String textFilter = "";
            Int32 countChecked = 0;
            foreach(CheckBox checkBox in groupBox1.Controls)
            {
                if(countChecked >= 1 && checkBox.Checked)
                {
                    textFilter += $" OR Група_мязів = '{checkBox.Text}'";
                }
                else if(checkBox.Checked)
                {
                    textFilter += $"Група_мязів = '{checkBox.Text}'";
                    countChecked++;
                }
            }

            if(countChecked >= 1)
            {
                Base.DialogCriteria = textFilter;
            }
        }
    }
}
