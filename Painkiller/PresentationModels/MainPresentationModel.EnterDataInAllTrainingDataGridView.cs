using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painkiller.PresentationModels
{
    public partial class MainPresentationModel
    {
        private RelayCommand enterDataInAllTrainingDGV;

        public RelayCommand EnterDataInAllTrainingDGV
        {
            get => enterDataInAllTrainingDGV ?? (new RelayCommand(obj =>
            {

            }));
        }

        
    }
}
