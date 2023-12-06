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

namespace AdventOfCode.AdventOfCode2023.Day6
{
    public class AdventOfCodeDay6 : IAdventOfCodeSolution
    {
        private readonly APIDataProvider _apiDataProvider;
        public AdventOfCodeDay6(APIDataProvider apiDataProvider)
        {
            _apiDataProvider = apiDataProvider;
        }
        public async Task<string> Part1Solution()
        {
            var input = await _apiDataProvider.GetDayInput(2023, 6);
            var inputLines = DataConverter.ConvertStringToStringArray(input, "\n");
            var t = inputLines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Where(x => char.IsDigit(x[0])).Select(x => int.Parse(x)).ToList();
            var d = inputLines[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Where(x => char.IsDigit(x[0])).Select(x => int.Parse(x)).ToList();
            int m = 1;
            for (int i = 0; i < t.Count(); i++)
            {
                var ways = 0;
                var maxMilliseconds = t[i];
                var neededDistance = d[i];
                for (int j = 1; j < maxMilliseconds - 1; j++)
                {
                    int leftMs = maxMilliseconds - j;
                    var distanceMoved = leftMs * j;
                    if (distanceMoved > neededDistance)
                    {
                        ways++;
                    }
                }
                if (ways != 0)
                {
                    m *= ways;
                }
            }

            return m.ToString();
        }

        public async Task<string> Part2Solution()
        {
            var input = await _apiDataProvider.GetDayInput(2023, 6);
            var inputLines = DataConverter.ConvertStringToStringArray(input, "\n");
            var t = long.Parse(string.Join("", inputLines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Where(x => char.IsDigit(x[0])).ToList()));
            var d = long.Parse(string.Join("", inputLines[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Where(x => char.IsDigit(x[0])).ToList()));
            var wins = 0;
            for (long j = 1; j < t - 1; j++)
            {
                long leftMs = t - j;
                var distanceMoved = leftMs * j;
                if (distanceMoved > d)
                {
                    wins++;
                }
            }
            return wins.ToString();
        }
    }
}
