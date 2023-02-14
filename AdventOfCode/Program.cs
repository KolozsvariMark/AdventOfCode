// See https://aka.ms/new-console-template for more information

using AdventOfCode.Utils;
using System.Reflection;

var solutionTypes = GetSolutionTypes();

var solutions = solutionTypes.Select(type => Activator.CreateInstance(type) as ISolution ?? throw new NullReferenceException());

Solver.SolveAll(solutions);

static IEnumerable<Type> GetSolutionTypes()
{
    var assembly = Assembly.GetAssembly(typeof(ISolution))
        ?? throw new NullReferenceException();

    var types = assembly.GetTypes();
    return types
        .Where(type => typeof(ISolution).IsAssignableFrom(type) && !type.IsInterface);
}