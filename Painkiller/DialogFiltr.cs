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
            Base.dialogCriteria = "";
        }

        private void SortFiltr_Click(object sender, EventArgs e)
        {
            if (RBWeight.Checked)
            {
                Base.dialogCriteria = $"Max_вага > {amountWeigthReps.Value}";
            }
            if (RBReps.Checked)
            {
                Base.dialogCriteria = $"К_сть_повторень_з_max_вагою > {amountWeigthReps.Value}";
            }
            Close();
        }

        private void amountWeigthReps_ValueChanged(object sender, EventArgs e)
        {
            RBWeight.Text = $"Більше від {amountWeigthReps.Value}{Form1.sendMeasure}";
            RBReps.Text = $"Більше від {amountWeigthReps.Value} к-сті повторів";
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

        private void DialogFiltr_Load(object sender, EventArgs e)
        {
            RBReps.Text = $"Більше від {amountWeigthReps.Value} к-сті повторів";
            RBWeight.Text = $"Більше від {amountWeigthReps.Value}{Form1.sendMeasure}";
        }
    }
}
