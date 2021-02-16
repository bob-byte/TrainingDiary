using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painkiller.Models.Training
{
    public class Chest : MuscleGroup
    {
        public override String[] GetExercises()
        {
            NameExercises = new String[5];

            NameExercises[0] = "Жим (широким хватом)";
            NameExercises[1] = "Віджимання";
            NameExercises[2] = "Паралельний жим";
            NameExercises[3] = "Пуловер";
            NameExercises[4] = "Зведення рук";

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
