using Painkiller.Models;
using Painkiller.Models.Training;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painkiller.PresentationModels
{
    public class WeightControlsForm
    {

    }


    partial class MainPresentationModel
    {
        private DataGridView dataGridAllTraining;

        internal Int32 firstGroup;//назва групи м'язів першого рядка в таблиці

        internal Byte NumTypeTrain { get; set; }
        internal String DialogCriteria { get; set; }
        internal Int32 Length { get; set; }
        protected String[] NameExercises { get; set; }
        internal Boolean isClearMinRes { get; set; }
        private AllTrainingTableContext allTrainingTableContext = new AllTrainingTableContext();
        private LaggingExercisesTableContext laggingExercisesTableContext = new LaggingExercisesTableContext();
        public static Dictionary<MuscleGroup, String> GroupMuscles { get; } = new Dictionary<MuscleGroup, String>();
        private GroupBox groupBoxTypesTraining;
        private GroupBox groupBoxTypesEncumbrances;
        private TypeTrainingEnum typeTraining;
        private TypeEncumbranceEnum typeEncumbrance;
        private UnitMeasureEnum unitMeasure;
        private ComboBox cbGroupMuscle;
        private NumericUpDown nReps, nSets, nWeight;
        private MuscleGroup selectedMuscleGroup;
        private ComboBox cbExercise;
        private DomainUpDown dudUnitMeasure;
        private Label lMaxWeight;

        private void AddMessage(Boolean pos, Boolean neg, Notification sender)
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

        private void PositiveMessage(Object sender, MessageEventArgs e)
        {
            MessageBox.Show(e.Message, "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void NegativeMessage(Object sender, MessageEventArgs e)
        {
            MessageBox.Show(e.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public MainPresentationModel(DataGridView dataGridAllTraining, GroupBox groupBoxTypesTraining, GroupBox groupBoxTypesEncumbrances, ComboBox cbGroupMuscle, ComboBox cbExercise, NumericUpDown nReps, NumericUpDown nSets, NumericUpDown nWeight, DomainUpDown dudUnitMeasure, Label lMaxWeight)
        {
            this.dataGridAllTraining = dataGridAllTraining;
            this.groupBoxTypesTraining = groupBoxTypesTraining;
            this.groupBoxTypesEncumbrances = groupBoxTypesEncumbrances;
            this.cbGroupMuscle = cbGroupMuscle;
            this.nReps = nReps;
            this.nSets = nSets;
            this.cbExercise = cbExercise;
            this.dudUnitMeasure = dudUnitMeasure;
            this.nWeight = nWeight;
            nWeight.Maximum = 1500;
            this.lMaxWeight = lMaxWeight;
        }

        public virtual void SortCouter(DataGridView dataGrid)
        {
            //to dGv.Rows.Count - 2, because the last line is added itself 
            //the reason that DataGridView.AllowUserToAddRows = true and we always have additional line to fill it
            for (Int32 i = 0; i < dataGrid.Rows.Count - 1; i++)
            {
                dataGrid.Rows[i].Cells[AllTrainingTableContext.COUNTER_COLUMN].Value = i + 1;
            }
        }
    }
}
