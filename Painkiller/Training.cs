using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Drawing;

namespace Painkiller
{
    
    public class Base
    {
        public delegate void Message(object sender, MessageEventArgs e);
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


        public DataTable TabMinTrain = new DataTable();
        public DataTable DovGroup = new DataTable();
        public DataTable TabTrain = new DataTable();//відводить місце для таблиці тренувань для кожного екземпляру типу Base
        public DataView TrainView;
        string sdir, sNameFileAllTrain, sNameFileBadExercise, textRow;
        public string SortCriteria;
        public static int numTypeTrain, length;
        public static string typeTrain;
        private Int32 j;
        public Boolean clear;
        public Base()
        {
            clear = false;
            sdir = Directory.GetCurrentDirectory();
            sNameFileAllTrain = $"{sdir}\\Все тренування.txt";
            sNameFileBadExercise = $"{sdir}\\Відстаючі вправи.txt";
            TrainView = new DataView(TabTrain);
            //значення в лапках - значення властивості ColumnName
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
        }
        Int32 firstGroup = 0;//назва групи м'язів першого рядка
        public void TTrainingAddRow(String group, String exercise,
            String typeTraining, String burden, String position, Int32 weight, Int32 reps, Int32 sets)
        {
            j = TabTrain.Rows.Count + 1;
            DataRow rowSklad = TabTrain.NewRow();
            //присвоюємо значення полів значення, отримані через параметри
            rowSklad["N_пп"] = j++;
            rowSklad["Група_мязів"] = group;
            rowSklad["Вправа"] = exercise;
            rowSklad["Вид_тренування"] = typeTraining;
            rowSklad["Обтяження"] = burden;
            rowSklad["Положення"] = position;
            rowSklad["Max_вага"] = weight;
            rowSklad["К_сть_повторень_з_max_вагою"] = reps;
            rowSklad["Загальна_к_сть_підходів"] = sets;
            if(j == 2)
            {
                
                if(group == "Ноги")
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
            //j++;
            //ми могли б звертатись до відповідного поля рядка таблиці через його числовий індекс починаючи з 0. 
            //Наприклад, рядок rowSklad["N_пп"] можна переписати у вигляді rowSklad[0], а rowSklad["Ціна"] як rowSklad[4]
        }
        public void WriteTabFile(Boolean allTrain)
        {
            try
            {
                Int32 i = 0;
                String textRow;

                if (allTrain)
                {
                    StreamReader sr = new StreamReader(sNameFileAllTrain);
                    while (sr.Peek() >= 0)
                    {
                        textRow = sr.ReadLine();
                        if (textRow.Contains("День"))
                        {
                            String[] data = new String[2];
                            data = textRow.Split(' ');
                            if (!Int32.TryParse(data[1], out i))
                            {
                                messageNegative?.Invoke(this, new MessageEventArgs("Файл \"Все тренування\" неправильно записаний"));
                            }
                        }
                    }
                    sr.Close();
                }

                StreamWriter sw1 = new StreamWriter(sNameFileAllTrain, true);
                if (allTrain)
                {
                    sw1.WriteLine($"День {++i}");
                }
                foreach (DataRow r in TabTrain.Rows)
                {
                    this.textRow = $"{r["Група_мязів"]};{r["Вправа"]};{r["Вид_тренування"]};{r["Обтяження"]};{r["Положення"]};{r["Max_вага"]};{r["К_сть_повторень_з_max_вагою"]};{r["Загальна_к_сть_підходів"]}";
                    sw1.WriteLine(this.textRow);
                }
                sw1.Close();
                messagePositive?.Invoke(this, new MessageEventArgs("Інформація у файл \"Все тренування\" записана"));
            }
            catch (Exception ex)
            {
                messageNegative?.Invoke(this, new MessageEventArgs($"Все тренування не вдалося записати: {ex.Message}"));
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(sNameFileBadExercise))
                {
                    foreach(DataRow r in TabMinTrain.Rows)
                    {
                        if (r["Вправа "].ToString() == "")
                        {
                            continue;
                        }
                        textRow = $"{r["Група_мязів "]};{r["Вправа "]};{r["Обтяження "]};{r["Положення тіла "]};{r["Max_вага "]};{r["К_сть_повторень_з_max_вагою "]}";
                        sw.WriteLine(textRow);
                    }
                }

                messagePositive?.Invoke(this, new MessageEventArgs("Інформація у файл \"Відстаючі вправи\" записана"));
            }
            catch (Exception ex)
            {
                messageNegative?.Invoke(this, new MessageEventArgs($"Відстаючі вправи не вдалося записати: {ex.Message}"));
            }
        }
        public void ReadTabFile(DataGridView allTrain)
        {
            try
            {
                using (StreamReader sr = new StreamReader(sNameFileAllTrain))
                {
                    while (sr.Peek() >= 0)//поки у файлі є елементи
                    {
                        textRow = sr.ReadLine();
                        String[] partTrain = textRow.Split(';');

                        if (partTrain[0].Contains("День"))
                        {
                            continue;
                        }
                        TTrainingAddRow(partTrain[0], partTrain[1], partTrain[2], partTrain[3], partTrain[4], Convert.ToInt32(partTrain[5]), Convert.ToInt32(partTrain[6]), Convert.ToInt32(partTrain[7]));
                    }
                }               
            }
            catch(Exception ex)
            {
                messageNegative?.Invoke(this, new MessageEventArgs(ex.Message));
            }
            for (int i = 0; i < allTrain.Rows.Count - 1; i++)
            {
                allTrain.Rows[i].Cells["N_пп"].Value = i + 1;
            }
        }
        public void TTrainingFiltr(string filter, DataGridView dGV)
        {
            TrainView.RowFilter = filter;
            dGV.DataSource = TrainView;
            for(int i = 0; i < dGV.Rows.Count - 1; i++)
            {
                dGV.Rows[i].Cells["N_пп"].Value = i + 1;
            }
        }
        public void TTrainingSort(string sort, DataGridView dGV)
        {
            TrainView.Sort = sort;
            SortCriteria = sort;
            dGV.DataSource = TrainView;
            for (int i = 0; i < dGV.Rows.Count - 1; i++)//dGv.Rows.Count - 1, оскільки останній рядок самостійно додається
            {
                dGV.Rows[i].Cells["N_пп"].Value = i + 1;
            }
        }
        public void SeekExercise(string name, DataGridView dGV)
        {
            int n = 0;
            bool isFound = false;
            try
            {
                for (int i = 0; i < dGV.Rows.Count; i++)
                {
                    if ((string)dGV.Rows[i].Cells["Вправа"].Value == name)
                    {
                        n = i;
                        isFound = true;
                        break;
                    }
                }
                if (isFound)
                {
                    dGV.FirstDisplayedCell = dGV.Rows[n].Cells["Вправа"];
                    dGV.Rows[n].Selected = true;
                    dGV.CurrentCell = dGV.Rows[n].Cells["Вправа"];
                }
                else
                {
                    messageNegative?.Invoke(this, new MessageEventArgs("Елемент з такою назвою не існує"));
                }
            }
            catch
            {
                messageNegative?.Invoke(this, new MessageEventArgs("Елемент з такою назвою не існує"));
            }
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
            clear = true;
            TabMinTrain.Columns.Remove(TabMinTrain.Columns["Max_вага "]);
            TabMinTrain.Columns.Remove(TabMinTrain.Columns["К_сть_повторень_з_max_вагою "]);
            DataColumn cWeight = new DataColumn("Max_вага ");
            DataColumn cReps = new DataColumn("К_сть_повторень_з_max_вагою ");
            cWeight.DataType = Type.GetType("System.String");
            cReps.DataType = Type.GetType("System.String");
            TabMinTrain.Columns.Add(cWeight);
            TabMinTrain.Columns.Add(cReps);
            for (int i = 0; i < dGV.Rows.Count - 1; i++)
            {
                TabMinTrain.Rows[i]["Вправа "] = "";
                TabMinTrain.Rows[i]["Обтяження "] = "";
                TabMinTrain.Rows[i]["Положення тіла "] = "";
                TabMinTrain.Rows[i]["Max_вага "] = "";
                TabMinTrain.Rows[i]["К_сть_повторень_з_max_вагою "] = "";
            }
            dGV.DataSource = TabMinTrain;
        }

