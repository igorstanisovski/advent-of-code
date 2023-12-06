using AdventOfCode.Infrastructure;
using AdventOfCode.Infrastructure.Abstract;
using AdventOfCode.WebAPI;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AdventOfCode.AdventOfCode2023.Day5
{
    public class AdventOfCodeDay5 : IAdventOfCodeSolution
    {
        private readonly APIDataProvider _apiDataProvider;
        public AdventOfCodeDay5(APIDataProvider apiDataProvider)
        {
            _apiDataProvider = apiDataProvider;
        }
        public async Task<string> Part1Solution()
        {
            var input = await _apiDataProvider.GetDayInput(2023, 5);
            var inputLines = DataConverter.ConvertStringToStringArray(input, "\n");
            var seeds = inputLines[0].Split(": ")[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var keys = new List<string>() {
                "sts",
                "stf",
                "ftw",
                "wtl",
                "ltt",
                "tth",
                "htl"
            };
            Dictionary<string, List<Node>> dict = new Dictionary<string, List<Node>>();
            int k = 0;
            for (int j = 3; j < inputLines.Length - 1; j++)
            {
                if (string.IsNullOrEmpty(inputLines[j]))
                {
                    continue;
                }
                if (char.IsDigit(inputLines[j][0]))
                {
                    var numbers = inputLines[j].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                    if (dict.ContainsKey(keys[k]))
                    {
                        dict[keys[k]].Add(new Node(numbers[1] + numbers[2], numbers[1], numbers[0] - numbers[1]));
                    }
                    else
                    {
                        var n = new List<Node>
                        {
                            new Node(numbers[1] + numbers[2], numbers[1], numbers[0] - numbers[1])
                        };
                        dict.Add(keys[k], n);
                    }
                }
                else if (!char.IsDigit(inputLines[j][0]))
                {
                    k++;
                }
            }

            List<long> locations = new List<long>();
            long min = long.MaxValue;
            for (int i = 0; i < seeds.Count(); i++)
            {
                var seed = long.Parse(seeds[i]);
                for (int j = 0; j < keys.Count(); j++)
                {
                    var l = dict[keys[j]];
                    for (int p = 0; p < l.Count(); p++)
                    {
                        if (l[p].Start <= seed && seed <= l[p].End)
                        {
                            seed = seed + l[p].Difference;
                            break;
                        }
                    }
                }
                if (seed < min)
                {
                    min = seed;
                }
            }

            return min.ToString();
        }

        public async Task<string> Part2Solution()
        {
            var input = await _apiDataProvider.GetDayInput(2023, 5);
            var inputLines = DataConverter.ConvertStringToStringArray(input, "\n");
            var seeds = inputLines[0].Split(": ")[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var keys = new List<string>() {
                "sts",
                "stf",
                "ftw",
                "wtl",
                "ltt",
                "tth",
                "htl"
            };
            Dictionary<string, List<Node>> dict = new Dictionary<string, List<Node>>();
            int count = 0;
            for (int j = 3; j < inputLines.Length - 1; j++)
            {
                if (string.IsNullOrEmpty(inputLines[j]))
                {
                    continue;
                }
                if (char.IsDigit(inputLines[j][0]))
                {
                    var numbers = inputLines[j].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                    if (dict.ContainsKey(keys[count]))
                    {
                        dict[keys[count]].Add(new Node(numbers[1] + numbers[2], numbers[1], numbers[0] - numbers[1]));
                    }
                    else
                    {
                        var n = new List<Node>
                        {
                            new Node(numbers[1] + numbers[2], numbers[1], numbers[0] - numbers[1])
                        };
                        dict.Add(keys[count], n);
                    }
                }
                else if (!char.IsDigit(inputLines[j][0]))
                {
                    count++;
                }
            }

            List<long> locations = new List<long>();

            var ranges = new List<Tuple<long, long>>();

            for (int i = 0; i < seeds.Length; i += 2)
            {
                ranges.Add(new Tuple<long, long>(long.Parse(seeds[i]), long.Parse(seeds[i]) + long.Parse(seeds[i + 1]) - 1));
            }

            for (int i = 0; i < ranges.Count(); i++)
            {
                var listOfRanges = new List<Tuple<long, long>>();
                listOfRanges.Add(ranges[i]);
                for (int j = 0; j < keys.Count(); j++)
                {
                    var section = dict[keys[j]];
                    var nextSectionList = new List<Tuple<long, long>>();
                    var nextIterationList = new List<Tuple<long, long>>();
                    for (int k = 0; k < section.Count(); k++)
                    {
                        var currentLine = section[k];
                        nextIterationList = new List<Tuple<long, long>>();
                        for (int n = 0; n < listOfRanges.Count(); n++)
                        {
                            var item = listOfRanges[n];
                            if (currentLine.Start <= item.Item1 && currentLine.End >= item.Item1)
                            {
                                // start in intersect, check if end is inside or outside
                                if (currentLine.Start <= item.Item2 && currentLine.End >= item.Item2)
                                {
                                    // end is inside
                                    // fully mapped
                                    var t = new Tuple<long, long>(item.Item1 + currentLine.Difference, item.Item2 + currentLine.Difference);
                                    nextSectionList.Add(t);
                                }
                                else
                                {
                                    // end is outside
                                    // split
                                    var t = new Tuple<long, long>(item.Item1 + currentLine.Difference, currentLine.End + currentLine.Difference);
                                    // add the mapped range
                                    nextSectionList.Add(t);
                                    // remainder
                                    nextIterationList.Add(new Tuple<long, long>(currentLine.End + 1, item.Item2));
                                }
                            }
                            else
                            {
                                if (currentLine.Start < item.Item2 && currentLine.End > item.Item2)
                                {
                                    // start outside, end is inside
                                    var t = new Tuple<long, long>(currentLine.Start + currentLine.Difference, item.Item2 + currentLine.Difference);
                                    nextSectionList.Add(t);
                                    // remainder
                                    nextIterationList.Add(new Tuple<long, long>(item.Item1, currentLine.Start - 1));
                                }
                                else
                                {
                                    nextIterationList.Add(item);
                                }
                            }
                        }
                        listOfRanges = new List<Tuple<long, long>>(nextIterationList);
                    }
                    listOfRanges = new List<Tuple<long, long>>(nextSectionList.Concat(nextIterationList));
                }
                for (int c = 0; c < listOfRanges.Count(); c++)
                {
                    locations.Add(listOfRanges[c].Item1);
                }
            }

            return locations.OrderBy(x => x).ToList()[0].ToString();
        }
    }
}
