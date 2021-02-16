using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painkiller.Models.Training
{
    public class Back : MuscleGroup
    {
        public override String[] GetExercises()
        {
            NameExercises = new String[12];

            NameExercises[0] = "Станова тяга";

            NameExercises[1] = "Тяга зверху перед собою прямим широким хватом";
            NameExercises[2] = "Тяга зверху перед собою прямим середнім хватом";
            NameExercises[3] = "Тяга зверху перед собою прямим вузьким хватом";
            NameExercises[4] = "Тяга зверху перед собою паралельним хватом";
            NameExercises[5] = "Тяга зверху перед собою оберненим середнім хватом";

            NameExercises[6] = "Тяга за голову";
            NameExercises[7] = "Тяга до поясу";
            NameExercises[8] = "Пуловер";
            NameExercises[9] = "Шраги";

            NameExercises[10] = "Good morning";
            NameExercises[11] = "Гіперекстензія";

            return NameExercises;
        }

        public override void Reps(TypeTrainingEnum typeTraining, out Int32 min, out Int32 max)
        {
            if (typeTraining == TypeTrainingEnum.Statodynamics)
            {
                min = 20;
                max = 33;
            }
            else if (typeTraining == TypeTrainingEnum.Hypertrophy)
            {
                min = 8;
                max = 20;
            }
            else if (typeTraining == TypeTrainingEnum.DevelopmentStrength)
            {
                min = 1;
                max = 7;
            }
            else
            {
                min = 1;
                max = 33;
            }
        }

        public override void Sets(out Int32 min, out Int32 max)
        {
            min = 1;
            max = 10;
        }
    }
}
