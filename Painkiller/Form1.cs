using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Threading;

namespace Painkiller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            sendMeasure = unitMeasure;
        }

        public static String dialogParameter;
        internal static DataGridView DGV;
        internal static DomainUpDown sendMeasure;


        Legs legs = new Legs();
        Back back = new Back();
        Chest chest = new Chest();
        Arms arms = new Arms();
        Shoulders shoulders = new Shoulders();
        Base doIt;

        String[] exercises;
        String burden = "";
        DialogFiltr filtr = new DialogFiltr();
        DialogSort sortDialog = new DialogSort();
        WriteRead writeRead;

        private void Form1_Load(object sender, EventArgs e)
        {
            doIt = new Base();
            writeRead = new WriteRead();
            DGV = AllTraining;
            AllTraining.DataSource = Base.TabTrain;
            AllTraining.Columns["N_пп"].HeaderText = "№ п/п";
            AllTraining.Columns["Група_мязів"].HeaderText = "Група м\'язів";
            AllTraining.Columns["Вправа"].HeaderText = "Вправа";
            AllTraining.Columns["Вид_тренування"].HeaderText = "Вид тренування";
            AllTraining.Columns["Обтяження"].HeaderText = "Обтяження";
            AllTraining.Columns["Положення"].HeaderText = "Положення";
            AllTraining.Columns["Max_вага"].HeaderText = $"Max вага, {unitMeasure.Text}";
            AllTraining.Columns["К_сть_повторень_з_max_вагою"].HeaderText = "К-сть повторень з max вагою";
            AllTraining.Columns["Загальна_к_сть_підходів"].HeaderText = "Загальна к-сть підходів";
            AllTraining.Columns["N_пп"].Width = 40;
            AllTraining.Columns["Група_мязів"].Width = 100;
            AllTraining.Columns["Вправа"].Width = 230;
            AllTraining.Columns["Вид_тренування"].Width = 230;
            AllTraining.Columns["Обтяження"].Width = 200;
            AllTraining.Columns["Положення"].Width = 180;
            AllTraining.Columns["Max_вага"].Width = 65;
            AllTraining.Columns["К_сть_повторень_з_max_вагою"].Width = 65;
            AllTraining.Columns["Загальна_к_сть_підходів"].Width = 65;
            AllTraining.Columns[0].DefaultCellStyle.BackColor = Color.NavajoWhite;
            AllTraining.Columns[0].DefaultCellStyle.ForeColor = Color.Black;
           
            for (Int32 i = 1; i < AllTraining.ColumnCount; i++)
            {
                if (i % 2 == 0)
                {
                    AllTraining.Columns[i].DefaultCellStyle.BackColor = Color.NavajoWhite;
                }
                else
                {
                    AllTraining.Columns[i].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                }
                AllTraining.Columns[i].DefaultCellStyle.ForeColor = Color.Black;
            }
            doIt.MainRes();

            MinResults.DataSource = Base.TabMinTrain;
            MinResults.Columns["Група_мязів "].HeaderText = "Група_мязів";
            MinResults.Columns["Вправа "].HeaderText = "Вправа";
            MinResults.Columns["Обтяження "].HeaderText = "Обтяження";
            MinResults.Columns["Положення тіла "].HeaderText = "Положення";
            MinResults.Columns["Max_вага "].HeaderText = $"Max вага, {unitMeasure.Text}";
            MinResults.Columns["К_сть_повторень_з_max_вагою "].HeaderText = "К-сть повторень з max вагою";
            MinResults.Columns["Вправа "].Width = 230;
            MinResults.Columns["Обтяження "].Width = 200;
            MinResults.Columns["Положення тіла "].Width = 180;
            MinResults.Columns["Max_вага "].Width = 65;
            MinResults.Columns["К_сть_повторень_з_max_вагою "].Width = 65;
            MinResults.Columns[0].DefaultCellStyle.BackColor = Color.NavajoWhite;
            MinResults.Columns[0].DefaultCellStyle.ForeColor = Color.Black;
            for (Int32 i = 1; i < MinResults.ColumnCount; i++)
            {
                if (i % 2 == 0)
                {
                    MinResults.Columns[i].DefaultCellStyle.BackColor = Color.NavajoWhite;
                }
                else
                {
                    MinResults.Columns[i].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                }
                MinResults.Columns[i].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void записатиТаблицюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Всі вправи внесені у таблицю?", "Питання", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            AddMessage(true, true, writeRead);

            if (result == DialogResult.Yes)
            {
                writeRead.WriteTabFile(true, false);
            }
            else if (result == DialogResult.No)
            {
                writeRead.WriteTabFile(false, false);
            }
        }

        void AddMessage<T>(Boolean pos, Boolean neg, T sender) where T : Base
        {
            if (pos)
            {
                if (MessageEventArgs.CountPosInvoke > 0)
                {
                    sender.MessagePositive -= PositiveMessage;
                }
                sender.MessagePositive += PositiveMessage;
            }

            if (neg)
            {
                if (MessageEventArgs.CountNegInvoke > 0)
                {
                    sender.MessageNegative -= NegativeMessage;
                }
                sender.MessageNegative += NegativeMessage;
            }

        }

        void PositiveMessage(Object sender, MessageEventArgs e)
        {
            MessageBox.Show(e.Message, "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void NegativeMessage(Object sender, MessageEventArgs e)
        {
            MessageBox.Show(e.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void зчитатиТаблицюЗФайлуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMessage(false, true, writeRead);
            writeRead.ReadTabFile(AllTraining);
            doIt.SetSumy(MinResults, unitMeasure);
        }

        private void перезаписатиФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Всі вправи внесені у таблицю?", "Питання", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            AddMessage(true, true, writeRead);

            if (result == DialogResult.Yes)
            {
                writeRead.WriteTabFile(true, true);
            }
            else if (result == DialogResult.No)
            {
                writeRead.WriteTabFile(false, true);
            }
        }



        private void записатиТаблицюВБазуДанихToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMessage(true, true, doIt);

            writeRead.WriteDB(Base.TabTrain, unitMeasure);
        }

        private void зчитатиТаблицюЗБазиДанихToolStripMenuItem_Click(object sender, EventArgs e)
        {
            writeRead.ReadDB(Base.TabTrain, AllTraining);
            doIt.SetSumy(MinResults, unitMeasure);
        }

        private void очиститиТаблицюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear(AllTraining);
            doIt.ClearMax(MinResults);
            MinResults.Columns["Max_вага "].Width = 65;
            MinResults.Columns["К_сть_повторень_з_max_вагою "].Width = 65;
            MinResults.Columns["Max_вага "].HeaderText = $"Max вага, {unitMeasure.Text}";
            MinResults.Columns["К_сть_повторень_з_max_вагою "].HeaderText = "К-сть повторень з max вагою";
            for (Int32 i = 3; i < MinResults.ColumnCount; i++)
            {
                if (i % 2 == 0)
                {
                    MinResults.Columns[i].DefaultCellStyle.BackColor = Color.NavajoWhite;
                }
                else
                {
                    MinResults.Columns[i].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                }
                MinResults.Columns[i].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        void Clear(DataGridView dataGridView)
        {
            while (dataGridView.Rows.Count > 1)
            {
                for (Int32 i = 0; i < dataGridView.Rows.Count - 1; i++)
                {
                    dataGridView.Rows.Remove(dataGridView.Rows[i]);
                }
            }
        }

        private void ввестиКритерійСортуванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sortDialog.ShowDialog();
            sortDialog.TTrainingSort(Base.dialogCriteria, AllTraining, Base.TrainView);
        }
        private void знятиСортуванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sortDialog.TTrainingSort("", AllTraining, Base.TrainView);
        }

        private void ввестиФільтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtr.ShowDialog();
            if (Base.dialogCriteria != "")
            {
                filtr.TTrainingFiltr(Base.dialogCriteria, AllTraining, Base.TrainView);
            }
        }

        private void забратиФільтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtr.TTrainingFiltr("", AllTraining, Base.TrainView);
        }

        private void пошукВправиToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogSeekExercise dialog = new DialogSeekExercise();
            AddMessage(false, true, doIt);
            dialog.ShowDialog();

            AllTraining.DataSource = Base.TabTrain;
        }

        private void RBStatodynamic_CheckedChanged(object sender, EventArgs e)
        {
            if (RBStatodynamic.Checked)
            {
                Base.numTypeTrain = 1;
                Base.typeTrain = RBStatodynamic.Text;
                RepsSets();
                NReps.Value = NReps.Minimum;
            }
        }

        void RepsSets()
        {
            Int32 min, max;
            if (CBGroup.SelectedIndex == 0)
            {
                legs.Reps(out min, out max);
                NReps.Minimum = min;
                NReps.Maximum = max;
                legs.Sets(out min, out max);
                NSets.Minimum = min;
                NSets.Maximum = max;
            }
            else if (CBGroup.SelectedIndex == 1)
            {

                back.Reps(out min, out max);
                NReps.Minimum = min;
                NReps.Maximum = max;
                back.Sets(out min, out max);
                NSets.Minimum = min;
                NSets.Maximum = max;
            }
            else if (CBGroup.SelectedIndex == 2)
            {
                chest.Reps(out min, out max);
                NReps.Minimum = min;
                NReps.Maximum = max;
                chest.Sets(out min, out max);
                NSets.Minimum = min;
                NSets.Maximum = max;
            }
            else if (CBGroup.SelectedIndex == 3)
            {
                arms.Reps(out min, out max);
                NReps.Minimum = min;
                NReps.Maximum = max;
                arms.Sets(out min, out max);
                NSets.Minimum = min;
                NSets.Maximum = max;
            }
            else if (CBGroup.SelectedIndex == 4)
            {
                shoulders.Reps(out min, out max);
                NReps.Minimum = min;
                NReps.Maximum = max;
                shoulders.Sets(out min, out max);
                NSets.Minimum = min;
                NSets.Maximum = max;
            }
        }

        private void RBHipertrophy_CheckedChanged(object sender, EventArgs e)
        {
            if (RBHipertrophy.Checked)
            {
                Base.numTypeTrain = 2;
                Base.typeTrain = RBHipertrophy.Text;
                RepsSets();
                NReps.Value = NReps.Minimum;
            }
        }

        private void RBStrength_CheckedChanged(object sender, EventArgs e)
        {
            if (RBStrength.Checked)
            {
                Base.numTypeTrain = 3;
                Base.typeTrain = RBStrength.Text;
                RepsSets();
                NReps.Value = NReps.Minimum;
            }
        }

        private void CBGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            CBExercise.Text = "";
            CBExercise.Items.Clear();
        }

        private void CBExercise_SelectedIndexChanged(object sender, EventArgs e)
        {
            NReps.Value = NReps.Minimum;
        }

        private void CBExercise_Click(object sender, EventArgs e)
        {
            Int32 min, max;
            Int32 length;
            CBExercise.Items.Clear();
            if (Base.numTypeTrain != 0)
            {
                CBExercise.Text = "";
                if (CBGroup.SelectedIndex == 0)
                {
                    exercises = legs.Exercises();
                    legs.Reps(out min, out max);
                    NReps.Minimum = min;
                    NReps.Maximum = max;
                    legs.Sets(out min, out max);
                    NSets.Minimum = min;
                    NSets.Maximum = max;                    
                }
                else if (CBGroup.SelectedIndex == 1)
                {
                    exercises = back.Exercises();
                    back.Reps(out min, out max);
                    NReps.Minimum = min;
                    NReps.Maximum = max;
                    back.Sets(out min, out max);
                    NSets.Minimum = min;
                    NSets.Maximum = max;
                }
                else if (CBGroup.SelectedIndex == 2)
                {
                    exercises = chest.Exercises();
                    chest.Reps(out min, out max);
                    NReps.Minimum = min;
                    NReps.Maximum = max;
                    chest.Sets(out min, out max);
                    NSets.Minimum = min;
                    NSets.Maximum = max;
                }
                else if (CBGroup.SelectedIndex == 3)
                {
                    exercises = arms.Exercises();
                    arms.Exercises();
                    arms.Reps(out min, out max);
                    NReps.Minimum = min;
                    NReps.Maximum = max;
                    arms.Sets(out min, out max);
                    NSets.Minimum = min;
                    NSets.Maximum = max;
                }
                else if (CBGroup.SelectedIndex == 4)
                {
                    exercises = shoulders.Exercises();
                    shoulders.Exercises();
                    shoulders.Reps(out min, out max);
                    NReps.Minimum = min;
                    NReps.Maximum = max;
                    shoulders.Sets(out min, out max);
                    NSets.Minimum = min;
                    NSets.Maximum = max;
                }
                else
                {
                    MessageBox.Show("Виберіть, будь ласка, групу м\'язів", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                length = exercises.Length;
                for (Int32 i = 0; i < length; i++)
                {
                    CBExercise.Items.Add(exercises[i]);
                }
            }
            else
            {
                MessageBox.Show("Виберіть, будь ласка, спершу вид тренування", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void RBDumb_Bell_CheckedChanged(object sender, EventArgs e)
        {
            if (RBDumb_Bell.Checked == true)
            {
                burden = RBDumb_Bell.Text;
                if (unitMeasure.SelectedIndex == 0)
                {
                    NWeight.Maximum = 150;
                }
                if (unitMeasure.SelectedIndex == 1)
                {
                    NWeight.Maximum = 420;
                }
            }

            if (label5.Location.X != 144)
            {
                label5.Location = new Point(144, label5.Location.Y);
            }
            label5.Text = "Max вага однієї гантелі";
        }

        private void RBBar_CheckedChanged(object sender, EventArgs e)
        {
            if (RBBar.Checked == true)
            {
                burden = RBBar.Text;
                if (unitMeasure.SelectedIndex == 0)
                {
                    NWeight.Maximum = 720;
                }
                if (unitMeasure.SelectedIndex == 1)
                {
                    NWeight.Maximum = 1500;
                }
                if (label5.Location.X != 194)
                {
                    label5.Location = new Point(194, label5.Location.Y);
                }
                label5.Text = "Max вага";
            }
        }

        private void RBBlok_CheckedChanged(object sender, EventArgs e)
        {
            if (RBBlok.Checked == true)
            {
                burden = RBBlok.Text;
                if (unitMeasure.SelectedIndex == 0)
                {
                    NWeight.Maximum = 105;
                }
                if (unitMeasure.SelectedIndex == 1)
                {
                    NWeight.Maximum = 230;
                }
                if (label5.Location.X != 144)
                {
                    label5.Location = new Point(144, label5.Location.Y);
                }
                label5.Text = "Max вага одного блоку";
            }
        }

        private void RBMachine_CheckedChanged(object sender, EventArgs e)
        {
            if (RBMachine.Checked == true)
            {
                burden = RBMachine.Text;
                if (unitMeasure.SelectedIndex == 0)
                {
                    NWeight.Maximum = 720;
                }
                if (unitMeasure.SelectedIndex == 1)
                {
                    NWeight.Maximum = 1500;
                }
                if (label5.Location.X != 194)
                {
                    label5.Location = new Point(194, label5.Location.Y);
                }
                label5.Text = "Max вага";
            }
        }

        private void RBBodyWeight_CheckedChanged(object sender, EventArgs e)
        {
            if (RBBodyWeight.Checked == true)
            {
                burden = RBBodyWeight.Text;
                label5.Location = new Point(168, label5.Location.Y);
                label5.Text = "Додаткова вага";
                NWeight.Minimum = 0;
                NWeight.Value = 0;
            }
        }

        private void BAdd_Click(object sender, EventArgs e)
        {
            if (Base.numTypeTrain == 0)
            {
                MessageBox.Show("Виберіть, будь ласка, вид тренування", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (CBGroup.Text == "")
            {
                MessageBox.Show("Виберіть, будь ласка, групу м\'язів", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (CBExercise.Text == "")
            {
                MessageBox.Show("Виберіть, будь ласка, вправу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (burden == "")
            {
                MessageBox.Show("Виберіть, будь ласка, обтяження", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String position = "";
                foreach (Control control in GBPosition.Controls)
                {
                    RadioButton rb = control as RadioButton;
                    if (rb.Checked)
                    {
                        position = rb.Text;
                    }
                }
                if (position != "")
                {
                    doIt.TTrainingAddRow(CBGroup.Text, CBExercise.Text, RBStatodynamic.Text,
                    burden, position, (Int32)NWeight.Value, (Int32)NReps.Value, (Int32)NSets.Value);
                    AddMessage(false, true, doIt);
                    doIt.SetSumy(MinResults, unitMeasure);
                }
                else
                {
                    MessageBox.Show("Виберіть, будь ласка, положення тіла", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BClear_Click(object sender, EventArgs e)
        {
            CBGroup.Text = "";
            CBExercise.Text = "";
            RBStatodynamic.Checked = false;
            RBHipertrophy.Checked = false;
            RBStrength.Checked = false;
            NReps.Value = NReps.Minimum;
            NSets.Value = NSets.Minimum;
            NWeight.Value = NWeight.Minimum;
        }

        private void unitMeasure_Scroll(object sender, ScrollEventArgs e)
        {
            if (unitMeasure.Text == "кг")
            {
                AllTraining.Columns[4].HeaderText = "Max вага, кг";
                for (Int32 i = 0; i < AllTraining.Rows.Count; i++)
                {
                    Base.TrainView[i]["Max вага, кг"] = (Int32)Base.TrainView[i]["Max вага, кг"];
                }
            }
        }

        private void unitMeasure_SelectedItemChanged(object sender, EventArgs e)
        {
            if (unitMeasure.Text == "кг")
            {
                AllTraining.Columns[6].HeaderText = "Max вага, кг";
                for (Int32 i = 0; i < AllTraining.Rows.Count - 1; i++)
                {
                    Base.TabTrain.Rows[i]["Max_вага"] = Math.Round((Int32)Base.TabTrain.Rows[i]["Max_вага"] * 0.454);
                }
                for (Int32 i = 0; i < MinResults.Rows.Count - 1; i++)
                {
                    MinResults.Columns[4].HeaderText = "Max вага, кг";
                    if (Base.TabMinTrain.Rows[i]["Max_вага "].ToString() != "")
                    {
                        Base.TabMinTrain.Rows[i]["Max_вага "] = Math.Round((Int32)Base.TabMinTrain.Rows[i]["Max_вага "] * 0.454);
                    }
                }
                NWeight.Maximum = 1200;
            }
            else
            {
                AllTraining.Columns[6].HeaderText = "Max вага, lb";
                Int32 j;
                for (Int32 i = 0; i < AllTraining.Rows.Count - 1; i++)
                {
                    j = (Int32)Base.TrainView[i]["Max_вага"];
                    Base.TabTrain.Rows[i]["Max_вага"] = Math.Round((Int32)Base.TabTrain.Rows[i]["Max_вага"] * 2.2046);
                    j = (Int32)Base.TrainView[i]["Max_вага"];
                }
                MinResults.Columns[4].HeaderText = "Max вага, lb";
                for (Int32 i = 0; i < MinResults.Rows.Count - 1; i++)
                {
                    if (Base.TabMinTrain.Rows[i]["Max_вага "].ToString() != "")
                    {
                        Base.TabMinTrain.Rows[i]["Max_вага "] = Math.Round((Int32)Base.TabMinTrain.Rows[i]["Max_вага "] * 2.2046);
                    }
                }
                NWeight.Maximum = 2400;
            }
            AllTraining.DataSource = Base.TrainView;
        }

        private void NWeight_ValueChanged(object sender, EventArgs e)
        {
            if(unitMeasure.Text == "кг")
            {
                NWeight.Maximum = 1200;
            }
            else
            {
                NWeight.Maximum = 2400;
            }
        }
    }
}