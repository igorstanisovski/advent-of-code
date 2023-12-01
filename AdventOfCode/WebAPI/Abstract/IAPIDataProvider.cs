using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.WebAPI.Abstract
{
    internal interface IAPIDataProvider
    {
        Task<string> GetDayInput(int year, int day);
    }
}
