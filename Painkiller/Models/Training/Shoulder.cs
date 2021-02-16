using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painkiller.Models.Training
{
    public class Shoulders : MuscleGroup
    {
        public override String[] GetExercises()
        {
            NameExercises = new String[7];

            NameExercises[0] = "Жим перед собою";
            NameExercises[1] = "Жим за головою";
            NameExercises[2] = "Тяга на середню дельту";
            NameExercises[3] = "Тяга на задню дельту";
            NameExercises[4] = "Розведення";
            NameExercises[5] = "Піднімання снаряду перед собою";
            NameExercises[6] = "Метелик";

            return NameExercises;
        }

        public override void Reps(TypeTrainingEnum typeTraining, out Int32 min, out Int32 max)
        {
            if (typeTraining == TypeTrainingEnum.Statodynamics)
            {
                min = 20;
                max = 35;
            }
            else if (typeTraining == TypeTrainingEnum.Hypertrophy)
            {
                min = 8;
                max = 30;
            }
            else if (typeTraining == TypeTrainingEnum.DevelopmentStrength)
            {
                min = 1;
                max = 7;
            }
            else
            {
                min = 1;
                max = 35;
            }
        }

        public override void Sets(out Int32 min, out Int32 max)
        {
            min = 1;
            max = 8;
        }
    }
}
