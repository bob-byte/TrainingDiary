using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painkiller
{
    public class Base
    {
        public delegate void Message(Object sender, MessageEventArgs e);
        event Message messagePositive;
        event Message messageNegative;
        public event Message MessagePositive
        {
            add
            {
                messagePositive += value;
                MessageEventArgs.CountPosInvoke++;
            }
            remove
            {
                messagePositive -= value;
                MessageEventArgs.CountPosInvoke--;
            }
        }
        public event Message MessageNegative
        {
            add
            {
                messageNegative += value;
                MessageEventArgs.CountNegInvoke++;
            }
            remove
            {
                messageNegative -= value;
                MessageEventArgs.CountNegInvoke--;
            }
        }

        protected void MessageInvoke(Boolean positive, String mess)
        {
            if (positive)
            {
                messagePositive?.Invoke(this, new MessageEventArgs(mess));
            }
            else
            {
                messageNegative?.Invoke(this, new MessageEventArgs(mess));
            }
        }

        public static DataTable TabMinTrain = new DataTable();
        public static DataTable TabTrain = new DataTable();//відводить місце для таблиці тренувань для кожного екземпляру типу Base
        public static DataView TrainView;


        public static String dialogCriteria, typeTrain;
        public static Int32 numTypeTrain, length;

        protected String[] names;
        Int32 firstGroup;//назва групи м'язів першого рядка в таблиці

        public static Boolean isClearMinRes;

        static Base()
        {
            DataColumn cNpp = new DataColumn("N_пп");
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
            isClearMinRes = false;
            TrainView = new DataView(TabTrain);
        }

        public void TTrainingAddRow(String group, String exercise,
            String typeTraining, String burden, String position, Int32 weight, Int32 reps, Int32 sets)
        {
            Int32 n = TabTrain.Rows.Count + 1;

            DataRow rowSklad = TabTrain.NewRow();
            rowSklad["N_пп"] = n;
            rowSklad["Група_мязів"] = group;
            rowSklad["Вправа"] = exercise;
            rowSklad["Вид_тренування"] = typeTraining;
            rowSklad["Обтяження"] = burden;
            rowSklad["Положення"] = position;
            rowSklad["Max_вага"] = weight;
            rowSklad["К_сть_повторень_з_max_вагою"] = reps;
            rowSklad["Загальна_к_сть_підходів"] = sets;
            if (n == 1)
            {

                if (group == "Ноги")
                {
                    firstGroup = 0;
                }
                if (group == "Спина")
                {
                    firstGroup = 1;
                }
                if (group == "Груди")
                {
                    firstGroup = 2;
                }
                if (group == "Руки")
                {
                    firstGroup = 3;
                }
                if (group == "Плечі")
                {
                    firstGroup = 4;
                }
            }
            TabTrain.Rows.Add(rowSklad);
            //ми могли б звертатись до відповідного поля рядка таблиці через його числовий індекс починаючи з 0. 
            //Наприклад, рядок rowSklad["N_пп"] можна переписати у вигляді rowSklad[0], а rowSklad["Ціна"] як rowSklad[4]
        }

        public void MainRes()
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

        public void ClearMax(DataGridView dGV)
        {
            isClearMinRes = true;

            TabMinTrain.Columns.Remove(TabMinTrain.Columns["Max_вага "]);
            TabMinTrain.Columns.Remove(TabMinTrain.Columns["К_сть_повторень_з_max_вагою "]);

            DataColumn cWeight = new DataColumn("Max_вага ");
            DataColumn cReps = new DataColumn("К_сть_повторень_з_max_вагою ");
            cWeight.DataType = Type.GetType("System.String");
            cReps.DataType = Type.GetType("System.String");
            TabMinTrain.Columns.Add(cWeight);
            TabMinTrain.Columns.Add(cReps);

            for (Int32 i = 0; i < dGV.Rows.Count - 1; i++)
            {
                TabMinTrain.Rows[i]["Вправа "] = "";
                TabMinTrain.Rows[i]["Обтяження "] = "";
                TabMinTrain.Rows[i]["Положення тіла "] = "";
                TabMinTrain.Rows[i]["Max_вага "] = "";
                TabMinTrain.Rows[i]["К_сть_повторень_з_max_вагою "] = "";
            }
        }

        public void DefineMinWeightColumn(Int32 numGroup, List<Int32> rows)
        {
            if (isClearMinRes == false)
            {
                Int32 rowMax = rows[0];
                try
                {
                    foreach (Int32 i in rows)
                    {
                        if ((Int32)TrainView[rowMax]["Max_вага"] > (Int32)TrainView[i]["Max_вага"])
                        {
                            rowMax = i;
                        }
                    }
                }
                catch (InvalidCastException ex)
                {
                    messageNegative?.Invoke(this, new MessageEventArgs(ex.Message));
                }
                ChangeColumnsValue(numGroup, rowMax);
            }
        }

        void ChangeColumnsValue(Int32 numRowTab, Int32 numRowView)
        {
            try
            {
                TabMinTrain.Rows[numRowTab]["Вправа "] = (String)TrainView[numRowView]["Вправа"];
                TabMinTrain.Rows[numRowTab]["Обтяження "] = (String)TrainView[numRowView]["Обтяження"];
                TabMinTrain.Rows[numRowTab]["Положення тіла "] = (String)TrainView[numRowView]["Положення"];
                TabMinTrain.Rows[numRowTab]["Max_вага "] = (Int32)TrainView[numRowView]["Max_вага"];
                TabMinTrain.Rows[numRowTab]["К_сть_повторень_з_max_вагою "] = (Int32)TrainView[numRowView]["К_сть_повторень_з_max_вагою"];
            }
            catch (InvalidCastException ex)
            {
                messageNegative?.Invoke(this, new MessageEventArgs(ex.Message));
            }
        }
        public void SetSumy(DataGridView dGV, DomainUpDown unitMeasure)
        {
            if (isClearMinRes == true)
            {
                TabMinTrain.Columns.Remove(TabMinTrain.Columns["Max_вага "]);
                TabMinTrain.Columns.Remove(TabMinTrain.Columns["К_сть_повторень_з_max_вагою "]);

                DataColumn cWeight = new DataColumn("Max_вага ");
                DataColumn cReps = new DataColumn("К_сть_повторень_з_max_вагою ");
                cWeight.DataType = Type.GetType("System.Int32");
                cReps.DataType = Type.GetType("System.Int32");

                TabMinTrain.Columns.Add(cWeight);
                TabMinTrain.Columns.Add(cReps);

                dGV.Columns["Max_вага "].HeaderText = $"Max вага, {unitMeasure.Text}";
                dGV.Columns["К_сть_повторень_з_max_вагою "].HeaderText = "К-сть повторень з max вагою";
                dGV.Columns["Max_вага "].Width = 65;
                dGV.Columns["К_сть_повторень_з_max_вагою "].Width = 65;

                dGV.Columns["Max_вага "].DefaultCellStyle.BackColor = Color.Black;
                dGV.Columns["Max_вага "].DefaultCellStyle.ForeColor = Color.Red;
                dGV.Columns["К_сть_повторень_з_max_вагою "].DefaultCellStyle.BackColor = Color.Red;
                dGV.Columns["К_сть_повторень_з_max_вагою "].DefaultCellStyle.ForeColor = Color.Black;

                isClearMinRes = false;//щоб не заходило зайвий раз в це розгалуження
            }
            if (TrainView.Count == 1)//якщо один рядок, то не потрібно робити логічний операцій порівнянь, а просто варто додавати його в таблицю TabMinTrain
            {
                ChangeColumnsValue(firstGroup, 0);
            }
            else
            {
                List<Int32> numRowLegs = new List<Int32>();
                List<Int32> numRowBack = new List<Int32>();
                List<Int32> numRowChest = new List<Int32>();
                List<Int32> numRowArms = new List<Int32>();
                List<Int32> numRowShoulders = new List<Int32>();

                for (Int32 i = 0; i < TrainView.Count; i++)
                {
                    try
                    {
                        if ((String)TrainView[i]["Група_мязів"] == "Ноги")
                        {
                            numRowLegs.Add(i);
                        }
                        else if ((String)TrainView[i]["Група_мязів"] == "Спина")
                        {
                            numRowBack.Add(i);
                        }
                        else if ((String)TrainView[i]["Група_мязів"] == "Груди")
                        {
                            numRowChest.Add(i);
                        }
                        else if ((String)TrainView[i]["Група_мязів"] == "Руки")
                        {
                            numRowArms.Add(i);
                        }
                        else if ((String)TrainView[i]["Група_мязів"] == "Плечі")
                        {
                            numRowShoulders.Add(i);
                        }
                    }
                    catch (Exception ex)
                    {
                        messageNegative?.Invoke(this, new MessageEventArgs(ex.Message));
                    }
                }

                if (numRowLegs.Count >= 1)
                {
                    DefineMinWeightColumn(0, numRowLegs);
                }
                if (numRowBack.Count >= 1)
                {
                    DefineMinWeightColumn(1, numRowBack);
                }
                if (numRowChest.Count >= 1)
                {
                    DefineMinWeightColumn(2, numRowChest);
                }
                if (numRowArms.Count >= 1)
                {
                    DefineMinWeightColumn(3, numRowArms);
                }
                if (numRowShoulders.Count >= 1)
                {
                    DefineMinWeightColumn(4, numRowShoulders);
                }
            }
        }
    }
}
