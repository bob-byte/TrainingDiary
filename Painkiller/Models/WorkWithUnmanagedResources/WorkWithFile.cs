using Painkiller.PresentationModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Painkiller
{
    class WorkWithFile : AllTrainingTableContext
    {
        String fileAllTrain, fileBadExercise;
        String textRow;
        private Notification notification;

        internal WorkWithFile(Notification notification, String fileAllTrain, String fileBadExercise)
        {
            this.notification = notification;
            this.fileAllTrain = fileAllTrain;
            this.fileBadExercise = fileBadExercise;
        }

        public void RewriteFile(Boolean doDelete, String measure, Boolean previousDay, DataTable laggingExercisesTable)
        {
            StreamReader reader = null;
            StreamWriter writer = null;

            try
            {
                Int32 numberOfDay = 0;
                String textRow;
                List<String> newFile = new List<String>();
                Int32 countDay = 0;

                reader = new StreamReader(fileAllTrain);
                while (reader.Peek() >= 0)
                {
                    textRow = reader.ReadLine();
                    newFile.Add(textRow);
                    if (textRow.Contains("День"))
                    {
                        String[] data = new String[2];
                        countDay++;
                        data = textRow.Split(' ');
                        if (!Int32.TryParse(data[1], out numberOfDay))
                        {
                            notification.MessageInvoke(false, "Файл \"Все тренування\" неправильно записаний");
                        }
                    }
                }
                reader.Close();

                writer = new StreamWriter(fileAllTrain);//якщо не перезапис, то додаємо до вхідного тексту файлу наступні рядки

                if (!doDelete)
                {
                    Int32 numRow = 0;
                    for (Int32 i = 0; i < newFile.Count && numRow < TabTrain.Rows.Count; i++)
                    {
                        if (!newFile[i].Contains("День"))
                        {
                            textRow = $"{TabTrain.Rows[numRow]["Група_мязів"]};{TabTrain.Rows[numRow]["Вправа"]};{TabTrain.Rows[numRow]["Вид_тренування"]};" +
                                $"{TabTrain.Rows[numRow]["Обтяження"]};{TabTrain.Rows[numRow]["Положення"]};" +
                                $"{TabTrain.Rows[numRow]["Max_вага"]} {measure};{TabTrain.Rows[numRow]["К_сть_повторень_з_max_вагою"]} повторень;" +
                                $"{TabTrain.Rows[numRow]["Загальна_к_сть_підходів"]} підходів";
                            newFile[i] = textRow;
                            numRow++;
                        }
                    }
                    if(numRow < TabTrain.Rows.Count && !previousDay)
                    {
                        newFile.Add($"День {++numberOfDay}");
                    }
                    while (numRow < TabTrain.Rows.Count)
                    {
                        textRow = $"{TabTrain.Rows[numRow]["Група_мязів"]};{TabTrain.Rows[numRow]["Вправа"]};{TabTrain.Rows[numRow]["Вид_тренування"]};" +
                                $"{TabTrain.Rows[numRow]["Обтяження"]};{TabTrain.Rows[numRow]["Положення"]};" +
                                $"{TabTrain.Rows[numRow]["Max_вага"]} {measure};{TabTrain.Rows[numRow]["К_сть_повторень_з_max_вагою"]} повторень;" +
                                $"{TabTrain.Rows[numRow]["Загальна_к_сть_підходів"]} підходів";
                        newFile.Add(textRow);
                        numRow++;
                    }
                    foreach (String row in newFile)
                    {
                        writer.WriteLine(row);
                    }
                }
                else
                {
                    if(TabTrain.Rows.Count > 0)
                    {
                        writer.WriteLine($"День 1");
                        foreach (DataRow r in TabTrain.Rows)
                        {
                            textRow = $"{r["Група_мязів"]};{r["Вправа"]};{r["Вид_тренування"]};{r["Обтяження"]};{r["Положення"]};" +
                                $"{r["Max_вага"]} {measure};{r["К_сть_повторень_з_max_вагою"]} повторень;{r["Загальна_к_сть_підходів"]} підходів";
                            writer.WriteLine(textRow);
                        }
                    }
                }

                writer.Close();
                notification.MessageInvoke(true, "Інформація у файл \"Все тренування\" записана");
            }
            catch (Exception ex)
            {
                notification.MessageInvoke(false, ex.Message);
            }
            finally
            {
                reader?.Close();
                writer?.Close();
            }

            WriteInFileBadExercise(measure, laggingExercisesTable);
        }

        public void WriteTabInFile(Boolean allTrain, String measure, DataTable laggingExercisesTable)
        {
            StreamReader reader = null;
            StreamWriter writer = null;
            Int32 numberOfDay = 0;

            try
            {
                String textRow;

                if (allTrain)
                {
                    reader = new StreamReader(fileAllTrain);
                    while (reader.Peek() >= 0)
                    {
                        textRow = reader.ReadLine();
                        if (textRow.Contains("День"))
                        {
                            String[] data = new String[2];
                            data = textRow.Split(' ');
                            if (!Int32.TryParse(data[1], out numberOfDay))
                            {
                                notification.MessageInvoke(false, "Файл \"Все тренування\" неправильно записаний");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                notification.MessageInvoke(false, ex.Message);
            }
            finally
            {
                reader?.Close();
            }

            try
            {
                writer = new StreamWriter(fileAllTrain, true);
                if (allTrain)
                {
                    writer.WriteLine($"День {++numberOfDay}");
                }
                foreach (DataRow r in TabTrain.Rows)
                {
                    textRow = $"{r["Група_мязів"]};{r["Вправа"]};{r["Вид_тренування"]};{r["Обтяження"]};{r["Положення"]};" +
                            $"{r["Max_вага"]} {measure};{r["К_сть_повторень_з_max_вагою"]} повторень;{r["Загальна_к_сть_підходів"]} підходів";
                    writer.WriteLine(textRow);
                }
                
                notification.MessageInvoke(true, "Інформація у файл \"Все тренування\" записана");
            }
            catch (Exception ex)
            {
                notification.MessageInvoke(false, ex.Message);
            }
            finally
            {
                writer?.Close();
            }

            WriteInFileBadExercise(measure, laggingExercisesTable);
        }

        private void WriteInFileBadExercise(String measure, DataTable laggingExercisesTable)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileBadExercise, true))
                {
                    foreach (DataRow r in laggingExercisesTable.Rows)
                    {
                        if (r["Вправа "].ToString() == "")
                        {
                            continue;
                        }
                        textRow = $"{r["Група_мязів "]};{r["Вправа "]};{r["Обтяження "]};" +
                            $"{r["Положення тіла "]};{r["Max_вага "]} {measure};{r["К_сть_повторень_з_max_вагою "]} повторень";
                        sw.WriteLine(textRow);
                    }
                }

                notification.MessageInvoke(true, "Інформація у файл \"Відстаючі вправи\" записана");
            }
            catch (Exception ex)
            {
                notification.MessageInvoke(false, ex.Message);
            }
        }

        public void ReadTabFile(DataGridView allTrain, String measure)
        {
            try
            {
                using StreamReader sr = new StreamReader(fileAllTrain);

                List<String[]> rowsFromFile = new List<String[]>();

                while (sr.Peek() >= 0)//поки у файлі є елементи
                {
                    textRow = sr.ReadLine();
                    String[] partTrain = textRow.Split(';');

                    if (partTrain[0].Contains("День"))
                    {
                        continue;
                    }
                    partTrain[5] = partTrain[5].Trim((" " + measure).ToCharArray());
                    partTrain[6] = partTrain[6].Trim(" повторень".ToCharArray());
                    partTrain[7] = partTrain[7].Trim(" підходів".ToCharArray());

                    rowsFromFile.Add(partTrain);

                    //TTrainingAddRow(partTrain[0], partTrain[1], partTrain[2], partTrain[3], partTrain[4],
                    //    Convert.ToInt32(partTrain[5]), Convert.ToInt32(partTrain[6]), Convert.ToInt32(partTrain[7]));
                }
            }
            catch (Exception ex)
            {
                notification.MessageInvoke(false, ex.Message);
            }

            for (Int32 i = 0; i < allTrain.Rows.Count - 1; i++)
            {
                allTrain.Rows[i].Cells["N_пп"].Value = i + 1;
            }
        }
    }
}