        public void DefineMinWeightColumn(DataGridView dGv, Int32 numGroup, List<Int32> rows)
        {
            if (clear == false)
            {
                Int32 rowMax = rows[0];
                foreach (Int32 i in rows)
                {
                    if ((Int32)TrainView[rowMax]["Max_вага"] > (Int32)TrainView[i]["Max_вага"])
                    {
                        rowMax = i;
                    }
                }
                ChangeColumnsValue(numGroup, rowMax);

                dGv.DataSource = TabMinTrain;
            }
        }

        void ChangeColumnsValue(int numRowTab, int numRowView)
        {
            TabMinTrain.Rows[numRowTab]["Вправа "] = (string)TrainView[numRowView]["Вправа"];
            TabMinTrain.Rows[numRowTab]["Обтяження "] = (string)TrainView[numRowView]["Обтяження"];
            TabMinTrain.Rows[numRowTab]["Положення тіла "] = (string)TrainView[numRowView]["Положення"];
            TabMinTrain.Rows[numRowTab]["Max_вага "] = (int)TrainView[numRowView]["Max_вага"];
            TabMinTrain.Rows[numRowTab]["К_сть_повторень_з_max_вагою "] = (int)TrainView[numRowView]["К_сть_повторень_з_max_вагою"];
        }
        public void SetSumy(DataGridView dGV, DomainUpDown unitMeasure)
        {
            if (clear == true)
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

                clear = false;//щоб не заходило зайвий раз в це розгалуження
            }
            if (TrainView.Count == 1)//якщо один рядок, то не потрібно робити логічний операцій порівнянь, а просто варто додавати його в таблицю TabMaxTrain
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
                Int32 n = 0, s = 0, g = 0, r = 0, p = 0;

