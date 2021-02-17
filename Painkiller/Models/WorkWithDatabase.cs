using Painkiller.Models.Training;
using Painkiller.PresentationModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painkiller.Models
{
    class WorkWithDatabase
    {
        private SqlCommand command = new SqlCommand();
        private Notification notification;

        public WorkWithDatabase(Notification notification)
        {
            this.notification = notification;
        }

        public void ConnectDB(out SqlConnection connect)
        {
            connect = new SqlConnection("Data Source = (local)\\SQLEXPRESS; Initial Catalog = Training; " +
                "Integrated Security = True");
            command.Connection = connect;
        }

        public void WriteDB(DataTable grid, SqlConnection connect, UnitMeasureEnum unitMeasure)
        {
            if (connect.State != ConnectionState.Open)
            {
                notification.MessageInvoke(false, "Помилка зі з'єднанням до бази даних");
                return;
            }
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spWriteTrain";

            SqlTransaction tranPlSave = null;
            try
            {
                tranPlSave = connect.BeginTransaction("tranPlSave");
                command.Transaction = tranPlSave;

                foreach (DataRow row in grid.Rows)
                {
                    command.Parameters.Clear();

                    SqlParameter[] sqlParameters = GetSqlParametersToRewriteMainTable(row, unitMeasure);
                    if (sqlParameters[6].Value == null)
                    {
                        return;
                    }

                    command.Parameters.AddRange(sqlParameters);

                    command.ExecuteNonQuery();
                }
                tranPlSave.Commit();//підтвердження всіх змін у базі даних
            }
            catch
            {
                if(tranPlSave != null)
                {
                    tranPlSave.Rollback();//Виконати відкад у випадку невдалого записування
                }

                notification.MessageInvoke(false, $"Таблицю не вдалося записати в базу даних");
                return;
            }

            notification.MessageInvoke(true, "Таблиця записана в базу даних");
        }

        private SqlParameter[] GetSqlParametersToRewriteMainTable(DataRow row, UnitMeasureEnum unitMeasure)
        {
            SqlParameter[] sqlParameters = new SqlParameter[10];

            sqlParameters[0] = new SqlParameter("@N_pp", SqlDbType.Int);
            sqlParameters[0].Value = row["N_пп"];

            sqlParameters[1] = new SqlParameter(@"groupMuscle", SqlDbType.NVarChar, 50);
            sqlParameters[1].Value = row["Група_мязів"];

            sqlParameters[2] = new SqlParameter("@typeTraining", SqlDbType.NVarChar, 255);
            sqlParameters[2].Value = row["Вид_тренування"];

            sqlParameters[3] = new SqlParameter(@"exercise", SqlDbType.NVarChar, 255);
            sqlParameters[3].Value = row["Вправа"];

            sqlParameters[4] = new SqlParameter(@"encumbrance", SqlDbType.NVarChar, 255);
            sqlParameters[4].Value = row["Обтяження"];

            sqlParameters[5] = new SqlParameter(@"position", SqlDbType.NVarChar, 255);
            sqlParameters[5].Value = row["Положення"];

            DefineSqlParameterWeight(row, unitMeasure, out sqlParameters[6], out sqlParameters[7]);

            sqlParameters[8] = new SqlParameter(@"reps", SqlDbType.Int);
            sqlParameters[8].Value = row["К_сть_повторень_з_max_вагою"];

            sqlParameters[9] = new SqlParameter(@"sets", SqlDbType.Int);
            sqlParameters[9].Value = row["Загальна_к_сть_підходів"];

            return sqlParameters;
        }

        private void DefineSqlParameterWeight(DataRow row, UnitMeasureEnum unitMeasure, out SqlParameter parameterWeightKg, out SqlParameter parameterWeightLb)
        {
            parameterWeightKg = new SqlParameter(@"weightKg", SqlDbType.Int);
            parameterWeightLb = new SqlParameter(@"weightLb", SqlDbType.Int);

            if (unitMeasure == UnitMeasureEnum.Kg)
            {
                parameterWeightKg.Value = row["Max_вага"];
                parameterWeightLb.Value = 0;
            }
            else if (unitMeasure == UnitMeasureEnum.Lb)
            {
                parameterWeightKg.Value = 0;
                parameterWeightLb.Value = row["Max_вага"];
            }
            else
            {
                notification.MessageInvoke(false, "Неправильно задано одиницю вимірювання");
            }
        }

        public void ReadDB(DataTable table, SqlConnection connect)
        {
            if(connect.State != ConnectionState.Open)
            {
                notification.MessageInvoke(false, "Помилка зі з'єднанням до бази даних");
                return;
            }

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spTrainTabRead";

            try
            {
                SqlDataReader sqlReader = command.ExecuteReader();

                while (sqlReader.Read())
                {
                    DataRow row = GetNewDataRow(table, sqlReader);
                    table.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                notification.MessageInvoke(false, ex.Message);
            }
        }

        private DataRow GetNewDataRow(DataTable table, SqlDataReader sqlReader)
        {
            DataRow row = table.NewRow();

            row[AllTrainingTableContext.COUNTER_COLUMN] = sqlReader.GetInt32(0);
            row[AllTrainingTableContext.GROUP_MUSCLE_COLUMN] = sqlReader.GetString(1);
            row[AllTrainingTableContext.TYPE_TRAINING_COLUMN] = sqlReader.GetString(2);
            row[AllTrainingTableContext.EXERCISE_COLUMN] = sqlReader.GetString(3);
            row[AllTrainingTableContext.BURDEN_COLUMN] = sqlReader.GetString(4);
            row[AllTrainingTableContext.POSITION_COLUMN] = sqlReader.GetString(5);

            DefineMaxWeightFromDB(row, sqlReader);

            row[AllTrainingTableContext.REPS_COLUMN] = sqlReader.GetInt32(8);
            row[AllTrainingTableContext.SETS_COLUMN] = sqlReader.GetInt32(9);

            return row;
        }

        private void DefineMaxWeightFromDB(DataRow row, SqlDataReader sqlReader)
        {
            if (sqlReader.GetInt32(6) != 0)
            {
                row[AllTrainingTableContext.WEIGHT_COLUMN] = sqlReader.GetInt32(6);
            }
            else if (sqlReader.GetInt32(7) != 0)
            {
                row[AllTrainingTableContext.WEIGHT_COLUMN] = sqlReader.GetInt32(7);
            }
            else
            {
                row[AllTrainingTableContext.WEIGHT_COLUMN] = 0;
            }
        }

        public void ClearMainTabDB(SqlConnection connect)
        {
            if (connect.State != ConnectionState.Open)
            {
                notification.MessageInvoke(false, "Помилка зі з'єднанням до бази даних");
                return;
            }

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spClearTrain";

            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                notification.MessageInvoke(false, ex.Message);
                return;
            }

            notification.MessageInvoke(true, "Головна таблиця успішно очищена");
        }
    }
}
