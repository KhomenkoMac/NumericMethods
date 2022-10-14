

abstract class ProblemSolutionChain
{
    protected static double Epsillon = 1e-7; // <-! 1e-7
    
    protected static IMethod GetRootFunction;
    protected static double[] RootsByLobachevskyi;

    protected static (double, double) AB { get; set; }

    private ProblemSolutionChain _next;
    public ProblemSolutionChain Next(ProblemSolutionChain unit)
    {
        _next = unit;
        return _next;
    }

    public virtual void Handle()
    {
        if (_next != null)
        {
            _next.Handle();
        }
    }
}
