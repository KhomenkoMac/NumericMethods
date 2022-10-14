using Lab1.ReportWrappers;

public class FixedPointIterationMethod : IMethod
{
    public MyFunction Function { get; set; } = new MyFunction
    {
        TheFunction = ProblemStatedFunctions.f2,
    };

    private double alpha;
    private double gamma;

    private double Lipshec_Q => Math.Abs( (gamma - alpha) / (gamma + alpha) );
    private double Lambda
    {
        get
        {
            alpha = Math.Max(Function.TheFunctionDerivative(Function.A), Function.TheFunctionDerivative(Function.B));
            gamma = Math.Min(Function.TheFunctionDerivative(Function.A), Function.TheFunctionDerivative(Function.B));
            return 2.0 / (Function.TheFunctionDerivative(Function.A) + Function.TheFunctionDerivative(Function.B));
        }
    }
    
    private bool StopCriteria(double a, double b)
    {
        return Math.Abs(a - b) <= (1 - Lipshec_Q) * Function.Epsilon / Lipshec_Q;
    }

    private double Phi(double x) => x - Lambda * Function.TheFunction(x);

    private double getRoot(double x_curr)
    {
        // add iteration point to the plot
        //plotPoints.Add(new Point(iterationNumber++, x_curr));

        var x_next = Phi(x_curr);

        if (StopCriteria(x_next, x_curr))
        {
            //ResultsManager.Plot(plotPoints, plotFilename);
            return x_next;
        }
        return getRoot(x_next);
    }

    public virtual double getRoot()
    {
        if (!Auxiliary.IsMonotonous(Function.TheFunction, Function.A, Function.B))
        {
            throw new InvalidOperationException("Функція не строго монотонна на цьому проміжку. Виберіть інший проміжок.");
        }
        else if (!Auxiliary.IsRootOnRange(Function.A, Function.B, Function.TheFunction))
        {
            throw new InvalidOperationException("Функція не має коренів на цьому проміжку. Виберіть інший проміжок.");
        }
        return getRoot((Function.A + Function.B) / 2);
    }

    #region Plot valriables

    private int iterationNumber;
    private List<Point> plotPoints = Enumerable.Empty<Point>().ToList();

    private const string plotFilename = "FixedPointIterationMethod";
    #endregion
}
