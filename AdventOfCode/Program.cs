#region Setup

using AdventOfCode.AdventOfCode2023;
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