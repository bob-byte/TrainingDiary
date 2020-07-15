using System;
using System.Windows.Forms;

namespace Painkiller
{
    public partial class DialogSeekExercise : Form
    {
        public DialogSeekExercise()
        {
            InitializeComponent();
        }

        Legs legs = new Legs();
        Back back = new Back();
        Chest chest = new Chest();
        Arms arms = new Arms();
        Shoulders shoulders = new Shoulders();

        String[] exercises;

        public void SeekExercise(String name, DataGridView grid, Int32 count)
        {
            Int32 numElement = 0;
            Int32 j = 0;
            Boolean isFound = false;
            
            try
            {
                for (Int32 i = 0; i < grid.Rows.Count - 1; i++)
                {
                    if ((String)grid.Rows[i].Cells["Вправа"].Value == name)
                    {
                        j++;
                        if(j == count)
                        {
                            numElement = i;
                            isFound = true;
                            break;
                        }
                    }
                }
                if (isFound)
                {
                    grid.FirstDisplayedCell = grid.Rows[numElement].Cells["Вправа"];
                    grid.Rows[numElement].Selected = true;
                    grid.CurrentCell = grid.Rows[numElement].Cells["Вправа"];
                }
                else
                {
                    MessageBox.Show($"Вправу \"{name}\" не вдалося знайти", "Невдача", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        

        private void CBExercise_Click(object sender, EventArgs e)
        {
            CBExercise.Items.Clear();
            CBExercise.Text = "";
            Int32 length;

            if (CBGroup.SelectedIndex == 0)
            {
                exercises = legs.Exercises();
            }
            else if (CBGroup.SelectedIndex == 1)
            {
                exercises = back.Exercises();
            }
            else if (CBGroup.SelectedIndex == 2)
            {
                exercises = chest.Exercises();
            }
            else if (CBGroup.SelectedIndex == 3)
            {
                exercises = arms.Exercises();
            }
            else if (CBGroup.SelectedIndex == 4)
            {
                exercises = shoulders.Exercises();
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


        private void numExercise_ValueChanged(object sender, EventArgs e)
        {
            if (CBExercise.Text != "" && numExercise.Value != 0)
            {
                SeekExercise(CBExercise.Text, Form1.sendDialogSeek, (Int32)numExercise.Value);
            }
        }

        private void CBGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            CBExercise.Text = "";
            CBExercise.Items.Clear();
        }

    }
}
