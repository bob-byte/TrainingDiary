using Painkiller.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painkiller.PresentationModels
{
    partial class MainPresentationModel
    {
        private RelayCommand enterDataInDatabaseCommand;
        public RelayCommand clearMainTableInDBCommand;
        private DialogSort sortDialog = new DialogSort();
        private Notification notification = new Notification();
        private WorkWithDatabase opDatabase;

        public RelayCommand EnterDataInDatabaseCommand
        {
            get => enterDataInDatabaseCommand ?? (new RelayCommand(obj =>
            {
                sortDialog.TTrainingSort("", dataGridAllTraining, allTrainingTableContext.TrainView);
            }));
        }

        public RelayCommand ClearMainTableInDBCommand
        {
            get => clearMainTableInDBCommand ?? (new RelayCommand(obj =>
             {
                 DialogResult doClearMainTableInDB = MessageBox.Show("Ви впевнені, що хочете очистити головну таблицю в базі даних? Повернути незаписані дані буде неможливо",
                "Попередження", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                 if (doClearMainTableInDB == DialogResult.Yes)
                 {
                     AddMessage(true, true, notification);

                     SqlConnection connect;

                     opDatabase.ConnectDB(out connect);
                     connect.Open();
                     opDatabase.ClearMainTabDB(connect);
                     connect.Close();
                 }
             }));
        }

    }
}
