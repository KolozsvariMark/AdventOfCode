using AdventOfCode.Attributes;
using AdventOfCode.Utils;

namespace AdventOfCode.Y2022.Day04;

[Problem("Camp Cleanup", 2022, 4)]
public class Solution : ISolution
{
    public struct Section
    {
        public Section(int start, int end)
        {
            Start = start;
            End = end;
        }

        public int Start { get; set; }
        public int End { get; set; }
    }

    public object? PartOne(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var sum = 0;
        foreach(var line in lines)
        {
            var (firstSection, secondSection) = GetSections(line);

            if (FullyContains(firstSection, secondSection))
            {
                sum++;
            }
        }

        return sum;
    }

    public object? PartTwo(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var sum = 0;
        foreach (var line in lines)
        {
            var (firstSection, secondSection) = GetSections(line);

            if (FullyContains(firstSection, secondSection) || PartiallyContains(firstSection, secondSection))
            {
                sum++;
            }
        }

        return sum;
    }

    private (Section first,Section second) GetSections(string line)
    {
        var pairs = line.Split(',');

        var firstElf = pairs[0].Split('-');
        var secondElf = pairs[1].Split('-');

        var firstSection = new Section(int.Parse(firstElf[0]), int.Parse(firstElf[1]));
        var secondSection = new Section(int.Parse(secondElf[0]), int.Parse(secondElf[1]));

        return (firstSection, secondSection);
    }

    private bool FullyContains(Section first, Section second)
    {
        return (first.Start <= second.Start && first.End >= second.End) || (first.Start >= second.Start && first.End <= second.End);
    }

    private bool PartiallyContains(Section first, Section second)
    {
        return (first.Start <= second.Start && first.End >= second.Start) || (first.Start >= second.Start && first.Start <= second.End);
    }
}
