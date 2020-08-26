using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Drawing;

namespace Painkiller
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
    public class Back : Base, IPainKiller
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
    public class Chest : Base, IPainKiller
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
    public class Arms : Base, IPainKiller
    {
        public String[] Exercises()
        {
            NameExercises = new String[15];
            NameExercises[0] = "Молотки";
            NameExercises[1] = "Згинання рук з супінацією";
            NameExercises[2] = "Згинання рук широким прямим хватом";
            NameExercises[3] = "Згинання рук середнім прямим хватом";
            NameExercises[4] = "Згинання рук вузьким прямим хватом";
            NameExercises[5] = "Згинання рук середнім оберненим хватом";
            NameExercises[6] = "Згинання рук вузьким оберненим хватом";
            NameExercises[7] = "Згинання Зотмана";
            NameExercises[8] = "Концентровані згинання на біцепс з супінацією";
            NameExercises[9] = "Концентровані згинання на біцепс в стилі молот";
            NameExercises[10] = "Жим вузьким хватом";
            NameExercises[11] = "Віджимання";
            NameExercises[12] = "Французький жим";
            NameExercises[13] = "Розгинання рук перед собою";
            NameExercises[14] = "Розгинання рук за головою";
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
                max = 25;
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
    public class Shoulders : Base, IPainKiller
    {
        public String[] Exercises()
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
                max = 30;
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
