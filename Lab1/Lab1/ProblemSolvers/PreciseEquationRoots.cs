

class PreciseEquationRoots : ProblemSolutionChain, IProblemHandler
{
    public override void Handle()
    {
        GetRootFunction.Function.A = AB.Item1;
        GetRootFunction.Function.B = AB.Item2;

        try
        {
            Console.WriteLine($"Корінь: {GetRootFunction.getRoot()}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        Console.ReadKey();
    }

    public void HandleProblem()
    {
        var methodAccepting = new MethodAccept();
        var epsilonAccepting = new EpsilonAccept();
        var abAccepting = new AcceptAB();

        abAccepting
            .Next(methodAccepting)
            .Next(epsilonAccepting)
            .Next(this);

        abAccepting.Handle();
    }
}
