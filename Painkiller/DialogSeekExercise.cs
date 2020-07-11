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
    public partial class DialogSeekExercise : Form
    {
        public DialogSeekExercise()
        {
            InitializeComponent();
        }

        public delegate void Message(object sender, MessageEventArgs e);
        event Message messageNegative;

        public event Message MessageNegative
        {
            add
            {
                messageNegative += value;
                MessageEventArgs.CountNegInvoke++;
            }
            remove
            {
                messageNegative -= value;
                MessageEventArgs.CountNegInvoke--;
            }
        }

        public void SeekExercise(string name, DataGridView grid, Int32 count)
        {
            int n = 0;
            Int32 num = 0;
            bool isFound = false;
            
            try
            {
                for (int i = 0; i < grid.Rows.Count - 1; i++)
                {
                    if ((string)grid.Rows[i].Cells["Вправа"].Value == name)
                    {
                        num++;
                        if(num == count)
                        {
                            n = i;
                            isFound = true;
                            break;
                        }
                    }
                }
                if (isFound)
                {
                    grid.FirstDisplayedCell = grid.Rows[n].Cells["Вправа"];
                    grid.Rows[n].Selected = true;
                    grid.CurrentCell = grid.Rows[n].Cells["Вправа"];
                }
                else
                {
                    messageNegative?.Invoke(this, new MessageEventArgs($"Не вдається знайти \"{name}\""));
                }
            }
            catch(Exception ex)
            {
                messageNegative?.Invoke(this, new MessageEventArgs(ex.Message));
            }
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


        private void numExercise_ValueChanged(object sender, EventArgs e)
        {
            if (CBExercise.Text != "" && numExercise.Value != 0)
            {
                SeekExercise(CBExercise.Text, Form1.DGV, (Int32)numExercise.Value);
            }
        }
    }
}
