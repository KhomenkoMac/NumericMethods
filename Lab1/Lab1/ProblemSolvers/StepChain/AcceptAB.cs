

class AcceptAB : ProblemSolutionChain
{
    public override void Handle()
    {
        Console.WriteLine("Введiть промiжок локалiзацii: [a, b] ( два значення, роздiленi пробiлом, де a < b)");
        var tokens = Console.ReadLine().Split();
        AB = (double.Parse(tokens[0]), double.Parse(tokens[1]));

        base.Handle();
    }
}
