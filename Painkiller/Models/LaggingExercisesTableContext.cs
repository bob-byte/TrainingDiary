using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painkiller.Models
{
    class LaggingExercisesTableContext
    {
        protected internal DataTable TabMinTrain { get; } = new DataTable();

        public LaggingExercisesTableContext()
        {
            DataColumn cGroup = new DataColumn("Група_мязів ");
            DataColumn cExercise = new DataColumn("Вправа ");
            DataColumn cBurden = new DataColumn("Обтяження ");
            DataColumn cPosition = new DataColumn("Положення тіла ");
            DataColumn cWeight = new DataColumn("Max_вага ");
            DataColumn cReps = new DataColumn("К_сть_повторень_з_max_вагою ");

            DataRow legs1 = TabMinTrain.NewRow();
            DataRow back1 = TabMinTrain.NewRow();
            DataRow chest1 = TabMinTrain.NewRow();
            DataRow arms1 = TabMinTrain.NewRow();
            DataRow shoulders1 = TabMinTrain.NewRow();

            cGroup.DataType = Type.GetType("System.String");
            cExercise.DataType = Type.GetType("System.String");
            cBurden.DataType = Type.GetType("System.String");
            cPosition.DataType = Type.GetType("System.String");
            cWeight.DataType = Type.GetType("System.Int32");
            cReps.DataType = Type.GetType("System.Int32");

            TabMinTrain.Columns.Add(cGroup);
            TabMinTrain.Columns.Add(cExercise);
            TabMinTrain.Columns.Add(cBurden);
            TabMinTrain.Columns.Add(cPosition);
            TabMinTrain.Columns.Add(cWeight);
            TabMinTrain.Columns.Add(cReps);

            legs1["Група_мязів "] = "Ноги";
            back1["Група_мязів "] = "Спина";
            chest1["Група_мязів "] = "Груди";
            arms1["Група_мязів "] = "Руки";
            shoulders1["Група_мязів "] = "Плечі";

            TabMinTrain.Rows.Add(legs1);
            TabMinTrain.Rows.Add(back1);
            TabMinTrain.Rows.Add(chest1);
            TabMinTrain.Rows.Add(arms1);
            TabMinTrain.Rows.Add(shoulders1);
        }
    }
}
