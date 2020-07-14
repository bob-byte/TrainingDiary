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
            names = new String[8];
            names[0] = "Присідання";
            names[1] = "Фронтальні присідання";
            names[2] = "Мертва тяга";
            names[3] = "Жим ногами";
            names[4] = "Випади на місці";
            names[5] = "Випади ходьбою";
            names[6] = "Розгинання ніг";
            names[7] = "Згинання ніг";
            return names;
        }
        public void Reps(out int min, out int max)
        {
            if (numTypeTrain == 1)
            {
                min = 20;
                max = 40;
            }
            else if (numTypeTrain == 2)
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
        public void Sets(out int min, out int max)
        {
            min = 1;
            max = 10;
        }
    }
    public class Back : Base, IPainKiller
    {
        public String[] Exercises()
        {
            names = new String[7];
            names[0] = "Станова тяга";
            names[1] = "Тяга зверху перед собою";
            names[2] = "Тяга за голову";
            names[3] = "Тяга до поясу";
            names[4] = "Пуловер";
            names[5] = "Good morning";
            names[6] = "Гіперекстензія";
            return names;
        }
        public void Reps(out int min, out int max)
        {
            if (numTypeTrain == 1)
            {
                min = 20;
                max = 33;
            }
            else if (numTypeTrain == 2)
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
        public void Sets(out int min, out int max)
        {
            min = 1;
            max = 10;
        }
    }
    public class Chest : Base, IPainKiller
    {
        public String[] Exercises()
        {
            names = new String[5];
            names[0] = "Жим (широким хватом)";
            names[1] = "Віджимання";
            names[2] = "Паралельний жим";
            names[3] = "Пуловер";
            names[4] = "Зведення рук";
            return names;
        }
        public void Reps(out int min, out int max)
        {
            if (numTypeTrain == 1)
            {
                min = 20;
                max = 35;
            }
            else if (numTypeTrain == 2)
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
        public void Sets(out int min, out int max)
        {
            min = 1;
            max = 8;
        }
    }
    public class Arms : Base, IPainKiller
    {
        public String[] Exercises()
        {
            names = new String[15];
            names[0] = "Молотки";
            names[1] = "Згинання рук з супінацією";
            names[2] = "Згинання рук широким прямим хватом";
            names[3] = "Згинання рук середнім прямим хватом";
            names[4] = "Згинання рук вузьким прямим хватом";
            names[5] = "Згинання рук середнім оберненим хватом";
            names[6] = "Згинання рук вузьким оберненим хватом";
            names[7] = "Згинання Зотмана";
            names[8] = "Концентровані згинання на біцепс з супінацією";
            names[9] = "Концентровані згинання на біцепс в стилі молот";
            names[10] = "Жим вузьким хватом";
            names[11] = "Віджимання";
            names[12] = "Французький жим";
            names[13] = "Розгинання рук перед собою";
            names[14] = "Розгинання рук за головою";
            return names;
        }
        public void Reps(out int min, out int max)
        {
            if (numTypeTrain == 1)
            {
                min = 20;
                max = 35;
            }
            else if (numTypeTrain == 2)
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
        public void Sets(out int min, out int max)
        {
            min = 1;
            max = 8;
        }
    }
    public class Shoulders : Base, IPainKiller
    {
        public String[] Exercises()
        {
            names = new String[7];
            names[0] = "Жим перед собою";
            names[1] = "Жим за головою";
            names[2] = "Тяга на середню дельту";
            names[3] = "Тяга на задню дельту";
            names[4] = "Розведення";
            names[5] = "Піднімання снаряду перед собою";
            names[6] = "Метелик";
            return names;
        }
        public void Reps(out int min, out int max)
        {
            if (numTypeTrain == 1)
            {
                min = 20;
                max = 35;
            }
            else if (numTypeTrain == 2)
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
        public void Sets(out int min, out int max)
        {
            min = 1;
            max = 8;
        }
    }

}
