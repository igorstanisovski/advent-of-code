using AdventOfCode.Infrastructure;
using AdventOfCode.Infrastructure.Abstract;
using AdventOfCode.WebAPI;
using System.Collections.Generic;

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
            string substring = string.Empty;
            List<Tuple<int,int>> neighbourhood = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(0,-1), // left middle
                new Tuple<int, int>(0,1), // right middle
                new Tuple<int, int>(-1,-1), // left up diagonally
                new Tuple<int, int>(-1,0), // up
                new Tuple<int, int>(-1, 1), // right up diagonally
                new Tuple<int, int>(1,0), //down
                new Tuple<int, int>(1, 1), // right down diagonally
                new Tuple<int, int>(1,-1), // left down diagonally
            };
            long sum = 0;
            List<Tuple<int,int>> indexes = new List<Tuple<int,int>>();
            for(int i = 0; i < inputLines.Length;i++)
            {
                var line = inputLines[i];
                for (int j = 0; j < line.Length; j++)
                {
                    if (Char.IsDigit(line[j]))
                    {
                        substring += line[j];
                        indexes.Add(new Tuple<int, int>(i, j));
                    }
                    if(j == line.Length - 1 || !Char.IsDigit(line[j]))
                    {
                        bool shouldBreakLoop = false;
                        for (int k = 0; k < indexes.Count; k++)
                        {
                            if (shouldBreakLoop)
                            {
                                break;
                            }
                            for (int p = 0; p < neighbourhood.Count; p++)
                            {
                                // check for boundaries
                                var indexI = indexes[k].Item1 + neighbourhood[p].Item1;
                                var indexJ = indexes[k].Item2 + neighbourhood[p].Item2;

                                if (indexI >= inputLines.Length - 1 || indexI < 0 || indexJ >= line.Length || indexJ < 0)
                                {
                                    // out of boundaries
                                    continue;
                                }
                                if (!Char.IsDigit(inputLines[indexI][indexJ]) && inputLines[indexI][indexJ] != '.')
                                {
                                    // symbol found
                                    sum += long.Parse(substring);
                                    shouldBreakLoop = true;
                                }
                            }
                        }
                        indexes.Clear();
                        substring = string.Empty;
                    }
                }
            }
            return sum.ToString();
        }

        public async Task<string> Part2Solution()
        {
            var input = await _apiDataProvider.GetDayInput(2023, 3);
            var inputLines = DataConverter.ConvertStringToStringArray(input, "\n");
            string substring = string.Empty;
            List<Tuple<int, int>> neighbourhood = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(0,-1), // left middle
                new Tuple<int, int>(0,1), // right middle
                new Tuple<int, int>(-1,-1), // left up diagonally
                new Tuple<int, int>(-1,0), // up
                new Tuple<int, int>(-1, 1), // right up diagonally
                new Tuple<int, int>(1,0), //down
                new Tuple<int, int>(1, 1), // right down diagonally
                new Tuple<int, int>(1,-1), // left down diagonally
            };
            long sum = 0;
            List<Tuple<int, int>> indexes = new List<Tuple<int, int>>();
            List<Tuple<string,long>> asteriskPositionValue = new List<Tuple<string,long>>();
            for (int i = 0; i < inputLines.Length; i++)
            {
                var line = inputLines[i];
                for (int j = 0; j < line.Length; j++)
                {
                    if (Char.IsDigit(line[j]))
                    {
                        substring += line[j];
                        indexes.Add(new Tuple<int, int>(i, j));
                    }
                    if(j == line.Length - 1 || !Char.IsDigit(line[j]))
                    {
                        bool shouldBreakLoop = false;
                        for (int k = 0; k < indexes.Count; k++)
                        {
                            if (shouldBreakLoop)
                            {
                                break;
                            }
                            for (int p = 0; p < neighbourhood.Count; p++)
                            {
                                // check for boundaries
                                var indexI = indexes[k].Item1 + neighbourhood[p].Item1;
                                var indexJ = indexes[k].Item2 + neighbourhood[p].Item2;

                                if (indexI >= inputLines.Length - 1 || indexI < 0 || indexJ >= line.Length || indexJ < 0)
                                {
                                    // out of boundaries
                                    continue;
                                }
                                if (inputLines[indexI][indexJ] == '*')
                                {
                                    // symbol found
                                    asteriskPositionValue.Add(new Tuple<string, long>($"{indexI} {indexJ}", long.Parse(substring)));
                                    shouldBreakLoop = true;
                                }
                            }
                        }
                        indexes.Clear();
                        substring = string.Empty;
                    }
                }
            }
            var groups = asteriskPositionValue.GroupBy(v => v.Item1);
            foreach (var group in groups)
            {
                if(group.Count() == 2)
                {
                    sum += (group.ElementAt(0).Item2 * group.ElementAt(1).Item2);
                }
            }
            return sum.ToString();
        }
    }
}
