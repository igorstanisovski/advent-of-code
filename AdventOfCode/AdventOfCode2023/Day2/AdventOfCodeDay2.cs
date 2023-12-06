using AdventOfCode.Infrastructure;
using AdventOfCode.Infrastructure.Abstract;
using AdventOfCode.WebAPI;

namespace AdventOfCode.AdventOfCode2023
{
    public class AdventOfCodeDay2 : IAdventOfCodeSolution
    {
        private readonly APIDataProvider _apiDataProvider;
        public AdventOfCodeDay2(APIDataProvider apiDataProvider)
        {
            _apiDataProvider = apiDataProvider;
        }
        public async Task<string> Part1Solution()
        {
            var input = await _apiDataProvider.GetDayInput(2023, 2);
            var inputLines = DataConverter.ConvertStringToStringArray(input, "\n");
            int sum = 0;
            foreach(var line in inputLines)
            {
                if(string.IsNullOrEmpty(line))
                {
                    continue;
                }
                sum += GetValidGameId(line);
            }
            return sum.ToString();
        }

        public async Task<string> Part2Solution()
        {
            var input = await _apiDataProvider.GetDayInput(2023, 2);
            var inputLines = DataConverter.ConvertStringToStringArray(input, "\n");
            int sum = 0;
            foreach (var line in inputLines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }
                sum += GetPowerOfSet(line);
            }
            return sum.ToString();
        }

        private int GetValidGameId(string line)
        {
            var gameSplit = line.Split(':').ToArray();
            var gameId = new String(gameSplit[0].Where(Char.IsDigit).ToArray());
            var balls = gameSplit[1]
                .Split(';')
                .Select(x => x.Split(','))
                .ToArray();
            foreach(var item1 in balls)
            {
                foreach(var item2 in item1)
                {
                    //find if blue/red/green
                    if(item2.Contains("red"))
                    {
                        int red = int.Parse(new String(item2.Where(Char.IsDigit).ToArray()));
                        if (red > 12)
                        {
                            return 0;
                        }
                    }
                    if (item2.Contains("green"))
                    {
                        int green = int.Parse(new String(item2.Where(Char.IsDigit).ToArray()));
                        if (green > 13)
                        {
                            return 0;
                        }
                    }
                    if (item2.Contains("blue"))
                    {
                        int blue = int.Parse(new String(item2.Where(Char.IsDigit).ToArray()));
                        if (blue > 14)
                        {
                            return 0;
                        }
                    }
                }
            }

            return int.Parse(gameId);
        }

        private int GetPowerOfSet(string line)
        {
            var balls = line
                .Split(':')
                .ToArray()[1]
                .Split(';')
                .Select(x => x.Split(','))
                .ToArray();
            int maxBlue = 0, maxRed = 0, maxGreen = 0;
            foreach (var item1 in balls)
            {
                foreach (var item2 in item1)
                {
                    //find if blue/red/green
                    if (item2.Contains("red"))
                    {
                        int red = int.Parse(new String(item2.Where(Char.IsDigit).ToArray()));
                        maxRed = red > maxRed ? red : maxRed;
                    }
                    if (item2.Contains("green"))
                    {
                        int green = int.Parse(new String(item2.Where(Char.IsDigit).ToArray()));
                        maxGreen = green > maxGreen ? green : maxGreen;
                    }
                    if (item2.Contains("blue"))
                    {
                        int blue = int.Parse(new String(item2.Where(Char.IsDigit).ToArray()));
                        maxBlue = blue > maxBlue ? blue : maxBlue;
                    }
                }
            }
            return maxRed * maxBlue * maxGreen;
        }
    }
}
