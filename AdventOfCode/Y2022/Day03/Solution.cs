using AdventOfCode.Attributes;
using AdventOfCode.Utils;


namespace AdventOfCode.Y2022.Day03;

[Problem("Rucksack Reorganization", 2022, 3)]
public class Solution : ISolution
{
    public object? PartOne(string input)
    {
        var lines = input.Split(Environment.NewLine);

        var sum = 0;
        foreach(var line in lines)
        {
            var first = line.Substring(0, line.Length / 2);
            var second = line.Substring(line.Length / 2);

            var list = new List<string>() { first, second };

            var duplicate = IntersectStrings(list);

            sum += GetPriority(duplicate);
        }

        return sum;
    }

    public object? PartTwo(string input)
    {
        var lines = input.Split(Environment.NewLine);

        var sum = 0;
        for ( var i = 0; i < lines.Length; i += 3)
        {
            var group1 = lines[i];
            var group2 = lines[i + 1];
            var group3 = lines[i + 2];

            var list = new List<string>() { group1, group2, group3 };

            var badge = IntersectStrings(list);
            
            sum += GetPriority(badge);
        }

        return sum;
    }

    private char IntersectStrings(IEnumerable<string> strings)
    {
        return strings.Aggregate((working, next) => string.Join("", working.Intersect(next).ToList())).First();
    }

    private int GetPriority(char character)
    {
        return char.IsUpper(character) ? character - 38 : character - 96;
    }
}

