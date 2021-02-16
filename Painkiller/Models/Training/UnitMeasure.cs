using Painkiller.PresentationModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painkiller.Models.Training
{
    public enum UnitMeasureEnum
    {
        InvalidType,
        Kg,
        Lb
    }

    class UnitMeasure
    {
        public const String KG = "Кг";
        public const String LB = "lb";

        public const Double CONVERT_TO_KG_FROM_LB = 0.454;
        public const Double CONVERT_TO_LB_FROM_KG = 2.2046;

        private UnitMeasureEnum unitMeasure;
        private Notification notification;

        public UnitMeasure(UnitMeasureEnum unitMeasure, Notification notification)
        {
            this.unitMeasure = unitMeasure;
            this.notification = notification;
        }

        public void CalculateNewMeasure(DataTable dataTable, String nameOfColumnForCalculate)
        {
            Double multiplier = DefineMultiplier();
            if (multiplier == 0)
            {
                return;
            }

            for (Int32 i = 0; i < dataTable.Rows.Count; i++)
            {
                dataTable.Rows[i][nameOfColumnForCalculate] = Math.Round((Int32)dataTable.Rows[i][nameOfColumnForCalculate] * multiplier);
            }
        }

        private Double DefineMultiplier()
        {
            if (unitMeasure == UnitMeasureEnum.Kg)
            {
                return CONVERT_TO_KG_FROM_LB;
            }
            else if (unitMeasure == UnitMeasureEnum.Lb)
            {
                return CONVERT_TO_LB_FROM_KG;
            }
            else
            {
                notification.MessageInvoke(false, "This unit measure doesn't exist");
                return default;
            }
        }

        public static UnitMeasureEnum GetUnitMeasureEnum(String str)
        {
            switch(str)
            {
                case KG:
                    {
                        return UnitMeasureEnum.Kg;
                    }

                case LB:
                    {
                        return UnitMeasureEnum.Lb;
                    }

                default:
                    {
                        return UnitMeasureEnum.InvalidType;
                    }
            }
        }

        public static void Calculate(List<Int32> list, Func<Int32, Double, Int32> func, UnitMeasureEnum unitMeasure)
        {
            Double multiplier;
            if (unitMeasure == UnitMeasureEnum.Kg)
            {
                multiplier = CONVERT_TO_KG_FROM_LB;
            }
            else if(unitMeasure == UnitMeasureEnum.Lb)
            {
                multiplier = CONVERT_TO_LB_FROM_KG;
            }
            else
            {
                return;
            }

            for (Int32 i = 0; i < list.Count; i++)
            {
                list[i] = func(list[i], multiplier);
            }
        }
    }
}
