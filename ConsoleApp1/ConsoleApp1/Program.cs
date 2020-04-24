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
            var time = TimeSpan.FromSeconds(3662);

            var test = $"{(int)time.TotalHours} Hour, {time.Minutes} minute, {time.Seconds} seconds";
        }
    }
}
