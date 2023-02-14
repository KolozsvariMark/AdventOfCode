using AdventOfCode.Attributes;

namespace AdventOfCode.Utils;

public class AttributeUtil
{
    private ProblemAttribute ProblemAttribute { get; set; } = null!;

    public AttributeUtil(ISolution solution)
    {
        ProblemAttribute? problemAttribute =
            Attribute.GetCustomAttribute(solution.GetType(), typeof(ProblemAttribute)) as ProblemAttribute;

        if (problemAttribute == null)
        {
            throw new NullReferenceException("The attribute was not found");
        }

        ProblemAttribute = problemAttribute;
    }

    public string GetProblemName()
    {
        return ProblemAttribute.name;
    }

    public string GetProblemYear()
    {
        return $"Y{ProblemAttribute.year}";
    }

    public string GetProblemDay()
    {
        return $"Day{ProblemAttribute.day:00}";
    }
}
