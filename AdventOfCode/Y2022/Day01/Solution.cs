using AdventOfCode.Attributes;
using AdventOfCode.Utils;

namespace AdventOfCode.Y2022.Day01;

[Problem("Calorie Counting", 2022, 1)]
public class Solution : ISolution
{
    public string? PartOne(string input)
    {
        return GetSumOfCaloriesPerElf(input).First().ToString();
    }

    public string? PartTwo(string input)
    {
        return GetSumOfCaloriesPerElf(input).Take(3).Sum().ToString();
    }

    private static IEnumerable<int> GetSumOfCaloriesPerElf(string input)
    {   
        var stringCaloriesPerElf = input.Split(Environment.NewLine + Environment.NewLine)
            .Select(x => x.Split(Environment.NewLine));
        
        var intCaloriesPerElf = stringCaloriesPerElf.Select(x => x.Select(int.Parse));
        var sumOfCaloriesPerElf = intCaloriesPerElf.Select(x => x.Sum()).OrderByDescending(x => x);

        return sumOfCaloriesPerElf;
    }
}
