using Painkiller.Models.Training;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Painkiller
{
    public class AllTrainingTableContext
    {
        public const String COUNTER_COLUMN = "N";
        public const String GROUP_MUSCLE_COLUMN = "Група_мязів";
        public const String TYPE_TRAINING_COLUMN = "Вид_тренування";
        public const String EXERCISE_COLUMN = "Вправа";
        public const String BURDEN_COLUMN = "Обтяження";
        public const String POSITION_COLUMN = "Положення";
        public const String WEIGHT_COLUMN = "Max_вага";
        public const String REPS_COLUMN = "К_сть_повторень_з_max_вагою";
        public const String SETS_COLUMN = "Загальна_к_сть_підходів";
        protected internal DataTable TabTrain { get; set; } = new DataTable();
        protected internal DataTable TabMinTrain { get; set; } = new DataTable();

        internal DataView TrainView { get; private set; }



        public AllTrainingTableContext()
        {
            DataColumn cNpp = new DataColumn(COUNTER_COLUMN);
            DataColumn cNameGroup = new DataColumn("Група_мязів");
            DataColumn cTypeTrain = new DataColumn("Вид_тренування");
            DataColumn cNameExercice = new DataColumn("Вправа");
            DataColumn cBurden = new DataColumn("Обтяження");
            DataColumn cPosition = new DataColumn("Положення");
            DataColumn cWeight = new DataColumn("Max_вага");
            DataColumn cReps = new DataColumn("К_сть_повторень_з_max_вагою");
            DataColumn cSets = new DataColumn("Загальна_к_сть_підходів");

            cNpp.DataType = Type.GetType("System.Int32");
            cNameGroup.DataType = Type.GetType("System.String");
            cTypeTrain.DataType = Type.GetType("System.String");
            cNameExercice.DataType = Type.GetType("System.String");
            cBurden.DataType = Type.GetType("System.String");
            cPosition.DataType = Type.GetType("System.String");
            cWeight.DataType = Type.GetType("System.Int32");
            cReps.DataType = Type.GetType("System.Int32");
            cSets.DataType = Type.GetType("System.Int32");

            TabTrain.Columns.Add(cNpp);
            TabTrain.Columns.Add(cNameGroup);
            TabTrain.Columns.Add(cTypeTrain);
            TabTrain.Columns.Add(cNameExercice);
            TabTrain.Columns.Add(cBurden);
            TabTrain.Columns.Add(cPosition);
            TabTrain.Columns.Add(cWeight);
            TabTrain.Columns.Add(cReps);
            TabTrain.Columns.Add(cSets);

            TrainView = new DataView(TabTrain);
        }
    }
}
