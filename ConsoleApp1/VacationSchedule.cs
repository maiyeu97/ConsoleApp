using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class VacationSchedule
    {
        private List<DayDuration> schedule = new List<DayDuration>();

        public void AddVacation(DayDuration vacation)
        {
            schedule.Add(vacation);
        }

        public bool IsInOfficeAt(int day)
        {
            return schedule.Find(vacation => vacation.IsDayIn(day)) == null;
        }

        public bool IsInVacation(int day)
        {
            return !IsInOfficeAt(day);
        }
    }
}
