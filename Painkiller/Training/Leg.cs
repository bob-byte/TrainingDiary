using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painkiller.Training
{
    public class Legs : Base, IPainKiller
    {
        public String[] Exercises()
        {
            NameExercises = new String[9];
            NameExercises[0] = "Присідання";
            NameExercises[1] = "Фронтальні присідання";
            NameExercises[2] = "Мертва тяга";
            NameExercises[3] = "Жим ногами";
            NameExercises[4] = "Випади на місці";
            NameExercises[5] = "Випади ходьбою";
            NameExercises[6] = "Розгинання ніг";
            NameExercises[7] = "Згинання ніг";
            NameExercises[8] = "Підйоми на носки";

            return NameExercises;
        }
        public void Reps(out Int32 min, out Int32 max)
        {
            if (NumTypeTrain == 1)
            {
                min = 20;
                max = 40;
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
