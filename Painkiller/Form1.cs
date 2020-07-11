using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace Painkiller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            //пошукВправиToolStripMenuItem.Click += new EventHandler(пошукВправиToolStripMenuItem_Click_1);
        }

        internal static DataGridView DGV;

        private void пошукВправиToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogSeekExercise dialog = new DialogSeekExercise();

            if (MessageEventArgs.CountNegInvoke > 0)
            {
                dialog.MessageNegative -= NegativeMessage;
            }
            dialog.MessageNegative += NegativeMessage;

            dialog.ShowDialog();
            
            AllTraining.DataSource = Base.TabTrain;
        }

        WorkDB database = new WorkDB();



        void Clear(DataGridView dataGridView)
        {
            while (dataGridView.Rows.Count > 1)
            {
                for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                {
                    dataGridView.Rows.Remove(dataGridView.Rows[i]);
                }
            }
        }
        void ChoicePosition()
        {
            position = "";
            foreach(Control control in groupBox3.Controls)
            {
                RadioButton rb = control as RadioButton;
                if(rb.Checked)
                {
                    position = rb.Text;
                }
            }
            if(position == "")
            {
                MessageBox.Show("Виберіть, будь ласка, положення тіла", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static string dialogParameter;
        string burden, position;
        Base doIt;
        private void button1_Click(object sender, EventArgs e)
        {
            if (Base.numTypeTrain == 0)
            {
                MessageBox.Show("Виберіть, будь ласка, вид тренування", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (CBGroup.Items[1] == null)
            {
                MessageBox.Show("Виберіть, будь ласка, групу м\'язів", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (CBExercise.Items[1] == null)
            {
                MessageBox.Show("Виберіть, будь ласка, вправу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (RBStatodynamic.Checked)
                {
                    ChoicePosition();
                    if (position != "")
                    {
                        doIt.TTrainingAddRow(CBGroup.Text, CBExercise.Text, RBStatodynamic.Text,
                            burden, position, (int)NWeight.Value, (int)NReps.Value, (int)NSets.Value);
                    }
                }
                if (RBHipertrophy.Checked)
                {
                    ChoicePosition();
                    if (position != "")
                    {
                        doIt.TTrainingAddRow(CBGroup.Text, CBExercise.Text, RBHipertrophy.Text,
                        burden, position, (int)NWeight.Value, (int)NReps.Value, (int)NSets.Value);
                    }
                }
                if (RBStrength.Checked)
                {
                    ChoicePosition();
                    if (position != "")
                    {
                        doIt.TTrainingAddRow(CBGroup.Text, CBExercise.Text, RBStrength.Text,
                        burden, position, (int)NWeight.Value, (int)NReps.Value, (int)NSets.Value);
                    }
                }
                doIt.SetSumy(MinResults, unitMeasure);
                MinResults.Columns["Max_вага "].Width = 65;
                MinResults.Columns["К_сть_повторень_з_max_вагою "].Width = 65;
                MinResults.Columns["Max_вага "].HeaderText = $"Max вага, {unitMeasure.Text}";
                MinResults.Columns["К_сть_повторень_з_max_вагою "].HeaderText = "К-сть повторень з max вагою";
                for (int i = 3; i < MinResults.ColumnCount; i++)
                {
                    if (i % 2 == 0)
                    {
                        MinResults.Columns[i].DefaultCellStyle.BackColor = Color.Black;
                        MinResults.Columns[i].DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        MinResults.Columns[i].DefaultCellStyle.BackColor = Color.Red;
                        MinResults.Columns[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }
        Legs legs = new Legs();
        Back back = new Back();
        Chest chest = new Chest();
        Arms arms = new Arms();
        Shoulders shoulders = new Shoulders();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CBExercise.Text = "";
            CBExercise.Items.Clear();

        }
        private void button2_Click(object sender, EventArgs e)
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (RBStatodynamic.Checked)
            {
                Base.numTypeTrain = 1;
                Base.typeTrain = RBStatodynamic.Text;
                RepsSets();
                NReps.Value = NReps.Minimum;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (RBHipertrophy.Checked)
            {
                Base.numTypeTrain = 2;
                Base.typeTrain = RBHipertrophy.Text;
                RepsSets();
                NReps.Value = NReps.Minimum;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (RBStrength.Checked)
            {
                Base.numTypeTrain = 3;
                Base.typeTrain = RBStrength.Text;
                RepsSets();
                NReps.Value = NReps.Minimum;
            }
        }

        private void очиститиТаблицюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear(AllTraining);
            doIt.ClearMax(MinResults);
            MinResults.Columns["Max_вага "].Width = 65;
            MinResults.Columns["К_сть_повторень_з_max_вагою "].Width = 65;
            MinResults.Columns["Max_вага "].HeaderText = $"Max вага, {unitMeasure.Text}";
            MinResults.Columns["К_сть_повторень_з_max_вагою "].HeaderText = "К-сть повторень з max вагою";
            for (int i = 3; i < MinResults.ColumnCount; i++)
            {
                if (i % 2 == 0)
                {
                    MinResults.Columns[i].DefaultCellStyle.BackColor = Color.Black;
                    MinResults.Columns[i].DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    MinResults.Columns[i].DefaultCellStyle.BackColor = Color.Red;
                    MinResults.Columns[i].DefaultCellStyle.ForeColor = Color.Black;
                }
            }            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            doIt = new Base();
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
            AllTraining.Columns[0].DefaultCellStyle.BackColor = Color.Black;
            AllTraining.Columns[0].DefaultCellStyle.ForeColor = Color.Red;
            for (int i = 1; i < AllTraining.ColumnCount; i++)
            {
                if (i % 2 == 0)
                {
                    AllTraining.Columns[i].DefaultCellStyle.BackColor = Color.Black;
                    AllTraining.Columns[i].DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    AllTraining.Columns[i].DefaultCellStyle.BackColor = Color.Red;
                    AllTraining.Columns[i].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
            doIt.MainRes();
            MinResults.DataSource = doIt.TabMinTrain;
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
            MinResults.Columns[0].DefaultCellStyle.BackColor = Color.Black;
            MinResults.Columns[0].DefaultCellStyle.ForeColor = Color.Red;
            for (int i = 1; i < MinResults.ColumnCount; i++)
            {
                if (i % 2 == 0)
                {
                    MinResults.Columns[i].DefaultCellStyle.BackColor = Color.Black;
                    MinResults.Columns[i].DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    MinResults.Columns[i].DefaultCellStyle.BackColor = Color.Red;
                    MinResults.Columns[i].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        void PositiveMessage(object sender, MessageEventArgs e)
        {
            MessageBox.Show(e.Message, "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void NegativeMessage(object sender, MessageEventArgs e)
        {
             MessageBox.Show(e.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void записатиТаблицюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Всі вправи внесені у таблицю?", "Питання", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (MessageEventArgs.CountPosInvoke > 0)
            {
                doIt.MessagePositive -= PositiveMessage;
            }
            if (MessageEventArgs.CountNegInvoke > 0)
            {
                doIt.MessageNegative -= NegativeMessage;
            }
            doIt.MessagePositive += PositiveMessage;
            doIt.MessageNegative += NegativeMessage;
            if (result == DialogResult.Yes)
            {
                doIt.WriteTabFile(true);
            }
            else if(result == DialogResult.No)
            {
                doIt.WriteTabFile(false);
            }
        }

        private void зчитатиТаблицюЗФайлуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageEventArgs.CountNegInvoke > 0)
            {
                doIt.MessageNegative -= NegativeMessage;
            }
            doIt.MessageNegative += NegativeMessage;
            doIt.ReadTabFile(AllTraining);
            doIt.SetSumy(MinResults, unitMeasure);
        }

        private void ввестиКритерійСортуванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialog SortDialog = new Dialog();
            SortDialog.Text = "Виберіть, будь ласка, критерій сортування";
            SortDialog.ShowDialog();
            dialogParameter = SortDialog.criteria;
            doIt.TTrainingSort(dialogParameter, AllTraining);
        }
        private void знятиСортуванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doIt.TTrainingSort("", AllTraining);
        }
        void RepsSets()
        {
            int min, max;
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
        private void CBExercise_Click(object sender, EventArgs e)
        {
            int min, max;
            CBExercise.Items.Clear();
            if (Base.numTypeTrain != 0)
            {
                CBExercise.Text = "";
                if (CBGroup.SelectedIndex == 0)
                {
                    //замінити наступні рядки коду на метод з параметром типу Base
                    legs.DovGroup.Rows.Clear();
                    legs.DovGroup.Columns.Clear();
                    legs.Exercises();
                    legs.Reps(out min, out max);
                    NReps.Minimum = min;
                    NReps.Maximum = max;
                    legs.Sets(out min, out max);
                    NSets.Minimum = min;
                    NSets.Maximum = max;
                    foreach (DataRow r in legs.DovGroup.Rows)
                    {
                        CBExercise.Items.Add(r["Вправа"]);
                    }
                }
                else if (CBGroup.SelectedIndex == 1)
                {
                    back.DovGroup.Rows.Clear();
                    back.DovGroup.Columns.Clear();
                    back.Exercises();
                    back.Reps(out min, out max);
                    NReps.Minimum = min;
                    NReps.Maximum = max;
                    back.Sets(out min, out max);
                    NSets.Minimum = min;
                    NSets.Maximum = max;
                    foreach (DataRow r in back.DovGroup.Rows)
                    {
                        CBExercise.Items.Add(r["Вправа"]);
                    }
                }
                else if (CBGroup.SelectedIndex == 2)
                {
                    chest.DovGroup.Rows.Clear();
                    chest.DovGroup.Columns.Clear();
                    chest.Exercises();
                    chest.Reps(out min, out max);
                    NReps.Minimum = min;
                    NReps.Maximum = max;
                    chest.Sets(out min, out max);
                    NSets.Minimum = min;
                    NSets.Maximum = max;
                    foreach (DataRow r in chest.DovGroup.Rows)
                    {
                        CBExercise.Items.Add(r["Вправа"]);
                    }
                }
                else if (CBGroup.SelectedIndex == 3)
                {
                    arms.DovGroup.Rows.Clear();
                    arms.DovGroup.Columns.Clear();
                    arms.Exercises();
                    arms.Reps(out min, out max);
                    NReps.Minimum = min;
                    NReps.Maximum = max;
                    arms.Sets(out min, out max);
                    NSets.Minimum = min;
                    NSets.Maximum = max;
                    foreach (DataRow r in arms.DovGroup.Rows)
                    {
                        CBExercise.Items.Add(r["Вправа"]);
                    }
                }
                else if (CBGroup.SelectedIndex == 4)
                {
                    shoulders.DovGroup.Rows.Clear();
                    shoulders.DovGroup.Columns.Clear();
                    shoulders.Exercises();
                    shoulders.Reps(out min, out max);
                    NReps.Minimum = min;
                    NReps.Maximum = max;
                    shoulders.Sets(out min, out max);
                    NSets.Minimum = min;
                    NSets.Maximum = max;
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
            else
            {
                MessageBox.Show("Виберіть, будь ласка, спершу вид тренування", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ввестиФільтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialog filtr = new Dialog();
            filtr.Text = "Виберіть, будь ласка, критерій фільтрування";
            filtr.ShowDialog();
            if (dialogParameter != "")
            {
                dialogParameter = filtr.criteria;
                doIt.TTrainingFiltr(dialogParameter, AllTraining);
            }
        }
        private void забратиФільтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doIt.TTrainingFiltr("", AllTraining);
        }
        private void пошукВправиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialog search = new Dialog();
            search.Text = "Пошук вправи";
            search.ShowDialog();
            //doIt.SeekExercise(dialogParameter, AllTraining);
        }
        

        private void записатиТаблицюВБазуДанихToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageEventArgs.CountPosInvoke > 0)
            {
                database.MessagePositive -= PositiveMessage;
            }
            if (MessageEventArgs.CountNegInvoke > 0)
            {
                database.MessageNegative -= NegativeMessage;
            }
            database.MessagePositive += PositiveMessage;
            database.MessageNegative += NegativeMessage;
            database.WriteGrid(Base.TabTrain, unitMeasure);
            //SqlConnection connect = new SqlConnection();
            //SqlCommand command = new SqlCommand();
            //command.Connection = connect;
            //command.CommandType = CommandType.StoredProcedure;
            //connect.ConnectionString = "Data Source = (local)\\SQLEXPRESS; Initial Catalog = Training; " +
            //    "Integrated Security = True";
            //connect.Open();                              //відкрили з'єднання
            //SqlTransaction tranPlSave = connect.BeginTransaction("tranPlSave");
            //command.Transaction = tranPlSave;
            //command.Parameters.Clear();
            //try
            //{
            //    //command.CommandText = "spClearTrain"; //назначили команді сторед-процедуру для очищення таблиці склад у базі
            //    //command.ExecuteNonQuery();//Очистити таблицю склад у базі
            //    command.CommandText = "spWriteTrain";
            //    foreach (DataRow rr in doIt.TabTrain.Rows)
            //    {
            //        command.Parameters.Clear();
            //        SqlParameter par1 = new SqlParameter("@N_pp", SqlDbType.Int);
            //        par1.Value = rr["N_пп"];
            //        SqlParameter par2 = new SqlParameter(@"groupMuscle", SqlDbType.NVarChar, 50);
            //        par2.Value = rr["Група_мязів"];
            //        SqlParameter par3 = new SqlParameter("@typeTraining", SqlDbType.NVarChar);
            //        par3.Value = rr["Вид_тренування"];
            //        SqlParameter par4 = new SqlParameter(@"exercise", SqlDbType.NVarChar, 255);
            //        par4.Value = rr["Вправа"];
            //        SqlParameter par5 = new SqlParameter(@"encumbrance", SqlDbType.NVarChar, 255);
            //        par5.Value = rr["Обтяження"];
            //        SqlParameter par6 = new SqlParameter(@"position", SqlDbType.NVarChar, 255);
            //        par6.Value = rr["Положення"];
            //        String parNameWeight;
            //        if (unitMeasure.Text == "кг")
            //        {
            //            parNameWeight = @"weightKg";
            //        }
            //        else
            //        {
            //            parNameWeight = @"weightLb";
            //        }
            //        SqlParameter par7 = new SqlParameter(parNameWeight, SqlDbType.Int);
            //        par7.Value = rr["Max_вага"];
            //        SqlParameter par8 = new SqlParameter(@"reps", SqlDbType.Int);
            //        par8.Value = rr["К_сть_повторень_з_max_вагою"];
            //        SqlParameter par9 = new SqlParameter(@"sets", SqlDbType.Int);
            //        par9.Value = rr["Загальна_к_сть_підходів"];
            //        command.Parameters.Add(par1);
            //        command.Parameters.Add(par2);
            //        command.Parameters.Add(par3);
            //        command.Parameters.Add(par4);
            //        command.Parameters.Add(par5);
            //        command.Parameters.Add(par6);
            //        command.Parameters.Add(par7);
            //        command.Parameters.Add(par8);
            //        command.Parameters.Add(par9);
            //        command.ExecuteNonQuery();
            //    }
            //    tranPlSave.Commit();//підтвердження всіх змін у базі даних
            //}
            //catch
            //{

            //    tranPlSave.Rollback();//Виконати відкад у випадку невдалого записування
            //}
            //connect.Close();
            //MessageBox.Show("Таблиця записана у базу даних", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void зчитатиТаблицюЗБазиДанихToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SqlConnection connect = new SqlConnection();
            //SqlCommand com = new SqlCommand();
            //com.Connection = connect;
            //com.CommandType = CommandType.StoredProcedure;
            //com.CommandText = "spTrainTabRead";
            //connect.ConnectionString = "Data Source = (local)\\SQLEXPRESS; Initial Catalog = Painkiller; " +
            //    "Integrated Security = True";
            //connect.Open();
            //SqlDataReader SqlLn = com.ExecuteReader();
            //doIt.TabTrain.Rows.Clear();
            //while (SqlLn.Read())
            //{
            //    DataRow row = doIt.TabTrain.NewRow();
            //    row["N_пп"] = SqlLn.GetInt32(0);
            //    row["Група_мязів"] = SqlLn.GetString(1);
            //    row["Вид_тренування"] = SqlLn.GetString(2);
            //    row["Вправа"] = SqlLn.GetString(3);
            //    row["Обтяження"] = SqlLn.GetString(4);
            //    row["Положення"] = SqlLn.GetString(5);
            //    if(SqlLn.GetInt32(6) != 0)
            //    {
            //        row["Max_вага"] = SqlLn.GetInt32(6);
            //    }
            //    else if(SqlLn.GetInt32(7) != 0)
            //    {
            //        row["Max_вага"] = SqlLn.GetInt32(7);
            //    }
            //    else
            //    {
            //        row["Max_вага"] = 0;
            //    }
            //    row["К_сть_повторень_з_max_вагою"] = SqlLn.GetInt32(8);
            //    row["Загальна_к_сть_підходів"] = SqlLn.GetInt32(9);
            //    doIt.TabTrain.Rows.Add(row);
            //}
            //connect.Close();
            database.ReadDatabase(Base.TabTrain, AllTraining);
            doIt.SetSumy(MinResults, unitMeasure);
        }

        

        private void RBDumb_Bell_CheckedChanged(object sender, EventArgs e)
        {
            if(RBDumb_Bell.Checked == true)
            {
                burden = RBDumb_Bell.Text;
                if(unitMeasure.SelectedIndex == 0)
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
            if(RBBar.Checked == true)
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

        private void unitMeasure_Scroll(object sender, ScrollEventArgs e)
        {
            if(unitMeasure.Text == "кг")
            {
                AllTraining.Columns[4].HeaderText = "Max вага, кг";
                for (Int32 i = 0; i < AllTraining.Rows.Count; i++)
                {
                    doIt.TrainView[i]["Max вага, кг"] = (Int32)doIt.TrainView[i]["Max вага, кг"] ; 
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
                    doIt.TrainView[i]["Max_вага"] = Math.Round((Int32)doIt.TrainView[i]["Max_вага"] * 0.454);
                }
                for (Int32 i = 0; i < MinResults.Rows.Count - 1; i++)
                {
                    MinResults.Columns[4].HeaderText = "Max вага, кг";
                    if (doIt.TabMinTrain.Rows[i]["Max_вага "].ToString() != "")
                    {
                        doIt.TabMinTrain.Rows[i]["Max_вага "] = Math.Round((Int32)doIt.TabMinTrain.Rows[i]["Max_вага "] * 0.454);
                    }
                }
            }
            else
            {
                AllTraining.Columns[6].HeaderText = "Max вага, lb";
                for (Int32 i = 0; i < AllTraining.Rows.Count - 1; i++)
                {
                    doIt.TrainView[i]["Max_вага"] = Math.Round((Int32)doIt.TrainView[i]["Max_вага"] * 2.2046);
                }
                for (Int32 i = 0; i < MinResults.Rows.Count - 1; i++)
                {
                    MinResults.Columns[4].HeaderText = "Max вага, lb";
                    if (doIt.TabMinTrain.Rows[i]["Max_вага "].ToString() != "")
                    {
                        doIt.TabMinTrain.Rows[i]["Max_вага "] = Math.Round((Int32)doIt.TabMinTrain.Rows[i]["Max_вага "] * 2.2046);
                    }
                }
            }
        }

        private void CBExercise_SelectedIndexChanged(object sender, EventArgs e)
        {
            NReps.Value = NReps.Minimum;
        }

    }
}