using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painkiller.Training
{
    public class Back : Base, Painkiller.IMuscleGroup
    {
        public String[] Exercises()
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

        public void Reps(out Int32 min, out Int32 max)
        {
            if (NumTypeTrain == 1)
            {
                min = 20;
                max = 33;
            }
            else if (NumTypeTrain == 2)
            {
                min = 8;
                max = 20;
            }
            else
            {
                min = 1;
                max = 7;
            }
        }

        public void Sets(out Int32 min, out Int32 max)
        {
            min = 1;
            max = 10;
        }
    }
}
