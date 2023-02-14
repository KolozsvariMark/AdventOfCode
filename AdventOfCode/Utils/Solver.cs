namespace AdventOfCode.Utils;

public static class Solver
{
    public static void SolveAll(IEnumerable<ISolution> solutions)
    {
        if (!solutions.Any())
        {
            Console.WriteLine("Nothing to solve!");
        }

        foreach(var solution in solutions)
        {
            var input = File.ReadAllText(GetFullInputFilePath(solution));
            Solve(solution, input);
        }
    }

    public static IEnumerable<string> Solve(ISolution solution, string input)
    {
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