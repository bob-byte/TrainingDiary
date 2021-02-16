using System;
using System.Windows.Forms;

namespace Painkiller
{
    public partial class WeightRepsSetsFiltr : Form
    {
        private String logicOperation = "Більше";

        public WeightRepsSetsFiltr()
        {
            InitializeComponent();

            //AllTrainingTableContext.DialogCriteria = "";

            CBWeight.Text = $"{logicOperation} від {NUDCountWeigthRepsSets.Value}{MainForm.SendMeasure}";
            CBReps.Text = $"{logicOperation} від {NUDCountWeigthRepsSets.Value} к-сті повторів";
            CBSets.Text = $"{logicOperation} від {NUDCountWeigthRepsSets.Value} к-сті підходів";
        }

        private void WeightRepsSetsFiltr_FormClosed(object sender, FormClosedEventArgs e)
        {
            String textFilter = "";
            Boolean isChecked = false;
            
            foreach (CheckBox checkBox in checkBoxes.Controls)
            {
                if (isChecked && checkBox.Checked)
                {
                    if(checkBox.Text.Contains(MainForm.SendMeasure))
                    {
                        textFilter += $" AND Max_вага {DUDMoreOrLess.Text} {NUDCountWeigthRepsSets.Value}";
                    }
                    else if (checkBox.Text.Contains("повторів"))
                    {
                        textFilter += $" AND К_сть_повторень_з_max_вагою {DUDMoreOrLess.Text} {NUDCountWeigthRepsSets.Value}";
                    }
                    else if (checkBox.Text.Contains("підходів"))
                    {
                        textFilter += $" AND Загальна_к_сть_підходів {DUDMoreOrLess.Text} {NUDCountWeigthRepsSets.Value}";
                    }
                }
                else if (checkBox.Checked)
                {
                    if (checkBox.Text.Contains(MainForm.SendMeasure))
                    {
                        textFilter += $"Max_вага {DUDMoreOrLess.Text} {NUDCountWeigthRepsSets.Value}";
                    }
                    else if (checkBox.Text.Contains("повторів"))
                    {
                        textFilter += $"К_сть_повторень_з_max_вагою {DUDMoreOrLess.Text} {NUDCountWeigthRepsSets.Value}";
                    }
                    else if (checkBox.Text.Contains("підходів"))
                    {
                        textFilter += $"Загальна_к_сть_підходів {DUDMoreOrLess.Text} {NUDCountWeigthRepsSets.Value}";
                    }
                    isChecked = true;
                }
            }

            if (isChecked)
            {
                //AllTrainingTableContext.DialogCriteria = textFilter;
            }
        }

        private void DUDMoreOrLess_SelectedItemChanged(object sender, EventArgs e)
        {
            if(DUDMoreOrLess.Text == ">")
            {
                logicOperation = "Більше";

                foreach (CheckBox checkBox in checkBoxes.Controls)
                {
                    checkBox.Text = checkBox.Text.Replace("Менше", logicOperation);
                }
            }
            else if(DUDMoreOrLess.Text == "<")
            {
                logicOperation = "Менше";

                foreach (CheckBox checkBox in checkBoxes.Controls)
                {
                    checkBox.Text = checkBox.Text.Replace("Більше", logicOperation);
                }
            }
        }

        private void NUDCountWeigthRepsSets_ValueChanged(object sender, EventArgs e)
        {
            CBWeight.Text = $"{logicOperation} від {NUDCountWeigthRepsSets.Value}{MainForm.SendMeasure}";
            CBReps.Text = $"{logicOperation} від {NUDCountWeigthRepsSets.Value} к-сті повторів";
            CBSets.Text = $"{logicOperation} від {NUDCountWeigthRepsSets.Value} к-сті підходів";
        }
    }
}