                for (Int32 i = 0; i < TrainView.Count; i++)
                {
                    if ((string)TrainView[i]["Група_мязів"] == "Ноги")
                    {
                        n++;
                        numRowLegs.Add(i);
                    }
                    else if ((string)TrainView[i]["Група_мязів"] == "Спина")
                    {
                        s++;
                        numRowBack.Add(i);
                    }
                    else if ((string)TrainView[i]["Група_мязів"] == "Груди")
                    {
                        g++;
                        numRowChest.Add(i);
                    }
                    else if ((string)TrainView[i]["Група_мязів"] == "Руки")
                    {
                        r++;
                        numRowArms.Add(i);
                    }
                    else if ((string)TrainView[i]["Група_мязів"] == "Плечі")
                    {
                        p++;
                        numRowShoulders.Add(i);
                    }
                }

                if (n >= 1)
                {
                    DefineMinWeightColumn(dGV, 0, numRowLegs);
                }
                if (s >= 1)
                {
                    DefineMinWeightColumn(dGV, 1, numRowBack);
                }
                if (g >= 1)
                {
                    DefineMinWeightColumn(dGV, 2, numRowChest);
                }
                if (r >= 1)
                {
                    DefineMinWeightColumn(dGV, 3, numRowArms);
                }
                if (p >= 1)
                {
                    DefineMinWeightColumn(dGV, 4, numRowShoulders);
                }
            }

