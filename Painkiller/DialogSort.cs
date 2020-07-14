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
    public partial class DialogSort : Form
    {
        public DialogSort()
        {
            InitializeComponent();
        }

        private void SortFiltrSearch_Click(object sender, EventArgs e)
        {
            if (RBGroup.Checked)
            {
                Base.dialogCriteria = "Група_мязів";
            }
            if (RBTypeTraining.Checked)
            {
                Base.dialogCriteria = "Вид_тренування";
            }
            if (RBExercise.Checked)
            {
                Base.dialogCriteria = "Вправа";
            }
            
            Close();
        }

        public void TTrainingSort(string sort, DataGridView dGV, DataView view)
        {
            if(sort != "")
            {
                if (RBGrowth.Checked)
                {
                    view.Sort = $"{sort} ASC";
                }
                else if (RBHorning.Checked)
                {
                    view.Sort = $"{sort} DESC";
                }
                else
                {
                    return;
                }
            }
            else
            {
                view.Sort = sort;
            }
            

            dGV.DataSource = view;
            for (Int32 i = 0; i < dGV.Rows.Count - 1; i++)//dGv.Rows.Count - 1, оскільки останній рядок самостійно додається
            {
                dGV.Rows[i].Cells["N_пп"].Value = i + 1;
            }
        }
    }
}
