using AdventOfCode.Infrastructure;
using AdventOfCode.Infrastructure.Abstract;
using AdventOfCode.WebAPI;

namespace AdventOfCode.AdventOfCode2023
{
    public class AdventOfCodeDay3 : IAdventOfCodeSolution
    {
        private readonly APIDataProvider _apiDataProvider;
        public AdventOfCodeDay3(APIDataProvider apiDataProvider)
        {
            _apiDataProvider = apiDataProvider;
        }
        public async Task<string> Part1Solution()
        {
            var input = await _apiDataProvider.GetDayInput(2023, 3);
            var inputLines = DataConverter.ConvertStringToStringArray(input, "\n");
            return string.Empty;
        }

        public async Task<string> Part2Solution()
        {
            var input = await _apiDataProvider.GetDayInput(2023, 3);
            var inputLines = DataConverter.ConvertStringToStringArray(input, "\n");
            return string.Empty;
        }
    }
}
