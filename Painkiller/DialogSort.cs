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
            Base.dialogCriteria = "";
        }

        private void SortFiltrSearch_Click(object sender, EventArgs e)
        {
            if (CBTypeSort.Text == "По групах м'язів")
            {
                Base.dialogCriteria = "Група_мязів";
            }
            else if (CBTypeSort.Text == "По видах тренувань")
            {
                Base.dialogCriteria = "Вид_тренування";
            }
            else if (CBTypeSort.Text == "По вправах")
            {
                Base.dialogCriteria = "Вправа";
            }
            else if (CBTypeSort.Text == "По обтяженнях")
            {
                Base.dialogCriteria = "Обтяження";
            }
            else if(CBTypeSort.Text == "По положеннях тіла")
            {
                Base.dialogCriteria = "Положення";
            }
            else if (CBTypeSort.Text == "По max вазі")
            {
                Base.dialogCriteria = "Max_вага";
            }
            else if (CBTypeSort.Text == "По кількості повторень з max вагою")
            {
                Base.dialogCriteria = "К_сть_повторень_з_max_вагою";
            }
            else if (CBTypeSort.Text == "По кількості загальних підходів")
            {
                Base.dialogCriteria = "Загальна_к_сть_підходів";
            }
            Close();
        }

        public void TTrainingSort(String sort, DataGridView dGV, DataView view)
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
