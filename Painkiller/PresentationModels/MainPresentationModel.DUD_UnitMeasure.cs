using Painkiller.Models.Training;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painkiller.PresentationModels
{
    public partial class MainPresentationModel
    {
        private RelayCommand dudUnitMeasureScrollCommand;

        public RelayCommand DUD_UnitMeasureScrollCommand =>
            dudUnitMeasureScrollCommand ?? (new RelayCommand(obj =>
            {
                UnitMeasure measureConvert = new UnitMeasure(unitMeasure, notification);
                measureConvert.CalculateNewMeasure(allTrainingTableContext.TabTrain, AllTrainingTableContext.WEIGHT_COLUMN);
                measureConvert.CalculateNewMeasure(allTrainingTableContext.TabMinTrain, AllTrainingTableContext.WEIGHT_COLUMN);
            }));

        
    }
}
