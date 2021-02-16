using Painkiller.Models.Training;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painkiller.PresentationModels
{
    public partial class MainPresentationModel
    {
        private RelayCommand selectedEncumbranceCommand;

        public RelayCommand SelectedEncumbranceCommand =>
            selectedEncumbranceCommand ?? (new RelayCommand(obj =>
            {
                typeEncumbrance = GetSelectedTypeEncumbranceEnum(groupBoxTypesEncumbrances);

                unitMeasure = UnitMeasure.GetUnitMeasureEnum(dudUnitMeasure.Text);

                PutLabelRightPlace(lMaxWeight, typeEncumbrance);
            }));

        private TypeEncumbranceEnum GetSelectedTypeEncumbranceEnum(GroupBox groupBox)
        {
            foreach (var item in groupBox.Controls)
            {
                if (item is RadioButton radioButton && radioButton.Checked)
                {
                    return TypeEncumbrance.GetTypeEncumbranceEnum(radioButton.Text);
                }
            }

            return TypeEncumbranceEnum.InvalidType;
        }

        private void PutLabelRightPlace(Label label, TypeEncumbranceEnum typeEncumbrance)
        {
            switch(typeEncumbrance)
            {
                case TypeEncumbranceEnum.Dumbbell:
                    {
                        label.Text = "Max вага однієї гантелі";
                        label.Location = new Point(144, label.Location.Y);

                        return;
                    }
                case TypeEncumbranceEnum.Bar:
                    {
                        label.Text = "Max вага";
                        label.Location = new Point(194, label.Location.Y);

                        return;
                    }

                case TypeEncumbranceEnum.Bloc:
                    {
                        label.Text = "Max вага одного блоку";
                        label.Location = new Point(144, label.Location.Y);

                        return;
                    }

                case TypeEncumbranceEnum.Machine:
                    {
                        label.Text = "Max вага";
                        label.Location = new Point(194, label.Location.Y);

                        return;
                    }

                case TypeEncumbranceEnum.BodyWeight:
                    {
                        label.Text = "Додаткова вага";
                        label.Location = new Point(168, label.Location.Y);

                        return;
                    }
            }
        }
    }
}
