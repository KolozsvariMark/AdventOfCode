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
            var results = Solve(solution, input).ToList();

            var problemAttribute = AttributeUtil.GetProblemAttribute(solution);
            Console.WriteLine($"{problemAttribute.GetProblemYear()} {problemAttribute.GetProblemDay()} {problemAttribute.name}");

            Console.WriteLine(results[0]);
            Console.WriteLine(results[1]);
            Console.WriteLine();
        }
    }

    public static IEnumerable<object> Solve(ISolution solution, string input)
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
        var problemAttribute = AttributeUtil.GetProblemAttribute(solution);
        var paths = new List<string>() { problemAttribute.GetProblemYear(), problemAttribute.GetProblemDay(), "input.txt" };

        return paths.Aggregate(Path.Combine);
    }
}