using AdventOfCode.Attributes;
using AdventOfCode.Utils;


namespace AdventOfCode.Y2022.Day02;

[Problem("Rock Paper Scissors", 2022, 2)]
public class Solution : ISolution
{
    enum Shape
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3,
    }

    private Dictionary<Shape, Shape> Beats { get; set; } = new Dictionary<Shape, Shape>()
    {
        {Shape.Paper, Shape.Rock},
        {Shape.Scissors, Shape.Paper},
        {Shape.Rock, Shape.Scissors},
    };

    public object? PartOne(string input)
    {
        var rounds = input.Split(Environment.NewLine);
        var sum = 0;
        foreach(var round in rounds)
        {
            var elfShape = TranslateElfShape(round[0]);
            var humanShape = TranslateHumanShape(round[2]);
            sum += Result(TranslateElfShape(round[0]), TranslateHumanShape(round[2]));
        }

        return sum;
    }

    public object PartTwo(string input)
    {
        var rounds = input.Split(Environment.NewLine);
        var sum = 0;
        foreach (var round in rounds)
        {
            var elfShape = TranslateElfShape(round[0]);
            var humanShape = DecideShape(elfShape, round[2]);
            sum += Result(elfShape, humanShape);
        }

        return sum;
    }

    private Shape TranslateElfShape(char shape) => shape switch
    {
        'A' => Shape.Rock,
        'B' => Shape.Paper,
        'C' => Shape.Scissors,
        _ => throw new ArgumentOutOfRangeException(nameof(shape), $"Not expected shape value: {shape}")
    };

    private Shape TranslateHumanShape(char shape) => shape switch
    {
        'X' => Shape.Rock,
        'Y' => Shape.Paper,
        'Z' => Shape.Scissors,
        _ => throw new ArgumentOutOfRangeException(nameof(shape), $"Not expected shape value: {shape}")
    };

    private Shape DecideShape(Shape elfShape, char outcome) => outcome switch
    {
        'X' => Beats[elfShape],
        'Y' => elfShape,
        'Z' => Beats.FirstOrDefault(x => x.Value == elfShape).Key,
        _ => throw new ArgumentOutOfRangeException(nameof(outcome), $"Not expected outcome value: {outcome}")
    };
    
    private int Result(Shape elfShape, Shape humanShape)
    {
        if (humanShape == elfShape)
        {
            return (int)humanShape + 3;
        }
        else if (Beats[humanShape] == elfShape)
        {
            return (int)humanShape + 6;
        }
        else
        {
            return (int)humanShape;
        }
    }
}

