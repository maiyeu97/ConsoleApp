using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DayDuration
    {
        public int StartDay
        {
            get;
            set;
        }

        public int EndDay
        {
            get;
            set;
        }

        public DayDuration(int StartDay = 0, int EndDay = 0)
        {
            this.StartDay = StartDay;
            this.EndDay = EndDay;
        }

        public bool IsDayIn(int day)
        {
            return day >= StartDay && day <= EndDay;
        }

        public override string ToString()
        {
            return StartDay.ToString() + ";" + EndDay.ToString();
        }
    }
}
