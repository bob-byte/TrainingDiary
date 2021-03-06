﻿using Painkiller.Models.Training;
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
    public partial class ExerciseFiltr : Form, IDialogFilter
    {
        public ExerciseFiltr()
        {
            InitializeComponent();
            //AllTrainingTableContext.DialogCriteria = "";
        }

        private Legs legs = new Legs();
        private Back back = new Back();
        private Chest chest = new Chest();
        private Arms arms = new Arms();
        private Shoulders shoulders = new Shoulders();

        private String[] exercises;

        internal List<String> selectedExercises = new List<String>();

        private void CBExercise_Click(object sender, EventArgs e)
        {
            CBExercise.Items.Clear();
            CBExercise.Text = "";

            if (CBGroup.SelectedIndex == 0)
            {
                exercises = legs.GetExercises();
            }
            else if (CBGroup.SelectedIndex == 1)
            {
                exercises = back.GetExercises();
            }
            else if (CBGroup.SelectedIndex == 2)
            {
                exercises = chest.GetExercises();
            }
            else if (CBGroup.SelectedIndex == 3)
            {
                exercises = arms.GetExercises();
            }
            else if (CBGroup.SelectedIndex == 4)
            {
                exercises = shoulders.GetExercises();
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

        public String GetFilterCriteria()
        {
            String textFilter = "";

            if (selectedExercises.Count != 0)
            {
                textFilter += $"Вправа = '{selectedExercises[0]}'";
            }
            else
            {
                return textFilter;
            }

            for (Int32 i = 1; i < selectedExercises.Count; i++)
            {
                textFilter += $" OR Вправа = '{selectedExercises[i]}'";
            }

            return textFilter;
        }

        private void CBGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            CBExercise.Text = "";
            CBExercise.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectedExercises.Add(CBExercise.Text);
        }
    }
}
