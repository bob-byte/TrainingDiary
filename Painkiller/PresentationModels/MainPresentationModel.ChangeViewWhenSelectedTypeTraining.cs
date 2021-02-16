using Painkiller.Models.Training;
using System;
using System.Windows.Forms;

namespace Painkiller.PresentationModels
{
    public partial class MainPresentationModel
    {
        private RelayCommand changeViewWhenSelectedTypeTrainingCommand;

        public RelayCommand ChangeViewWhenSelectedTypeTrainingCommand => 
            changeViewWhenSelectedTypeTrainingCommand ?? (new RelayCommand(obj =>
            {
                typeTraining = GetSelectedTypeTraining(groupBoxTypesTraining);

                if(cbGroupMuscle.Text != "")
                {
                    try
                    {
                        selectedMuscleGroup = MuscleGroup.GetMuscleGroup(cbGroupMuscle.Text);
                    }
                    catch(Exception ex)
                    {
                        notification.MessageInvoke(false, ex.Message);
                        AddMessage(false, true, notification);
                    }
                    finally
                    {
                        ChangeIntervalOfReps(selectedMuscleGroup, nReps);
                        ChangeIntervalOfSets(selectedMuscleGroup, nSets);

                        nReps.Value = nReps.Minimum;
                    }
                }
            }));

        private TypeTrainingEnum GetSelectedTypeTraining(GroupBox groupBox)
        {
            foreach (var item in groupBox.Controls)
            {
                if(item is RadioButton radioButton && radioButton.Checked)
                {
                    return TypeTraining.GetTypeTrainingEnum(radioButton.Text);
                }
            }

            return TypeTrainingEnum.InvalidType;
        }

        private void ChangeIntervalOfReps(MuscleGroup muscleGroup, NumericUpDown nReps)
        {
            muscleGroup.Reps(typeTraining, out Int32 min, out Int32 max);
            SetInterval(nReps, min, max);
        }

        private void ChangeIntervalOfSets(MuscleGroup muscleGroup, NumericUpDown nSets)
        {
            muscleGroup.Sets(out Int32 min, out Int32 max);
            SetInterval(nSets, min, max);
        }

        private void SetInterval(NumericUpDown numeric, Int32 min, Int32 max)
        {
            numeric.Minimum = min;
            numeric.Maximum = max;
        }
    }
}
