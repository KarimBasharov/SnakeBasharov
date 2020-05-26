using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeBasharov
{
   public class Time
    {
        public void PlayTime()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            TimeSpan ts = stopwatch.Elapsed;
            Console.WriteLine($"{ts.Minutes:00}:{ts.Seconds:00}");
        }
    }
}
