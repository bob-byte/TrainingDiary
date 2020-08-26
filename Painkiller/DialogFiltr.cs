using System;
using System.Data;
using System.Windows.Forms;

namespace Painkiller
{
    public partial class DialogFiltr : Form
    {
        public DialogFiltr()
        {
            InitializeComponent();
            Base.DialogCriteria = "";
            CBSelectTypeFilter.Text = "";
        }

        private void SortFiltr_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void TTrainingFiltr(String filter, DataGridView dGV, DataView view)
        {
            view.RowFilter = filter;
            dGV.DataSource = view;
            for (Int32 i = 0; i < dGV.Rows.Count - 1; i++)
            {
                dGV.Rows[i].Cells["N_пп"].Value = i + 1;
            }
        }

        private void CBSelectTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CBSelectTypeFilter.Text == "За групою м\'язів")
            {
                GroupFilter groupFilter = new GroupFilter();
                groupFilter.ShowDialog();
            }
            else if (CBSelectTypeFilter.Text == "За max вагою/к-стю повторень/к-стю підходів")
            {
                WeightRepsSetsFiltr weightRepsSets = new WeightRepsSetsFiltr();
                weightRepsSets.ShowDialog();
            }
        }
    }
}
