using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Painkiller
{
    class OperationDBFile : Base
    {
        SqlTransaction tranPlSave;

        static String fileAllTrain, fileBadExercise;
        String textRow;

        internal OperationDBFile()
        {
            fileAllTrain = "Все тренування.txt";
            fileBadExercise = "Відстаючі вправи.txt";
        }

        internal void WriteDB(DataTable grid, DomainUpDown unitMeasure)
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
                    if (unitMeasure.Text == "кг")
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
                MessageInvoke(false, $"Таблицю не вдалося записати в базу даних: {ex.Message}");
                tranPlSave.Rollback();//Виконати відкад у випадку невдалого записування
                return;
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
                connect.Close();
            }
            catch(SqlException ex)
            {
                MessageInvoke(false, ex.Message);
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
            connect.Close();

            MessageInvoke(true, "Головна таблиця успішно очищена");
        }

        public void WriteTabFile(Boolean allTrain, Boolean rewrite)
        {
            try
            {
                Int32 i = 0;
                String textRow;

                if (allTrain && !rewrite)
                {
                    StreamReader sr = new StreamReader(fileAllTrain);
                    while (sr.Peek() >= 0)
                    {
                        textRow = sr.ReadLine();
                        if (textRow.Contains("День"))
                        {
                            String[] data = new String[2];
                            data = textRow.Split(' ');
                            if (!Int32.TryParse(data[1], out i))
                            {
                                MessageInvoke(false, "Файл \"Все тренування\" неправильно записаний");
                            }
                        }
                    }
                    sr.Close();
                }

                StreamWriter sw1 = new StreamWriter(fileAllTrain, !rewrite);//якщо не перезапис, то додаємо до вхідного тексту файлу наступні рядки
                if (allTrain)
                {
                    sw1.WriteLine($"День {++i}");
                }
                foreach (DataRow r in TabTrain.Rows)
                {
                    this.textRow = $"{r["Група_мязів"]};{r["Вправа"]};{r["Вид_тренування"]};{r["Обтяження"]};{r["Положення"]};" +
                        $"{r["Max_вага"]};{r["К_сть_повторень_з_max_вагою"]};{r["Загальна_к_сть_підходів"]}";
                    sw1.WriteLine(this.textRow);
                }
                sw1.Close();
                MessageInvoke(true, "Інформація у файл \"Все тренування\" записана");
            }
            catch (Exception ex)
            {
                MessageInvoke(true, ex.Message);
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(fileBadExercise))
                {
                    foreach (DataRow r in Base.TabMinTrain.Rows)
                    {
                        if (r["Вправа "].ToString() == "")
                        {
                            continue;
                        }
                        textRow = $"{r["Група_мязів "]};{r["Вправа "]};{r["Обтяження "]};" +
                            $"{r["Положення тіла "]};{r["Max_вага "]};{r["К_сть_повторень_з_max_вагою "]}";
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
        public void ReadTabFile(DataGridView allTrain)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileAllTrain))
                {
                    while (sr.Peek() >= 0)//поки у файлі є елементи
                    {
                        textRow = sr.ReadLine();
                        String[] partTrain = textRow.Split(';');

                        if (partTrain[0].Contains("День"))
                        {
                            continue;
                        }
                        TTrainingAddRow(partTrain[0], partTrain[1], partTrain[2], partTrain[3], partTrain[4], 
                            Convert.ToInt32(partTrain[5]), Convert.ToInt32(partTrain[6]), Convert.ToInt32(partTrain[7]));
                    }
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
