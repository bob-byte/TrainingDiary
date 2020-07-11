using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painkiller
{
    class WorkDB
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

        internal  void WriteGrid(DataTable grid, DomainUpDown unitMeasure)
        {
            using (SqlConnection connect = new SqlConnection())
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connect;
                command.CommandType = CommandType.StoredProcedure;
                connect.ConnectionString = "Data Source = (local)\\SQLEXPRESS; Initial Catalog = Training; " +
                    "Integrated Security = True";
                connect.Open();                              //відкрили з'єднання
                SqlTransaction tranPlSave = connect.BeginTransaction("tranPlSave");
                command.Transaction = tranPlSave;
                try
                {
                    command.CommandText = "spWriteTrain";
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
                    messageNegative?.Invoke(this, new MessageEventArgs($"Таблицю не вдалося записати в базу даних: {ex.Message}"));
                    tranPlSave.Rollback();//Виконати відкад у випадку невдалого записування
                    return;
                }
                messagePositive?.Invoke(this, new MessageEventArgs($"Таблиця записана в базу даних"));
            }
        }
         internal void ReadDatabase(DataTable table, DataGridView dGV)
        {
            SqlConnection connect = new SqlConnection();
            SqlCommand com = new SqlCommand();
            com.Connection = connect;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "spTrainTabRead";
            connect.ConnectionString = "Data Source = (local)\\SQLEXPRESS; Initial Catalog = Training; " +
                "Integrated Security = True";
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
            for (int i = 0; i < dGV.Rows.Count - 1; i++)
            {
                dGV.Rows[i].Cells["N_пп"].Value = i + 1;
            }
        }
    }
}
