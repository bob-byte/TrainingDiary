using System;
using System.Data;
using System.Windows.Forms;

namespace Painkiller
{
    public partial class Dialog : Form
    {
        public Dialog()
        {
            InitializeComponent();
        }
        
        public string criteria;

        private void ChBGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (ChBGroupWeight.Checked)
            {
                if (ChBGroupWeight.Text == "По назвах груп м\'язів")
                {
                    ChBExercise.Checked = false;
                }
                ChBTypeTrainingReps.Checked = false;
            }
        }

        private void ChBExercise_CheckedChanged(object sender, EventArgs e)
        {
            if (ChBExercise.Checked)
            {
                ChBGroupWeight.Checked = false;
                ChBTypeTrainingReps.Checked = false;
            }
        }

        private void SortFiltr_Click(object sender, EventArgs e)
        {
            if (SortFiltrSearch.Text == "Фільтрувати")
            {
                if (ChBGroupWeight.Checked)
                {
                    criteria = $"Max_вага > {amountWeigthReps.Value}";
                }
                if(ChBTypeTrainingReps.Checked)
                {
                    criteria = $"К_сть_повторень_з_max_вагою > {amountWeigthReps.Value}";
                }
                Close();
            }
            else if(SortFiltrSearch.Text == "Сортувати")
            {
                if (ChBGroupWeight.Checked)
                {
                    criteria = "Група_мязів";
                }
                if (ChBExercise.Checked)
                {
                    criteria = "Вид_тренування";
                }
                if (ChBTypeTrainingReps.Checked)
                {
                    criteria = "Вправа";
                }
                Close();
            }
            else if(SortFiltrSearch.Text == "Шукати")
            {
                criteria = CBExercise.Text;
                Close();
            }
            else
            {
                MessageBox.Show("Виберіть, будь ласка, критерій", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void ChBTypeTraining_CheckedChanged(object sender, EventArgs e)
        {
            if (ChBTypeTrainingReps.Text == "По виду тренувань")
            {
                if (ChBTypeTrainingReps.Checked)
                {
                    ChBExercise.Checked = false;
                }
            }
            ChBGroupWeight.Checked = false;
        }

        private void Dialog_Load(object sender, EventArgs e)
        {
            if(this.Text == "Виберіть, будь ласка, критерій сортування")
            {
                ChBGroupWeight.Text = "По назвах груп м\'язів";
                amountWeigthReps.Visible = false;
                CBGroup.Visible = false;
                CBExercise.Visible = false;
                ChBExercise.Visible = true;
                label1.Visible = false;
                label2.Visible = false;
                ChBExercise.Text = "По назвах вправ";
                ChBTypeTrainingReps.Text = "По виду тренувань";
                SortFiltrSearch.Text = "Сортувати";
            }
            else if(this.Text == "Виберіть, будь ласка, критерій фільтрування")
            {
                ChBExercise.Visible = false;
                CBGroup.Visible = false;
                CBExercise.Visible = false;
                amountWeigthReps.Visible = true;
                label1.Visible = false;
                label2.Visible = false;
                ChBGroupWeight.Text = $"Більше від {amountWeigthReps.Value}кг";
                ChBTypeTrainingReps.Text = $"Більше від {amountWeigthReps.Value} к-сті повторів";
                SortFiltrSearch.Text = "Фільтрувати";
            }
            else
            {
                ChBGroupWeight.Visible = false;
                ChBExercise.Visible = false;
                ChBTypeTrainingReps.Visible = false;
                amountWeigthReps.Visible = false;
                CBGroup.Visible = true;
                CBExercise.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                SortFiltrSearch.Text = "Шукати";
            }
        }

        private void amountWeigthReps_ValueChanged(object sender, EventArgs e)
        {
            ChBGroupWeight.Text = $"Більше від {amountWeigthReps.Value}кг";
            ChBTypeTrainingReps.Text = $"Більше від {amountWeigthReps.Value} к-сті повторів";
        }
        Legs legs = new Legs();
        Back back = new Back();
        Chest chest = new Chest();
        Arms arms = new Arms();
        Shoulders shoulders = new Shoulders();
        private void CBExercise_Click(object sender, EventArgs e)
        {
            CBExercise.Items.Clear();
            if (CBGroup.SelectedIndex == 0)
            {
                CBExercise.Text = "";
                legs.DovGroup.Rows.Clear();
                legs.DovGroup.Columns.Clear();
                legs.Exercises();
                foreach (DataRow r in legs.DovGroup.Rows)
                {
                    CBExercise.Items.Add(r["Вправа"]);
                }
            }
            else if (CBGroup.SelectedIndex == 1)
            {
                CBExercise.Text = "";
                back.DovGroup.Rows.Clear();
                back.DovGroup.Columns.Clear();
                back.Exercises();
                foreach (DataRow r in back.DovGroup.Rows)
                {
                    CBExercise.Items.Add(r["Вправа"]);
                }
            }
            else if (CBGroup.SelectedIndex == 2)
            {
                CBExercise.Text = "";
                chest.DovGroup.Rows.Clear();
                chest.DovGroup.Columns.Clear();
                chest.Exercises();
                foreach (DataRow r in chest.DovGroup.Rows)
                {
                    CBExercise.Items.Add(r["Вправа"]);
                }
            }
            else if (CBGroup.SelectedIndex == 3)
            {
                CBExercise.Text = "";
                arms.DovGroup.Rows.Clear();
                arms.DovGroup.Columns.Clear();
                arms.Exercises();
                foreach (DataRow r in arms.DovGroup.Rows)
                {
                    CBExercise.Items.Add(r["Вправа"]);
                }
            }
            else if (CBGroup.SelectedIndex == 4)
            {
                CBExercise.Text = "";
                shoulders.DovGroup.Rows.Clear();
                shoulders.DovGroup.Columns.Clear();
                shoulders.Exercises();
                foreach (DataRow r in shoulders.DovGroup.Rows)
                {
                    CBExercise.Items.Add(r["Вправа"]);
                }
            }
            else
            {
                MessageBox.Show("Виберіть, будь ласка, групу м\'язів", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
