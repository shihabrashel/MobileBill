using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBillCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter Start Time. Sample Format (2019-08-31 08:59:13 am) : ");
                var inputStartTime = Console.ReadLine();               
                try
                {
                    DateTime.Parse(inputStartTime);
                }
                catch
                {
                    Console.WriteLine("Invalid start time");
                    Console.ReadLine();
                    return;
                }
                Console.Write("Enter End Time. Sample Format (2019-08-31 08:59:13 am) : ");
                var inputEndTime = Console.ReadLine();
                try
                {
                    DateTime.Parse(inputEndTime);
                }
                catch
                {
                    Console.WriteLine("Invalid end time");
                    Console.ReadLine();
                    return;
                }
                var startTime = DateTime.Parse(inputStartTime);
                var endTime = DateTime.Parse(inputEndTime);
                if (startTime > endTime)
                {
                    Console.WriteLine("Start time > end time. Calculation can't be done");
                    Console.ReadLine();
                    return;
                }
                var totalPaisa = 0.0;
                while (startTime <= endTime)
                {
                    var paisa = GetPulseRateInPaisa(startTime.AddSeconds(21));
                    totalPaisa += paisa;
                    startTime = startTime.AddSeconds(21);
                }
                Console.WriteLine("Total bill : " + (totalPaisa / 100) + " Taka");
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Opps! Something went wrong. Please try again");
                Console.ReadLine();
            }
        }
        private static bool IsPeakHour(DateTime time)
        {
            return time.Hour >= 9 && time.Hour < 23 ? true : false;
        }
        private static double GetPulseRateInPaisa(DateTime time)
        {
            return IsPeakHour(time) ? 30.00 : 20.00;
        }
    }
}
