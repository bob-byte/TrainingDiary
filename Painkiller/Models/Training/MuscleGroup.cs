using Painkiller.Models.Training;
using Painkiller.PresentationModels;
using System;

namespace Painkiller.Models.Training
{
    //In case, if every muscle group have the same interval of reps or sets
    //public interface IMuscleGroup
    //{
    //    public TypeTrainingEnum TypeTraining { get; set; }
    //}

    public abstract class MuscleGroup
    {
        public const String ARMS = "Руки";
        public const String BACK = "Спина";
        public const String CHEST = "Груди";
        public const String LEGS = "Ноги";
        public const String SHOULDERS = "Плечі";

        public static MuscleGroup GetMuscleGroup(String muscleGroup)
        {
            switch (muscleGroup)
            {
                case MuscleGroup.ARMS:
                    return new Arms();

                case MuscleGroup.BACK:
                    return new Back();

                case MuscleGroup.CHEST:
                    return new Chest();

                case MuscleGroup.LEGS:
                    return new Legs();

                case MuscleGroup.SHOULDERS:
                    return new Shoulders();

                default:
                    {
                        //notification.MessageInvoke(false, "Такої групи м'язів не існує в програмі");
                        throw new Exception("Такої групи м'язів не існує в програмі");
                    }
            }
        }

        public static MuscleGroupEnum GetMuscleGroupEnum(String muscleGroup)
        {
            switch (muscleGroup)
            {
                case ARMS:
                    return MuscleGroupEnum.Arms;

                case BACK:
                    return MuscleGroupEnum.Back;

                case CHEST:
                    return MuscleGroupEnum.Chest;

                case LEGS:
                    return MuscleGroupEnum.Legs;

                case SHOULDERS:
                    return MuscleGroupEnum.Shoulders;

                default:
                    {
                        //Notification errorNotification = new Notification();
                        //errorNotification.MessageInvoke(false, "Такої групи м'язів не існує в програмі");

                        return MuscleGroupEnum.InvalidType;
                    }
            }
        }
        protected virtual String[] NameExercises { get; set; }
        public abstract String[] GetExercises();
        public abstract void Reps(TypeTrainingEnum typeTraining, out Int32 min, out Int32 max);
        public abstract void Sets(out Int32 min, out Int32 max);
    }

    public enum MuscleGroupEnum
    {
        InvalidType = 0,
        First,
        Arms = 1,
        Back,
        Chest,
        Legs,
        Shoulders,
        Last = 5
    }
}