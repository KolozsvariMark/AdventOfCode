// See https://aka.ms/new-console-template for more information

using AdventOfCode;
using System.Reflection;

var solutionTypes = GetSolutionTypes();

foreach (var type in solutionTypes)
{
    var solution = Activator.CreateInstance(type) as ISolution ?? throw new NullReferenceException();

    var result = Solver.Solve(solution).ToList();

    Console.WriteLine(type.FullName);
    Console.WriteLine(result[0]);
    Console.WriteLine(result[1]);
}

static IEnumerable<Type> GetSolutionTypes()
{
    var assembly = Assembly.GetAssembly(typeof(ISolution))
        ?? throw new NullReferenceException();

    var types = assembly.GetTypes();
    return types
        .Where(type => typeof(ISolution).IsAssignableFrom(type) && !type.IsInterface);
}