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
    public partial class DialogSort : Form/*, IDialogService*/
    {
        public String DialogCriteria { get; private set; }

        public DialogSort()
        {
            InitializeComponent();
            DialogCriteria = "";
        }

        private void SortFiltrSearch_Click(object sender, EventArgs e)
        {
            if (CBTypeSort.Text == "По групах м'язів")
            {
                DialogCriteria = "Група_мязів";
            }
            else if (CBTypeSort.Text == "По видах тренувань")
            {
                DialogCriteria = "Вид_тренування";
            }
            else if (CBTypeSort.Text == "По вправах")
            {
                DialogCriteria = "Вправа";
            }
            else if (CBTypeSort.Text == "По обтяженнях")
            {
                DialogCriteria = "Обтяження";
            }
            else if(CBTypeSort.Text == "По положеннях тіла")
            {
                DialogCriteria = "Положення";
            }
            else if (CBTypeSort.Text == "По max вазі")
            {
                DialogCriteria = "Max_вага";
            }
            else if (CBTypeSort.Text == "По кількості повторень з max вагою")
            {
                DialogCriteria = "К_сть_повторень_з_max_вагою";
            }
            else if (CBTypeSort.Text == "По кількості загальних підходів")
            {
                DialogCriteria = "Загальна_к_сть_підходів";
            }

            Close();
        }

        public void TTrainingSort(String sort, DataGridView dGV, DataView view)
        {
            

            dGV.DataSource = view;

            
        }

        public void Filtering(String DialogCriteria, DataView view)
        {
            if (DialogCriteria != "")
            {
                if (RBGrowth.Checked)
                {
                    view.Sort = $"{DialogCriteria} ASC";
                }
                else if (RBHorning.Checked)
                {
                    view.Sort = $"{DialogCriteria} DESC";
                }
                else
                {
                    return;
                }
            }
            else
            {
                view.Sort = DialogCriteria;
            }
        }
    }
}
