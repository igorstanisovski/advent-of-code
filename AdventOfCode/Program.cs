#region Setup

using AdventOfCode.AdventOfCode2022;
using AdventOfCode.AdventOfCode2023;
using AdventOfCode.AdventOfCode2023.Day3;
using AdventOfCode.AdventOfCode2023.Day4;
using AdventOfCode.AdventOfCode2023.Day5;
using AdventOfCode.AdventOfCode2023.Day6;
using AdventOfCode.AdventOfCode2023.Day7;
using AdventOfCode.conf;
using AdventOfCode.WebAPI;
using Microsoft.Extensions.Configuration;

string? projectDirectory = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName;

IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile($"{projectDirectory}/conf/appsettings.json")
    .AddEnvironmentVariables()
    .Build();

Settings? settings = config.GetRequiredSection("Settings").Get<Settings>();

APIDataProvider apiDataProvider = new(settings?.Token);
#endregion

#region Advent Of Code 2022

#region Advent Of Code Day 11
//AdventOfCode2022Day12 adventOfCode2022Day12 = new(apiDataProvider);
//Console.WriteLine("Advent Of Code 2022 Day 12 - Part 1 Solution");
//Console.WriteLine(await adventOfCode2022Day12.Part1Solution());
//Console.WriteLine("Advent Of Code 2023 Day 12 - Part 2 Solution");
//Console.WriteLine(await adventOfCode2022Day12.Part2Solution());
#endregion

#endregion

//#region Advent Of Code 2023

#region AdventOfCodeDay 2023 - Day 1
AdventOfCodeDay1 adventOfCodeDay1 = new(apiDataProvider);
Console.WriteLine("Advent Of Code 2023 Day 1 - Part 1 Solution");
Console.WriteLine(await adventOfCodeDay1.Part1Solution());
Console.WriteLine("Advent Of Code 2023 Day 1 - Part 2 Solution");
Console.WriteLine(await adventOfCodeDay1.Part2Solution());
#endregion

#region AdventOfCodeDay 2023 - Day 2
AdventOfCodeDay2 adventOfCodeDay2 = new(apiDataProvider);
Console.WriteLine("Advent Of Code 2023 Day 2 - Part 1 Solution");
Console.WriteLine(await adventOfCodeDay2.Part1Solution());
Console.WriteLine("Advent Of Code 2023 Day 2 - Part 2 Solution");
Console.WriteLine(await adventOfCodeDay2.Part2Solution());
#endregion

#region AdventOfCodeDay 2023 - Day 3
AdventOfCodeDay3 adventOfCodeDay3 = new(apiDataProvider);
Console.WriteLine("Advent Of Code 2023 Day 3 - Part 1 Solution");
Console.WriteLine(await adventOfCodeDay3.Part1Solution());
Console.WriteLine("Advent Of Code 2023 Day 3 - Part 2 Solution");
Console.WriteLine(await adventOfCodeDay3.Part2Solution());
#endregion

#region AdventOfCodeDay 2023 - Day 4
AdventOfCodeDay4 adventOfCodeDay4 = new(apiDataProvider);
Console.WriteLine("Advent Of Code 2023 Day 4 - Part 1 Solution");
Console.WriteLine(await adventOfCodeDay4.Part1Solution());
Console.WriteLine("Advent Of Code 2023 Day 4 - Part 2 Solution");
Console.WriteLine(await adventOfCodeDay4.Part2Solution());
#endregion

#region AdventOfCodeDay 2023 - Day 5
AdventOfCodeDay5 adventOfCodeDay5 = new(apiDataProvider);
Console.WriteLine("Advent Of Code 2023 Day 5 - Part 1 Solution");
Console.WriteLine(await adventOfCodeDay5.Part1Solution());
Console.WriteLine("Advent Of Code 2023 Day 5 - Part 2 Solution");
Console.WriteLine(await adventOfCodeDay5.Part2Solution());
#endregion

#region AdventOfCodeDay 2023 - Day 6
AdventOfCodeDay6 adventOfCodeDay6 = new(apiDataProvider);
Console.WriteLine("Advent Of Code 2023 Day 6 - Part 1 Solution");
Console.WriteLine(await adventOfCodeDay6.Part1Solution());
Console.WriteLine("Advent Of Code 2023 Day 6 - Part 2 Solution");
Console.WriteLine(await adventOfCodeDay6.Part2Solution());
#endregion

#region AdventOfCodeDay 2023 - Day 7
AdventOfCodeDay7 adventOfCodeDay7 = new(apiDataProvider);
Console.WriteLine("Advent Of Code 2023 Day 7 - Part 1 Solution");
Console.WriteLine(await adventOfCodeDay7.Part1Solution());
Console.WriteLine("Advent Of Code 2023 Day 7 - Part 2 Solution");
Console.WriteLine(await adventOfCodeDay7.Part2Solution());
#endregion

//#endregion