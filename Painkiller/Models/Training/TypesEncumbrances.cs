using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painkiller.Models.Training
{
    public enum TypeEncumbranceEnum
    {
        InvalidType,
        Dumbbell,
        Bar,
        Bloc,
        Machine,
        BodyWeight
    }

    public static class TypeEncumbrance
    {
        public const String DUMBBELL = "Гантелі";
        public const String BAR = "Штанга";
        public const String BLOC = "Блок";
        public const String MACHINE = "Тренажер";
        public const String BODY_WEIGHT = "Власна вага тіла(+додаткова вага)";

        public static TypeEncumbranceEnum GetTypeEncumbranceEnum(String str)
        {
            switch(str)
            {
                case DUMBBELL:
                    {
                        return TypeEncumbranceEnum.Dumbbell;
                    }
                case BAR:
                    {
                        return TypeEncumbranceEnum.Bar;
                    }
                case BLOC:
                    {
                        return TypeEncumbranceEnum.Bloc;
                    }
                case MACHINE:
                    {
                        return TypeEncumbranceEnum.Machine;
                    }
                case BODY_WEIGHT:
                    {
                        return TypeEncumbranceEnum.BodyWeight;
                    }
                default:
                    {
                        return TypeEncumbranceEnum.InvalidType;
                    }
            }
        }
    }
}
