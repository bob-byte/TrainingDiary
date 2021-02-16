using System;
using System.Windows.Forms;
using System.Drawing;
using Painkiller.Models.Training;
using Painkiller.PresentationModels;

namespace Painkiller
{
    public partial class MainForm : Form
    {
        private MainPresentationModel mainPresentationModel;

        public MainForm()
        {
            InitializeComponent();
            mainPresentationModel = new MainPresentationModel(AllTraining, GBTypesTraining, groupBox2, CBGroup, CBExercise, NReps, NSets, NWeight, DUD_UnitMeasure, label5);

            RBStatodynamic.CheckedChanged += (s, e) => mainPresentationModel.ChangeViewWhenSelectedTypeTrainingCommand.Execute(null);
            RBHipertrophy.CheckedChanged += (s, e) => mainPresentationModel.ChangeViewWhenSelectedTypeTrainingCommand.Execute(null);
            RBStrength.CheckedChanged += (s, e) => mainPresentationModel.ChangeViewWhenSelectedTypeTrainingCommand.Execute(null);

            CBGroup.SelectedIndexChanged += (s, e) => mainPresentationModel.CBGroupSelectedIndexChangedCommand.Execute(null);

            CBExercise.SelectedIndexChanged += (s, e) => mainPresentationModel.CBExerciseSelectedIndexChangedCommand.Execute(null);
            CBExercise.Click += (s, e) => mainPresentationModel.CBExerciseClickCommand.Execute(null);

            RBDumb_Bell.CheckedChanged += (s, e) => mainPresentationModel.SelectedEncumbranceCommand.Execute(null);
            RBBar.CheckedChanged += (s, e) => mainPresentationModel.SelectedEncumbranceCommand.Execute(null);
            RBBlok.CheckedChanged += (s, e) => mainPresentationModel.SelectedEncumbranceCommand.Execute(null);
            RBMachine.CheckedChanged += (s, e) => mainPresentationModel.SelectedEncumbranceCommand.Execute(null);
            RBBodyWeight.CheckedChanged += (s, e) => mainPresentationModel.SelectedEncumbranceCommand.Execute(null);

            SendMeasure = DUD_UnitMeasure.Text;
            SetFreezeComboBoxes();
        }

        internal static DataGridView SendDialogSeek { get; private set; }
        internal static String SendMeasure { get; private set; }

        private void SetFreezeComboBoxes()
        {
            CBGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            CBExercise.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}