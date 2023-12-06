using AdventOfCode.Infrastructure;
using AdventOfCode.Infrastructure.Abstract;
using AdventOfCode.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.AdventOfCode2022
{
    public class AdventOfCode2022Day12 : IAdventOfCodeSolution
    {
        private readonly APIDataProvider _apiDataProvider;
        public AdventOfCode2022Day12(APIDataProvider apiDataProvider)
        {
            _apiDataProvider = apiDataProvider;
        }

        public async Task<string[]> ReadInput()
        {
            var input = await _apiDataProvider.GetDayInput(2022, 12);
            var inputLines = DataConverter.ConvertStringToStringArray(input, "\n");
            return inputLines;
        }
        public async Task<string> Part1Solution()
        {
            var inputLines = await ReadInput();
            var queue = new Queue<string>();
            queue.Enqueue($"20 0"); // start vertex S

            return string.Empty;
        }

        public async Task<string> Part2Solution()
        {
            var inputLines = await ReadInput();
            return string.Empty;
        }
    }
}
