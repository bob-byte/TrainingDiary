using Painkiller.Training;
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

        private Legs legs = new Legs();
        private Back back = new Back();
        private Chest chest = new Chest();
        private Arms arms = new Arms();
        private Shoulders shoulders = new Shoulders();
         
        private String[] exercises;

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

            for (Int32 i = 0; i < exercises.Length; i++)
            {
                CBExercise.Items.Add(exercises[i]);
            }
        }


        private void numExercise_ValueChanged(object sender, EventArgs e)
        {
            if (CBExercise.Text != "" && numExercise.Value != 0)
            {
                SeekExercise(CBExercise.Text, MainForm.SendDialogSeek, (Int32)numExercise.Value);
            }
        }

        private void CBGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            CBExercise.Text = "";
            CBExercise.Items.Clear();
        }
    }
}
