using AdventOfCode.Infrastructure;
using AdventOfCode.Infrastructure.Abstract;
using AdventOfCode.WebAPI;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AdventOfCode.AdventOfCode2023.Day4
{
    public class AdventOfCodeDay4 : IAdventOfCodeSolution
    {
        private readonly APIDataProvider _apiDataProvider;
        public AdventOfCodeDay4(APIDataProvider apiDataProvider)
        {
            _apiDataProvider = apiDataProvider;
        }
        public async Task<string> Part1Solution()
        {
            var input = await _apiDataProvider.GetDayInput(2023, 4);
            var inputLines = DataConverter.ConvertStringToStringArray(input, "\n");
            var sum = 0;
            foreach (var line in inputLines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }
                var winners = line.Split(':')[1].Split('|')[0].Split(' ').Where(p => !string.IsNullOrEmpty(p)).ToArray();
                var myNumbers = line.Split(':')[1].Split('|')[1].Split(' ').Where(p => !string.IsNullOrEmpty(p)).ToArray();
                var intersection = winners.Intersect(myNumbers);
                int innerSum = 0;
                for (int i = 0; i < intersection.Count(); i++)
                {
                    if (i == 0)
                    {
                        innerSum = 1;
                    }
                    else
                    {
                        innerSum *= 2;
                    }
                }
                sum += innerSum;
            }

            return sum.ToString();
        }

        public async Task<string> Part2Solution()
        {
            var input = await _apiDataProvider.GetDayInput(2023, 4);
            var inputLines = DataConverter.ConvertStringToStringArray(input, "\n");
            Dictionary<int, int> numDict = new Dictionary<int, int>();
            for (int p = 0; p < inputLines.Length - 1; p++)
            {
                numDict.Add(p + 1, 1);
            }
            var sum = 0;
            for (int i = 0; i < inputLines.Length - 1; i++)
            {
                var ls = inputLines[i].Split(": ")[1].Split(" | ");
                var winners = ls[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var myNumbers = ls[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < winners.Intersect(myNumbers).Count(); j++)
                {
                    numDict[i + 1 + j + 1] += 1 * numDict[i + 1];
                }
                sum += numDict[i + 1];
            }
            return sum.ToString();
        }
    }
}
