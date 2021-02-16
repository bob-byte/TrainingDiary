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
            //isClearMinRes = false;
            TrainView = new DataView(TabTrain);
        }

        //internal void GetValueMeasure(DataTable dataTable, UnitMeasureEnum unitMeasure)
        //{
        //    UnitMeasure measureConvert = new UnitMeasure(unitMeasure, notif)

            //if (unitMeasure == UnitMeasureEnum.Kg)
            //{

            //    for (Int32 i = 0; i < allTrainingTableContext.TabTrain.Rows.Count; i++)
            //    {
            //        allTrainingTableContext.TabTrain.Rows[i]["Max_вага"] = Math.Round((Int32)allTrainingTableContext.TabTrain.Rows[i]["Max_вага"] * 0.454);
            //    }
            //    for (Int32 i = 0; i < TabMinTrain.Rows.Count; i++)
            //    {
            //        if (TabMinTrain.Rows[i]["Max_вага "].ToString() != "")
            //        {
            //            TabMinTrain.Rows[i]["Max_вага "] = Math.Round((Int32)TabMinTrain.Rows[i]["Max_вага "] * 0.454);
            //        }
            //    }
            //}
            //else
            //{
            //    for (Int32 i = 0; i < TabTrain.Rows.Count; i++)
            //    {
            //        TabTrain.Rows[i]["Max_вага"] = Math.Round((Int32)TabTrain.Rows[i]["Max_вага"] * 2.2046);
            //    }
            //    for (Int32 i = 0; i < TabMinTrain.Rows.Count; i++)
            //    {
            //        if (TabMinTrain.Rows[i]["Max_вага "].ToString() != "")
            //        {
            //            TabMinTrain.Rows[i]["Max_вага "] = Math.Round((Int32)TabMinTrain.Rows[i]["Max_вага "] * 2.2046);
            //        }
            //    }
            //}
        //}

        //public void TTrainingAddRow(String group, String exercise,
        //    String typeTraining, String burden, String position, Int32 weight, Int32 reps, Int32 sets)
        //{
        //    Int32 n = TabTrain.Rows.Count + 1;

        //    DataRow rowSklad = TabTrain.NewRow();
        //    rowSklad["N_пп"] = n;
        //    rowSklad["Група_мязів"] = group;
        //    rowSklad["Вправа"] = exercise;
        //    rowSklad["Вид_тренування"] = typeTraining;
        //    rowSklad["Обтяження"] = burden;
        //    rowSklad["Положення"] = position;
        //    rowSklad["Max_вага"] = weight;
        //    rowSklad["К_сть_повторень_з_max_вагою"] = reps;
        //    rowSklad["Загальна_к_сть_підходів"] = sets;
        //    if (n == 1)
        //    {

        //        if (group == "Ноги")
        //        {
        //            firstGroup = 0;
        //        }
        //        if (group == "Спина")
        //        {
        //            firstGroup = 1;
        //        }
        //        if (group == "Груди")
        //        {
        //            firstGroup = 2;
        //        }
        //        if (group == "Руки")
        //        {
        //            firstGroup = 3;
        //        }
        //        if (group == "Плечі")
        //        {
        //            firstGroup = 4;
        //        }
        //    }
        //    TabTrain.Rows.Add(rowSklad);
        //    //ми могли б звертатись до відповідного поля рядка таблиці через його числовий індекс починаючи з 0. 
        //    //Наприклад, рядок rowSklad["N_пп"] можна переписати у вигляді rowSklad[0], а rowSklad["Ціна"] як rowSklad[4]
        //}

        //public void MainRes()
        //{

        //}

        //public void ClearMax(DataGridView dGV)
        //{
        //    isClearMinRes = true;

        //    TabMinTrain.Columns.Remove(TabMinTrain.Columns["Max_вага "]);
        //    TabMinTrain.Columns.Remove(TabMinTrain.Columns["К_сть_повторень_з_max_вагою "]);

        //    DataColumn cWeight = new DataColumn("Max_вага ");
        //    DataColumn cReps = new DataColumn("К_сть_повторень_з_max_вагою ");
        //    cWeight.DataType = Type.GetType("System.String");
        //    cReps.DataType = Type.GetType("System.String");
        //    TabMinTrain.Columns.Add(cWeight);
        //    TabMinTrain.Columns.Add(cReps);

        //    for (Int32 i = 0; i < dGV.Rows.Count - 1; i++)
        //    {
        //        TabMinTrain.Rows[i]["Вправа "] = "";
        //        TabMinTrain.Rows[i]["Обтяження "] = "";
        //        TabMinTrain.Rows[i]["Положення тіла "] = "";
        //        TabMinTrain.Rows[i]["Max_вага "] = "";
        //        TabMinTrain.Rows[i]["К_сть_повторень_з_max_вагою "] = "";
        //    }
        //}

        //public void DefineMinWeightColumn(MuscleGroup numGroup, List<Int32> rows)
        //{
        //    if (isClearMinRes == false)
        //    {
        //        Int32 rowMax = rows[0];
        //        try
        //        {
        //            foreach (Int32 i in rows)
        //            {
        //                if ((Int32)TrainView[rowMax]["Max_вага"] > (Int32)TrainView[i]["Max_вага"])
        //                {
        //                    rowMax = i;
        //                }
        //            }
        //        }
        //        catch (InvalidCastException ex)
        //        {
        //            messageNegative?.Invoke(this, new MessageEventArgs(ex.Message));
        //        }
        //        ChangeColumnsValue(numGroup, rowMax);
        //    }
        //}

        //void ChangeColumnsValue(MuscleGroup numRowTab, Int32 numRowView)
        //{
        //    try
        //    {
        //        TabMinTrain.Rows[(Int32)numRowTab]["Вправа "] = (String)TrainView[numRowView]["Вправа"];
        //        TabMinTrain.Rows[(Int32)numRowTab]["Обтяження "] = (String)TrainView[numRowView]["Обтяження"];
        //        TabMinTrain.Rows[(Int32)numRowTab]["Положення тіла "] = (String)TrainView[numRowView]["Положення"];
        //        TabMinTrain.Rows[(Int32)numRowTab]["Max_вага "] = (Int32)TrainView[numRowView]["Max_вага"];
        //        TabMinTrain.Rows[(Int32)numRowTab]["К_сть_повторень_з_max_вагою "] = (Int32)TrainView[numRowView]["К_сть_повторень_з_max_вагою"];
        //    }
        //    catch (InvalidCastException ex)
        //    {
        //        messageNegative?.Invoke(this, new MessageEventArgs(ex.Message));
        //    }
        //}

        //public void SetSumy(DataGridView dGV, DomainUpDown unitMeasure)
        //{
        //    if (isClearMinRes == true)
        //    {
        //        TabMinTrain.Columns.Remove(TabMinTrain.Columns["Max_вага "]);
        //        TabMinTrain.Columns.Remove(TabMinTrain.Columns["К_сть_повторень_з_max_вагою "]);

        //        DataColumn cWeight = new DataColumn("Max_вага ");
        //        DataColumn cReps = new DataColumn("К_сть_повторень_з_max_вагою ");
        //        cWeight.DataType = Type.GetType("System.Int32");
        //        cReps.DataType = Type.GetType("System.Int32");

        //        TabMinTrain.Columns.Add(cWeight);
        //        TabMinTrain.Columns.Add(cReps);

        //        dGV.Columns["Max_вага "].HeaderText = $"Max вага, {unitMeasure.Text}";
        //        dGV.Columns["К_сть_повторень_з_max_вагою "].HeaderText = "К-сть повторень з max вагою";
        //        dGV.Columns["Max_вага "].Width = 65;
        //        dGV.Columns["К_сть_повторень_з_max_вагою "].Width = 65;

        //        dGV.Columns["Max_вага "].DefaultCellStyle.BackColor = Color.NavajoWhite;
        //        dGV.Columns["К_сть_повторень_з_max_вагою "].DefaultCellStyle.BackColor = Color.PaleGoldenrod;

        //        isClearMinRes = false;//щоб не заходило зайвий раз в це розгалуження
        //    }
        //    if (TrainView.Count == 1)//якщо один рядок, то не потрібно робити логічний операцій порівнянь, а просто варто додавати його в таблицю TabMinTrain
        //    {
        //        ChangeColumnsValue(firstGroup, 0);
        //    }
        //    else
        //    {
        //        List<Int32> numRowLegs = new List<Int32>();
        //        List<Int32> numRowBack = new List<Int32>();
        //        List<Int32> numRowChest = new List<Int32>();
        //        List<Int32> numRowArms = new List<Int32>();
        //        List<Int32> numRowShoulders = new List<Int32>();
        //        Hashtable exercises = new Hashtable();


        //        for (var i = 0; i < TrainView.Count; i++)
        //        {
        //            exercises.Add(TrainView[i][GROUP_MUSCLE_COLUMN].ToString().GetMuscleGroupEnum(), (Int32)TrainView[i][WEIGHT_COLUMN]);
        //        }

        //        for (Int32 i = 0; i < TrainView.Count; i++)
        //        {
        //            try
        //            {
        //                String groupMuscle = (String)TrainView[i]["Група_мязів"];
        //                exercises.Add()
        //                if ((String)TrainView[i]["Група_мязів"] == "Ноги")
        //                {
        //                    numRowLegs.Add(i);
        //                }
        //                else if ((String)TrainView[i]["Група_мязів"] == "Спина")
        //                {
        //                    numRowBack.Add(i);
        //                }
        //                else if ((String)TrainView[i]["Група_мязів"] == "Груди")
        //                {
        //                    numRowChest.Add(i);
        //                }
        //                else if ((String)TrainView[i]["Група_мязів"] == "Руки")
        //                {
        //                    numRowArms.Add(i);
        //                }
        //                else if ((String)TrainView[i]["Група_мязів"] == "Плечі")
        //                {
        //                    numRowShoulders.Add(i);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                messageNegative?.Invoke(this, new MessageEventArgs(ex.Message));
        //            }
        //        }

        //        if (numRowLegs.Count >= 1)
        //        {
        //            DefineMinWeightColumn(0, numRowLegs);
        //        }
        //        if (numRowBack.Count >= 1)
        //        {
        //            DefineMinWeightColumn(1, numRowBack);
        //        }
        //        if (numRowChest.Count >= 1)
        //        {
        //            DefineMinWeightColumn(2, numRowChest);
        //        }
        //        if (numRowArms.Count >= 1)
        //        {
        //            DefineMinWeightColumn(3, numRowArms);
        //        }
        //        if (numRowShoulders.Count >= 1)
        //        {
        //            DefineMinWeightColumn(4, numRowShoulders);
        //        }
        //    }
        //}

        //internal void GetValueMeasure(Boolean isKg)
        //{
        //    if(isKg)
        //    {
        //        for (Int32 i = 0; i < TabTrain.Rows.Count; i++)
        //        {
        //            TabTrain.Rows[i]["Max_вага"] = Math.Round((Int32)TabTrain.Rows[i]["Max_вага"] * 0.454);
        //        }
        //        for (Int32 i = 0; i < TabMinTrain.Rows.Count; i++)
        //        {
        //            if (TabMinTrain.Rows[i]["Max_вага "].ToString() != "")
        //            {
        //                TabMinTrain.Rows[i]["Max_вага "] = Math.Round((Int32)TabMinTrain.Rows[i]["Max_вага "] * 0.454);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        for (Int32 i = 0; i < TabTrain.Rows.Count; i++)
        //        {
        //            TabTrain.Rows[i]["Max_вага"] = Math.Round((Int32)TabTrain.Rows[i]["Max_вага"] * 2.2046);
        //        }
        //        for (Int32 i = 0; i < TabMinTrain.Rows.Count; i++)
        //        {
        //            if (TabMinTrain.Rows[i]["Max_вага "].ToString() != "")
        //            {
        //                TabMinTrain.Rows[i]["Max_вага "] = Math.Round((Int32)TabMinTrain.Rows[i]["Max_вага "] * 2.2046);
        //            }
        //        }
        //    }
        //}
    }
}
