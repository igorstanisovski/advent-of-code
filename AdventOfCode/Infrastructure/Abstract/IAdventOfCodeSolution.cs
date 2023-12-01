using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Infrastructure.Abstract
{
    public interface IAdventOfCodeSolution
    {
        Task<string> Part1Solution();
        Task<string> Part2Solution();
    }
}
