using System;
using System.Windows.Forms;
using System.Drawing;

namespace Painkiller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SendMeasure = unitMeasure.Text;
            SetFreezeComboBoxes();
        }

        private Legs legs = new Legs();
        private Back back = new Back();
        private Chest chest = new Chest();
        private Arms arms = new Arms();
        private Shoulders shoulders = new Shoulders();
        private Base doIt;

        private String[] exercises;
        private String burden = "", typeTraining;
        private DialogFiltr filtr = new DialogFiltr();
        private DialogSort sortDialog = new DialogSort();
        private DialogResult dialogRes;
        private OperationDBFile opFileDB;

        internal static DataGridView SendDialogSeek { get; private set; }
        internal static String SendMeasure { get; private set; }

        private void SetFreezeComboBoxes()
        {
            CBGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            CBExercise.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            doIt = new Base();
            opFileDB = new OperationDBFile();
            SendDialogSeek = AllTraining;
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
            }
            doIt.MainRes();
            AllTraining.Columns["N_пп"].ReadOnly = true;

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
            }
        }

        private void записатиТаблицюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogRes = MessageBox.Show("Всі вправи внесені у таблицю?", "Питання", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            AddMessage(true, true, opFileDB);

            if (dialogRes == DialogResult.Yes)
            {
                opFileDB.WriteTabInFile(true, SendMeasure);
            }
            else if (dialogRes == DialogResult.No)
            {
                opFileDB.WriteTabInFile(false, SendMeasure);
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
            AddMessage(false, true, opFileDB);
            opFileDB.ReadTabFile(AllTraining, SendMeasure);
            doIt.SetSumy(MinResults, unitMeasure);
        }

        private void перезаписатиФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMessage(true, true, opFileDB);
            dialogRes = MessageBox.Show("Видалити інформацію, яка не була змінена?",
                "Питання", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            DialogResult dialogResult = MessageBox.Show("Додати вправу(-и) до попереднього дня?",
                "Питання", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogRes == DialogResult.Yes)
            {
                opFileDB.RewriteFile(false, SendMeasure, dialogResult == DialogResult.Yes);
            }
            else if (dialogRes == DialogResult.No)
            {
                opFileDB.RewriteFile(true, SendMeasure, dialogResult == DialogResult.Yes);
            }
        }



        private void записатиТаблицюВБазуДанихToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMessage(true, true, opFileDB);

            opFileDB.WriteDB(Base.TabTrain, unitMeasure.Text);
        }

        private void зчитатиТаблицюЗБазиДанихToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opFileDB.ReadDB(Base.TabTrain, AllTraining);
            doIt.SetSumy(MinResults, unitMeasure);
        }

        private void очиститиТаблицюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogRes = MessageBox.Show("Ви впевнені, що хочете очистити таблиці? Повернути незаписані дані буде неможливо",
                "Попередження", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogRes == DialogResult.Yes)
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

        private void очиститиГоловнуТаблицюБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogRes = MessageBox.Show("Ви впевнені, що хочете очистити головну таблицю в базі даних? Повернути незаписані дані буде неможливо",
                "Попередження", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogRes == DialogResult.Yes)
            {
                AddMessage(true, true, opFileDB);
                opFileDB.ClearMainTabDB();
            }
        }

        private void ввестиКритерійСортуванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogRes = sortDialog.ShowDialog();
            sortDialog.TTrainingSort(Base.DialogCriteria, AllTraining, Base.TrainView);
        }
        private void знятиСортуванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sortDialog.TTrainingSort("", AllTraining, Base.TrainView);
        }

        private void ввестиФільтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtr.ShowDialog();
            if (Base.DialogCriteria != "")
            {
                filtr.TTrainingFiltr(Base.DialogCriteria, AllTraining, Base.TrainView);
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
                Base.NumTypeTrain = 1;
                RepsSets();
                NReps.Value = NReps.Minimum;
                typeTraining = RBStatodynamic.Text;
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
                Base.NumTypeTrain = 2;
                RepsSets();
                NReps.Value = NReps.Minimum;
                typeTraining = RBHipertrophy.Text;
            }
        }

        private void RBStrength_CheckedChanged(object sender, EventArgs e)
        {
            if (RBStrength.Checked)
            {
                Base.NumTypeTrain = 3;
                RepsSets();
                NReps.Value = NReps.Minimum;
                typeTraining = RBStrength.Text;
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
            CBExercise.Items.Clear();
            if (Base.NumTypeTrain != 0)
            {
                CBExercise.Text = "";
                if (CBGroup.SelectedIndex == 0)
                {
                    InitTrain(legs);
                }
                else if (CBGroup.SelectedIndex == 1)
                {
                    InitTrain(back);
                }
                else if (CBGroup.SelectedIndex == 2)
                {
                    InitTrain(chest);
                }
                else if (CBGroup.SelectedIndex == 3)
                {
                    InitTrain(arms);
                }
                else if (CBGroup.SelectedIndex == 4)
                {
                    InitTrain(shoulders);
                }
                else
                {
                    MessageBox.Show("Виберіть, будь ласка, групу м\'язів", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Int32 length = exercises.Length;
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

        internal void InitTrain(IPainKiller group)
        {
            Int32 min, max;
            exercises = group.Exercises();
            group.Reps(out min, out max);
            NReps.Minimum = min;
            NReps.Maximum = max;
            group.Sets(out min, out max);
            NSets.Minimum = min;
            NSets.Maximum = max;
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
            if (Base.NumTypeTrain == 0)
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
                    doIt.TTrainingAddRow(CBGroup.Text, CBExercise.Text, typeTraining,
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
            CBGroup.SelectedIndex = -1;
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
            Boolean isKg;
            if (unitMeasure.Text == "кг")
            {
                AllTraining.Columns[6].HeaderText = "Max вага, кг";
                MinResults.Columns[4].HeaderText = "Max вага, кг";
                NWeight.Maximum = 1200;

                isKg = true;
            }
            else
            {
                AllTraining.Columns[6].HeaderText = "Max вага, lb";
                MinResults.Columns[4].HeaderText = "Max вага, lb";
                NWeight.Maximum = 2400;

                isKg = false;
            }
            doIt.GetValueMeasure(isKg);
            AllTraining.DataSource = Base.TrainView;
        }

        private void AllTraining_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.ColumnIndex != 0)
            {
                for (Int32 i = 0; i < AllTraining.Rows.Count - 1; i++)
                {
                    AllTraining.Rows[i].Cells["N_пп"].Value = i + 1;
                }
            }
        }
    }
}