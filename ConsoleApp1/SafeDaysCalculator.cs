using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class SafeDaysCalculator
    {
        public static ForecastResult Calculate(VacationSchedule admin1Vacations, VacationSchedule admin2Vacations, int daysOfForecast)
        {
            List<DayDuration> safeInterval = new List<DayDuration>();
            List<DayDuration> unsafeInterval = new List<DayDuration>();

            int currentSafeLevel = GetSafetyLevelOfDay(admin1Vacations, admin2Vacations, 1);
            DayDuration checkingInterval = new DayDuration(1, 1);

            if (currentSafeLevel == 0)
            {
                unsafeInterval.Add(checkingInterval);
            }
            else if(currentSafeLevel == 2)
            {
                safeInterval.Add(checkingInterval);
            }

            for (int checkingDay = 2; checkingDay <= daysOfForecast; checkingDay++)
            {
                int todaySafeLevel = GetSafetyLevelOfDay(admin1Vacations, admin2Vacations, checkingDay);

                if (todaySafeLevel == currentSafeLevel)
                {
                    checkingInterval.EndDay = checkingDay;
                }
                else
                {
                    checkingInterval = new DayDuration(checkingDay, checkingDay);

                    if (todaySafeLevel == 0)
                    {
                        unsafeInterval.Add(checkingInterval);
                    }
                    else if (todaySafeLevel == 2)
                    {
                        safeInterval.Add(checkingInterval);
                    }
                }

                currentSafeLevel = todaySafeLevel;
            }


            return new ForecastResult(safeInterval, unsafeInterval);
        }
        
        public static int GetSafetyLevelOfDay(VacationSchedule admin1Vacations, VacationSchedule admin2Vacations, int checkingDay)
        {
            int level = 0;

            if (admin1Vacations.IsInOfficeAt(checkingDay))
            {
                level++;
            }

            if (admin2Vacations.IsInOfficeAt(checkingDay))
            {
                level++;
            }

            return level;
        }
    }
}
