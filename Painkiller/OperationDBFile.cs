using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Painkiller
{
    class OperationDBFile : Base
    {
        SqlTransaction tranPlSave;

        String fileAllTrain, fileBadExercise;
        String textRow;

        internal OperationDBFile()
        {
            fileAllTrain = "Все тренування.txt";
            fileBadExercise = "Відстаючі вправи.txt";
        }

        internal void WriteDB(DataTable grid, String measure)
        {
            SqlConnection connect = new SqlConnection();
            SqlCommand command = new SqlCommand();
            ConnectDB(connect, command, "spWriteTrain");
            try
            {
                connect.Open();
                tranPlSave = connect.BeginTransaction("tranPlSave");
                command.Transaction = tranPlSave;
                foreach (DataRow rr in grid.Rows)
                {
                    command.Parameters.Clear();
                    SqlParameter par1 = new SqlParameter("@N_pp", SqlDbType.Int);
                    par1.Value = rr["N_пп"];
                    SqlParameter par2 = new SqlParameter(@"groupMuscle", SqlDbType.NVarChar, 50);
                    par2.Value = rr["Група_мязів"];
                    SqlParameter par3 = new SqlParameter("@typeTraining", SqlDbType.NVarChar, 255);
                    par3.Value = rr["Вид_тренування"];
                    SqlParameter par4 = new SqlParameter(@"exercise", SqlDbType.NVarChar, 255);
                    par4.Value = rr["Вправа"];
                    SqlParameter par5 = new SqlParameter(@"encumbrance", SqlDbType.NVarChar, 255);
                    par5.Value = rr["Обтяження"];
                    SqlParameter par6 = new SqlParameter(@"position", SqlDbType.NVarChar, 255);
                    par6.Value = rr["Положення"];
                    SqlParameter par7, par8;
                    if (measure == "кг")
                    {
                        par7 = new SqlParameter(@"weightKg", SqlDbType.Int);
                        par7.Value = rr["Max_вага"];
                        par8 = new SqlParameter(@"weightLb", SqlDbType.Int);
                        par8.Value = 0;
                    }
                    else
                    {
                        par7 = new SqlParameter(@"weightKg", SqlDbType.Int);
                        par7.Value = 0;
                        par8 = new SqlParameter(@"weightLb", SqlDbType.Int);
                        par8.Value = rr["Max_вага"];
                    }
                    SqlParameter par9 = new SqlParameter(@"reps", SqlDbType.Int);
                    par9.Value = rr["К_сть_повторень_з_max_вагою"];
                    SqlParameter par10 = new SqlParameter(@"sets", SqlDbType.Int);
                    par10.Value = rr["Загальна_к_сть_підходів"];
                    command.Parameters.Add(par1);
                    command.Parameters.Add(par2);
                    command.Parameters.Add(par3);
                    command.Parameters.Add(par4);
                    command.Parameters.Add(par5);
                    command.Parameters.Add(par6);
                    command.Parameters.Add(par7);
                    command.Parameters.Add(par8);
                    command.Parameters.Add(par9);
                    command.Parameters.Add(par10);
                    command.ExecuteNonQuery();
                }
                tranPlSave.Commit();//підтвердження всіх змін у базі даних
            }
            catch (Exception ex)
            {
                tranPlSave.Rollback();//Виконати відкад у випадку невдалого записування
                MessageInvoke(false, $"Таблицю не вдалося записати в базу даних: {ex.Message}");
                return;
            }
            finally
            {
                connect.Close();
            }
            MessageInvoke(true, "Таблиця записана в базу даних");
        }

        void ConnectDB(SqlConnection connect, SqlCommand command, String commandText)
        {
            command.Connection = connect;
            command.CommandType = CommandType.StoredProcedure;
            connect.ConnectionString = "Data Source = (local)\\SQLEXPRESS; Initial Catalog = Training; " +
                "Integrated Security = True";
            command.CommandText = commandText;
        }

        internal void ReadDB(DataTable table, DataGridView dGV)
        {
            SqlConnection connect = new SqlConnection();
            SqlCommand com = new SqlCommand();
            ConnectDB(connect, com, "spTrainTabRead");
            try
            {
                connect.Open();
                SqlDataReader SqlLn = com.ExecuteReader();
                while (SqlLn.Read())
                {
                    DataRow row = table.NewRow();
                    row["N_пп"] = SqlLn.GetInt32(0);
                    row["Група_мязів"] = SqlLn.GetString(1);
                    row["Вид_тренування"] = SqlLn.GetString(2);
                    row["Вправа"] = SqlLn.GetString(3);
                    row["Обтяження"] = SqlLn.GetString(4);
                    row["Положення"] = SqlLn.GetString(5);
                    if (SqlLn.GetInt32(6) != 0)
                    {
                        row["Max_вага"] = SqlLn.GetInt32(6);
                    }
                    else if (SqlLn.GetInt32(7) != 0)
                    {
                        row["Max_вага"] = SqlLn.GetInt32(7);
                    }
                    else
                    {
                        row["Max_вага"] = 0;
                    }
                    row["К_сть_повторень_з_max_вагою"] = SqlLn.GetInt32(8);
                    row["Загальна_к_сть_підходів"] = SqlLn.GetInt32(9);
                    table.Rows.Add(row);
                }
            }
            catch(Exception ex)
            {
                MessageInvoke(false, ex.Message);
            }
            finally
            {
                connect.Close();
            }
            for (Int32 i = 0; i < dGV.Rows.Count - 1; i++)
            {
                dGV.Rows[i].Cells["N_пп"].Value = i + 1;
            }
        }

        public void ClearMainTabDB()
        {
            SqlConnection connect = new SqlConnection();
            SqlCommand com = new SqlCommand();
            ConnectDB(connect, com, "spClearTrain");
            try
            {
                connect.Open();
                com.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageInvoke(false, ex.Message);
                return;
            }

            MessageInvoke(true, "Головна таблиця успішно очищена");
        }

        public void RewriteFile(Boolean whetherDelete, String measure, Boolean previousDay)
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
                            MessageInvoke(false, "Файл \"Все тренування\" неправильно записаний");
                        }
                    }
                }
                reader.Close();

                writer = new StreamWriter(fileAllTrain);//якщо не перезапис, то додаємо до вхідного тексту файлу наступні рядки

                if (!whetherDelete)
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
                MessageInvoke(true, "Інформація у файл \"Все тренування\" записана");
            }
            catch (Exception ex)
            {
                MessageInvoke(false, ex.Message);
            }
            finally
            {
                reader?.Close();
                writer?.Close();
            }

            WriteInFileBadExercise(measure);
        }

        public void WriteTabInFile(Boolean allTrain, String measure)
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
                                MessageInvoke(false, "Файл \"Все тренування\" неправильно записаний");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if(ex is FileNotFoundException == false)
                {
                    MessageInvoke(false, ex.Message);
                }
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
                
                MessageInvoke(true, "Інформація у файл \"Все тренування\" записана");
            }
            catch (Exception ex)
            {
                MessageInvoke(false, ex.Message);
            }
            finally
            {
                writer?.Close();
            }

            WriteInFileBadExercise(measure);
        }

        private void WriteInFileBadExercise(String measure)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileBadExercise, true))
                {
                    foreach (DataRow r in TabMinTrain.Rows)
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

                MessageInvoke(true, "Інформація у файл \"Відстаючі вправи\" записана");
            }
            catch (Exception ex)
            {
                MessageInvoke(false, ex.Message);
            }
        }

        public void ReadTabFile(DataGridView allTrain, String measure)
        {
            try
            {
                using StreamReader sr = new StreamReader(fileAllTrain);
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

                    TTrainingAddRow(partTrain[0], partTrain[1], partTrain[2], partTrain[3], partTrain[4],
                        Convert.ToInt32(partTrain[5]), Convert.ToInt32(partTrain[6]), Convert.ToInt32(partTrain[7]));
                }
            }
            catch (Exception ex)
            {
                MessageInvoke(false, ex.Message);
            }
            for (Int32 i = 0; i < allTrain.Rows.Count - 1; i++)
            {
                allTrain.Rows[i].Cells["N_пп"].Value = i + 1;
            }
        }
    }
}
