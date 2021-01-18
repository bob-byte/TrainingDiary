using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painkiller.Training
{
    public class Chest : Base, Painkiller.IExercise
    {
        public String[] Exercises()
        {
            NameExercises = new String[5];
            NameExercises[0] = "Жим (широким хватом)";
            NameExercises[1] = "Віджимання";
            NameExercises[2] = "Паралельний жим";
            NameExercises[3] = "Пуловер";
            NameExercises[4] = "Зведення рук";

            return NameExercises;
        }

        public void Reps(out Int32 min, out Int32 max)
        {
            if (NumTypeTrain == 1)
            {
                min = 20;
                max = 35;
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
            max = 8;
        }
    }
}
