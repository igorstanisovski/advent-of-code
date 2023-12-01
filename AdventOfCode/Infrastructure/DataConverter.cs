using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Infrastructure
{
    public class DataConverter
    {
        public DataConverter() { }

        public static string[] ConvertStringToStringArray(string input, string character)
        {
            return input.Split(character).ToArray();
        }
    }
}
