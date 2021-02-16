using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painkiller.Models.Training
{
    public class Arms : MuscleGroup
    {

        public override String[] GetExercises()
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
                max = 25;
            }
            else if(typeTraining == TypeTrainingEnum.DevelopmentStrength)
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
