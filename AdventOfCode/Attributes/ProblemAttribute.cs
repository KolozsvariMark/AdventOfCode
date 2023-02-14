namespace AdventOfCode.Attributes;

public class ProblemAttribute : Attribute
{
    public string name;
    public int year;
    public int day;

    public ProblemAttribute(string name, int year, int day)
    {
        this.name = name;
        this.year = year;
        this.day = day;
    }
}
