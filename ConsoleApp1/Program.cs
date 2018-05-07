using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            VacationSchedule aliceSchedule = new VacationSchedule();
            VacationSchedule bobSchedule = new VacationSchedule();

            int readingPointer = 0;

            string[] input = System.IO.File.ReadAllLines(@"in.txt");

            int daysOfForecast = Int32.Parse(input[0]);
            int numberOfAliceVacation = Int32.Parse(input[1]);

            for(int aliceVacationIndex = 2; aliceVacationIndex < numberOfAliceVacation + 2; aliceVacationIndex++)
            {
                DayDuration currentAliceVacation = new DayDuration();
                string[] vacationInput = input[aliceVacationIndex].Split(';');
                aliceSchedule.AddVacation(new DayDuration(Int32.Parse(vacationInput[0]), Int32.Parse(vacationInput[1])));
                readingPointer = aliceVacationIndex;
            }

            int numberOfBobVacation = Int32.Parse(input[readingPointer]);

            for (int bobVacationIndex = readingPointer + 1; bobVacationIndex < readingPointer + numberOfBobVacation + 1; bobVacationIndex++)
            {
                DayDuration currentAliceVacation = new DayDuration();
                string[] vacationInput = input[bobVacationIndex].Split(';');
                bobSchedule.AddVacation(new DayDuration(Int32.Parse(vacationInput[0]), Int32.Parse(vacationInput[1])));
            }
            
            ForecastResult forecastResult = SafeDaysCalculator.Calculate(aliceSchedule, bobSchedule, numberOfBobVacation);

            System.IO.File.WriteAllText(@"out.txt", forecastResult.ToString());
            Console.ReadLine();
        }
    }
}
