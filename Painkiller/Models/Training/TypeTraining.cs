using Painkiller.PresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painkiller.Models.Training
{
    public enum TypeTrainingEnum
    {
        InvalidType,
        Statodynamics,
        Hypertrophy,
        DevelopmentStrength
    }

    public class TypeTraining
    { 
        public const String STATODYNAMICS = "Статодинаміка";
        public const String HYPERTROPHY = "Гіпертрофія";
        public const String DEVELOPMENT_STRENGTH = "Розвиток сили";

        public static TypeTrainingEnum GetTypeTrainingEnum(String typeTraining)
        {
            switch(typeTraining)
            {
                case STATODYNAMICS:
                    {
                        return TypeTrainingEnum.Statodynamics;
                    }
                case HYPERTROPHY:
                    {
                        return TypeTrainingEnum.Hypertrophy;
                    }
                case DEVELOPMENT_STRENGTH:
                    {
                        return TypeTrainingEnum.DevelopmentStrength;
                    }
                default:
                    {
                        return TypeTrainingEnum.InvalidType;
                    }
            }
        }
    }
}
