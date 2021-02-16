using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painkiller.PresentationModels
{
    public partial class MainPresentationModel
    {
        private RelayCommand sortMainTableCommand;

        public RelayCommand SortMainTableCommand
        {
            get => sortMainTableCommand ?? (new RelayCommand(obj =>
            {
                DialogSort sortDialog = new DialogSort();
                sortDialog.ShowDialog();
                //sortDialog.TTrainingSort(AllTrainingTableContext.DialogCriteria, AllTraining, AllTrainingTableContext.TrainView);
            }));
        }

        private RelayCommand resetSortMainTableCommand;

        public RelayCommand ResetSortMainTableCommand
        {
            get => resetSortMainTableCommand ?? (new RelayCommand(obj =>
            {
                sortDialog.TTrainingSort("", dataGridAllTraining, allTrainingTableContext.TrainView);
            }));
        }
    }
}
