using Painkiller.Models.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painkiller.PresentationModels
{
    public partial class MainPresentationModel
    {
        private RelayCommand cbGroupSelectedIndexChangedCommand;


        public RelayCommand CBGroupSelectedIndexChangedCommand =>
            cbGroupSelectedIndexChangedCommand ?? (new RelayCommand(obj =>
            {
                selectedMuscleGroup = MuscleGroup.GetMuscleGroup(cbGroupMuscle.Text);

                if (cbExercise.Items.Count != 0)
                {
                    cbExercise.Text = "";
                    cbExercise.Items.Clear();
                }
            }));

        private RelayCommand cbExerciseSelectedIndexChangedCommand;


        public RelayCommand CBExerciseSelectedIndexChangedCommand =>
            cbExerciseSelectedIndexChangedCommand ?? (new RelayCommand(obj => nReps.Value = nReps.Minimum));

        private RelayCommand cbExerciseClickCommand;


        public RelayCommand CBExerciseClickCommand =>
            cbExerciseClickCommand ?? (new RelayCommand(obj =>
            {
                cbExercise.Items.Clear();

                if (typeTraining != default)
                {
                    cbExercise.Text = "";
                    ChangeIntervalOfReps(selectedMuscleGroup, nReps);
                    ChangeIntervalOfSets(selectedMuscleGroup, nSets);

                    String[] exercisesOfSelectedMuscleGroup = selectedMuscleGroup.GetExercises();
                    cbExercise.Items.AddRange(exercisesOfSelectedMuscleGroup);
                }
            }));
    }
}
