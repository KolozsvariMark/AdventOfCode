using AdventOfCode.Attributes;

namespace AdventOfCode.Utils;

public static class AttributeUtil
{
    public static ProblemAttribute GetProblemAttribute(ISolution solution)
    {
        ProblemAttribute? problemAttribute =
            Attribute.GetCustomAttribute(solution.GetType(), typeof(ProblemAttribute)) as ProblemAttribute;

        if (problemAttribute == null)
        {
            throw new NullReferenceException("The attribute was not found");
        }

        return problemAttribute;
    }

    public static string GetProblemName(this ProblemAttribute problemAttribute)
    {
        return problemAttribute.name;
    }

    public static string GetProblemYear(this ProblemAttribute problemAttribute)
    {
        return $"Y{problemAttribute.year}";
    }

    public static string GetProblemDay(this ProblemAttribute problemAttribute)
    {
        return $"Day{problemAttribute.day:00}";
    }
}
