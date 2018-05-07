using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ForecastResult
    {
        private List<DayDuration> safeIntervals;

        private List<DayDuration> unsafeIntervals;

        public ForecastResult(List<DayDuration> safeIntervals, List<DayDuration> unsafeIntervals)
        {
            this.safeIntervals = safeIntervals;
            this.unsafeIntervals = unsafeIntervals;
        }

        public override string ToString()
        {
            return safeIntervals.Count() + "\n" + 
                string.Join("\n", safeIntervals.ConvertAll(dayDuration => dayDuration.ToString())) + "\n" +
                unsafeIntervals.Count() + "\n" +
                string.Join("\n", safeIntervals.ConvertAll(dayDuration => dayDuration.ToString()))
            ;
        }
    }
}