            dGV.DataSource = TabMinTrain;
            TrainView.Sort = SortCriteria;
        }
    }

        public class Legs : Base, IPainKiller
        {
            public void Exercises()
            {
                length = 7;
                DataColumn cNameGroup = new DataColumn("Вправа")
                {
                    DataType = Type.GetType("System.String")
                };
                DovGroup.Columns.Add(cNameGroup);
                DataRow rowSklad0 = DovGroup.NewRow();
                rowSklad0[cNameGroup] = "Присідання";
                DovGroup.Rows.Add(rowSklad0);
                DataRow rowSklad1 = DovGroup.NewRow();
                rowSklad1[cNameGroup] = "Фронтальні присідання";
                DovGroup.Rows.Add(rowSklad1);
                DataRow rowSklad2 = DovGroup.NewRow();
                rowSklad2[cNameGroup] = "Мертва тяга";
                DovGroup.Rows.Add(rowSklad2);
                DataRow rowSklad3 = DovGroup.NewRow();
                rowSklad3[cNameGroup] = "Жим ногами";
                DovGroup.Rows.Add(rowSklad3);
                DataRow rowSklad4 = DovGroup.NewRow();
                rowSklad4[cNameGroup] = "Випади на місці";
                DovGroup.Rows.Add(rowSklad4);
                DataRow rowSklad5 = DovGroup.NewRow();
                rowSklad5[cNameGroup] = "Випади ходьбою";
                DovGroup.Rows.Add(rowSklad5);
                DataRow rowSklad6 = DovGroup.NewRow();
                rowSklad6[cNameGroup] = "Розгинання ніг";
                DovGroup.Rows.Add(rowSklad6);
                DataRow rowSklad7 = DovGroup.NewRow();
                rowSklad7[cNameGroup] = "Згинання ніг";
                DovGroup.Rows.Add(rowSklad7);
            }
            public void Reps(out int min, out int max)
            {
                if (numTypeTrain == 1)
                {
                    min = 18;
                    max = 30;
                }
                else if (numTypeTrain == 2)
                {
                    min = 8;
                    max = 15;
                }
                else
                {
                    min = 1;
                    max = 6;
                }
            }
            public void Sets(out int min, out int max)
            {
                 min = 1;
                 max = 10;               
            }
        }
        public class Back : Base, IPainKiller
        {
            public void Exercises()
            {
                length = 6;
                DataColumn cNameGroup = new DataColumn("Вправа");
                cNameGroup.DataType = Type.GetType("System.String");
                DovGroup.Columns.Add(cNameGroup);
                DataRow rowSklad0 = DovGroup.NewRow();
                rowSklad0[cNameGroup] = "Станова тяга";
                DovGroup.Rows.Add(rowSklad0);
                DataRow rowSklad1 = DovGroup.NewRow();
                rowSklad1[cNameGroup] = "Тяга зверху перед собою";
                DovGroup.Rows.Add(rowSklad1);
                DataRow rowSklad2 = DovGroup.NewRow();
                rowSklad2[cNameGroup] = "Тяга за голову";
                DovGroup.Rows.Add(rowSklad2);
                DataRow rowSklad3 = DovGroup.NewRow();
                rowSklad3[cNameGroup] = "Тяга до поясу";
                DovGroup.Rows.Add(rowSklad3);
                DataRow rowSklad4 = DovGroup.NewRow();
                rowSklad4[cNameGroup] = "Пуловер";
                DovGroup.Rows.Add(rowSklad4);
                DataRow rowSklad5 = DovGroup.NewRow();
                rowSklad5[cNameGroup] = "Good morning";
                DovGroup.Rows.Add(rowSklad5);
                DataRow rowSklad6 = DovGroup.NewRow();
                rowSklad6[cNameGroup] = "Гіперекстензія";
                DovGroup.Rows.Add(rowSklad6);
            }
            public void Reps(out int min, out int max)
            {
                if (numTypeTrain == 1)
                {
                    min = 22;
                    max = 33;
                }
                else if (numTypeTrain == 2)
                {
                    min = 8;
                    max = 15;
                }
                else
                {
                    min = 1;
                    max = 6;
                }
            }
            public void Sets(out int min, out int max)
            {
                min = 1;
                max = 10;
            }
        }
        public class Chest : Base, IPainKiller
        {
            public void Exercises()
            {
                length = 5;
                DataColumn cNameGroup = new DataColumn("Вправа");
                cNameGroup.DataType = Type.GetType("System.String");
                DovGroup.Columns.Add(cNameGroup);
                DataRow rowSklad0 = DovGroup.NewRow();
                rowSklad0[cNameGroup] = "Жим (широким хватом)";
                DovGroup.Rows.Add(rowSklad0);
                DataRow rowSklad1 = DovGroup.NewRow();
                rowSklad1[cNameGroup] = "Віджимання";
                DovGroup.Rows.Add(rowSklad1);
                DataRow rowSklad2 = DovGroup.NewRow();
                rowSklad2[cNameGroup] = "Паралельний жим";
                DovGroup.Rows.Add(rowSklad2);
                DataRow rowSklad3 = DovGroup.NewRow();
                rowSklad3[cNameGroup] = "Пуловер";
                DovGroup.Rows.Add(rowSklad3);
                DataRow rowSklad4 = DovGroup.NewRow();
                rowSklad4[cNameGroup] = "Зведення рук";
                DovGroup.Rows.Add(rowSklad4);
            }
            public void Reps(out int min, out int max)
            {
                if (numTypeTrain == 1)
                {
                    min = 24;
                    max = 35;
                }
                else if (numTypeTrain == 2)
                {
                    min = 7;
                    max = 15;
                }
                else
                {
                    min = 3;
                    max = 6;
                }
            }
            public void Sets(out int min, out int max)
            {
                min = 1;
                max = 8;
            }
        }
    public class Arms : Base, IPainKiller
    {
        public void Exercises()
        {
            length = 5;
            DataColumn cNameGroup = new DataColumn("Вправа");
            cNameGroup.DataType = Type.GetType("System.String");
            DovGroup.Columns.Add(cNameGroup);
            DataRow rowSklad0 = DovGroup.NewRow();
            rowSklad0[cNameGroup] = "Молотки";
            DovGroup.Rows.Add(rowSklad0);
            DataRow rowSklad1 = DovGroup.NewRow();
            rowSklad1[cNameGroup] = "Згинання рук з супінацією";
            DovGroup.Rows.Add(rowSklad1);
            DataRow rowSklad11 = DovGroup.NewRow();
            rowSklad11[cNameGroup] = "Згинання рук широким прямим хватом";
            DovGroup.Rows.Add(rowSklad11);
            DataRow rowSklad12 = DovGroup.NewRow();
            rowSklad12[cNameGroup] = "Згинання рук середнім прямим хватом";
            DovGroup.Rows.Add(rowSklad12);
            DataRow rowSklad13 = DovGroup.NewRow();
            rowSklad13[cNameGroup] = "Згинання рук вузьким прямим хватом";
            DovGroup.Rows.Add(rowSklad13);
            DataRow rowSklad14 = DovGroup.NewRow();
            rowSklad14[cNameGroup] = "Згинання рук середнім оберненим хватом";
            DovGroup.Rows.Add(rowSklad14);
            DataRow rowSklad15 = DovGroup.NewRow();
            rowSklad15[cNameGroup] = "Згинання рук вузьким оберненим хватом";
            DovGroup.Rows.Add(rowSklad15);
            DataRow rowSklad2 = DovGroup.NewRow();
            rowSklad2[cNameGroup] = "Згинання Зотмана";
            DovGroup.Rows.Add(rowSklad2);
            DataRow rowSklad3 = DovGroup.NewRow();
            rowSklad3[cNameGroup] = "Концентровані згинання на біцепс з супінацією";
            DovGroup.Rows.Add(rowSklad3);
            DataRow rowSklad4 = DovGroup.NewRow();
            rowSklad4[cNameGroup] = "Концентровані згинання на біцепс в стилі молот";
            DovGroup.Rows.Add(rowSklad4);
            DataRow rowSklad5 = DovGroup.NewRow();
            rowSklad5[cNameGroup] = "Жим вузьким хватом";
            DovGroup.Rows.Add(rowSklad5);
            DataRow rowSklad6 = DovGroup.NewRow();
            rowSklad6[cNameGroup] = "Віджимання";
            DovGroup.Rows.Add(rowSklad6);
            DataRow rowSklad7 = DovGroup.NewRow();
            rowSklad7[cNameGroup] = "Французький жим";
            DovGroup.Rows.Add(rowSklad7);
            DataRow rowSklad8 = DovGroup.NewRow();
            rowSklad8[cNameGroup] = "Розгинання рук перед собою";
            DovGroup.Rows.Add(rowSklad8);
            DataRow rowSklad9 = DovGroup.NewRow();
            rowSklad9[cNameGroup] = "Розгинання рук за головою";
            DovGroup.Rows.Add(rowSklad9);
        }
        public void Reps(out int min, out int max)
        {
            if (numTypeTrain == 1)
            {
                min = 25;
                max = 35;
            }
            else if (numTypeTrain == 2)
            {
                min = 8;
                max = 15;
            }
            else
            {
                min = 1;
                max = 6;
            }
        }
        public void Sets(out int min, out int max)
        {
            min = 1;
            max = 8;
        }
    }
        public class Shoulders : Base, IPainKiller
        {
            public void Exercises()
            {
                length = 6;
                DataColumn cNameGroup = new DataColumn("Вправа");
                cNameGroup.DataType = Type.GetType("System.String");
                DovGroup.Columns.Add(cNameGroup);
                DataRow rowSklad0 = DovGroup.NewRow();
                rowSklad0[cNameGroup] = "Жим перед собою";
                DovGroup.Rows.Add(rowSklad0);
                DataRow rowSklad1 = DovGroup.NewRow();
                rowSklad1[cNameGroup] = "Жим за головою";
                DovGroup.Rows.Add(rowSklad1);
                DataRow rowSklad2 = DovGroup.NewRow();
                rowSklad2[cNameGroup] = "Тяга на середню дельту";
                DovGroup.Rows.Add(rowSklad2);
                DataRow rowSklad3 = DovGroup.NewRow();
                rowSklad3[cNameGroup] = "Тяга на задню дельту";
                DovGroup.Rows.Add(rowSklad3);
                DataRow rowSklad4 = DovGroup.NewRow();
                rowSklad4[cNameGroup] = "Розведення";
                DovGroup.Rows.Add(rowSklad4);
                DataRow rowSklad5 = DovGroup.NewRow();
                rowSklad5[cNameGroup] = "Піднімання снаряду перед собою";
                DovGroup.Rows.Add(rowSklad5);
                DataRow rowSklad6 = DovGroup.NewRow();
                rowSklad6[cNameGroup] = "Метелик";
                DovGroup.Rows.Add(rowSklad6);
        }
            public void Reps(out int min, out int max)
            {
                if (numTypeTrain == 1)
                {
                    min = 25;
                    max = 35;
                }
                else if (numTypeTrain == 2)
                {
                    min = 8;
                    max = 15;
                }
                else
                {
                    min = 4;
                    max = 6;
                }
            }
            public void Sets(out int min, out int max)
            {
                min = 1;
                max = 8;
            }
        }

    }
