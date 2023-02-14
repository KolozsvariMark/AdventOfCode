using AdventOfCode.Utils;

namespace AdventOfCode;

public static class Solver
{
    public static IEnumerable<string> Solve(ISolution solution)
    {
        var input = File.ReadAllText(GetFullInputFilePath(solution));

        var partOneResult = solution.PartOne(input) ?? "Part one is unsolved!";
        var partTwoResult = solution.PartTwo(input) ?? "Part two is unsolved!";

        yield return partOneResult;
        yield return partTwoResult;
    }

    public static string GetFullInputFilePath(ISolution solution)
    {
        var currentDirectoryPath = Environment.CurrentDirectory;
        var filePath = GetFilePath(solution);

        return Path.Combine(currentDirectoryPath, filePath);
    }

    public static string GetFilePath(ISolution solution)
    {
        var attributeUtil = new AttributeUtil(solution);
        var paths = new List<string>() { attributeUtil.GetProblemYear(), attributeUtil.GetProblemDay(), "input.txt" };

        return paths.Aggregate(Path.Combine);
    }
}