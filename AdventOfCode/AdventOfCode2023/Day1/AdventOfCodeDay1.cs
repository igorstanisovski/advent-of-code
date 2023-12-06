using AdventOfCode.Infrastructure;
using AdventOfCode.Infrastructure.Abstract;
using AdventOfCode.WebAPI;

namespace AdventOfCode.AdventOfCode2023
{
    public class AdventOfCodeDay1 : IAdventOfCodeSolution
    {
        private readonly APIDataProvider _apiDataProvider;
        public AdventOfCodeDay1(APIDataProvider apiDataProvider)
        {
            _apiDataProvider = apiDataProvider;
        }
        public async Task<string> Part1Solution()
        {
            var input = await _apiDataProvider.GetDayInput(2023, 1);
            var inputLines = DataConverter.ConvertStringToStringArray(input, "\n");
            long sum = 0L;
            foreach (var line in inputLines)
            {
                string allNumbers = new String(line.Where(Char.IsDigit).ToArray());
                if (allNumbers.Length == 0)
                {
                    continue;
                } 
                try
                {
                    long number = long.Parse(string.Format("{0}{1}", allNumbers[0], allNumbers[allNumbers.Length - 1]));
                    sum += number;
                } catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return sum.ToString();
        }

        public async Task<string> Part2Solution()
        {
            var input = await _apiDataProvider.GetDayInput(2023, 1);
            var inputLines = DataConverter.ConvertStringToStringArray(input, "\n");
            var values = new List<string>() { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var dict = new Dictionary<string, int>();
            for (var k = 0; k < values.Count; k++)
            {
                dict.Add(values[k], k + 1);
            }
            long sum = 0;
            foreach (var line in inputLines)
            {
                
                var reshapedLine = ReshapeLine(line, values, dict);
                string allNumbers = new String(reshapedLine.Where(Char.IsDigit).ToArray());
                if (allNumbers.Length == 0)
                {
                    continue;
                }
                try
                {
                    long number = long.Parse(string.Format("{0}{1}", allNumbers[0], allNumbers[allNumbers.Length - 1]));
                    sum += number;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return sum.ToString();
        }

        private string ReshapeLine(string line, List<string> values, Dictionary<string, int> dict)
        {
            var tmp = line;
            var leftResult = string.Empty;
            var rightResult = string.Empty;
            string substring = string.Empty;

            // loop from the start
            for (int i = 0; i < tmp.Length; i++)
            {
                if (Char.IsDigit(tmp[i]))
                {
                    leftResult = tmp[i].ToString();
                    break;
                }
                substring += tmp[i];
                if (dict.ContainsKey(substring))
                {
                    leftResult = dict[substring].ToString();
                    break;
                } else
                {
                    var possibleMatch = false;
                    foreach (var val in values)
                    {
                        if (val.StartsWith(substring))
                        {
                            possibleMatch = true;
                        }
                    }
                    if (!possibleMatch)
                    {
                        i = i - substring.Length + 1;
                        substring = string.Empty;
                    }
                }
            }

            // loop from the end
            substring = string.Empty;

            for(int i = tmp.Length - 1; i > 0; i--)
            {
                if (Char.IsDigit(tmp[i]))
                {
                    rightResult = tmp[i].ToString();
                    break;
                }
                substring = tmp[i] + substring;
                if (dict.ContainsKey(substring))
                {
                    rightResult = dict[substring].ToString();
                    break;
                }
                else
                {
                    var possibleMatch = false;
                    foreach (var val in values)
                    {
                        if (val.EndsWith(substring))
                        {
                            possibleMatch = true;
                        }
                    }
                    if (!possibleMatch)
                    {
                        i = i + substring.Length - 1;
                        substring = string.Empty;
                    }
                }
            }

            return $"{leftResult}{rightResult}";
        }

    }
}
