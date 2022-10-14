

using Lab1.ReportWrappers;

public class BisectionMethod : IMethod
{
    public MyFunction Function { get; set; } = new MyFunction
    {
        TheFunction = ProblemStatedFunctions.f1,
    };

    public virtual double getRoot() => getRoot(Function.A, Function.B);

    private double getRoot(double a, double b)
    {
        if (!Auxiliary.IsMonotonous(Function.TheFunction, a, b))
        {
            throw new InvalidOperationException("Функція не строго монотонна на цьому проміжку. Виберіть інший проміжок.");

        }
        else if (!Auxiliary.IsRootOnRange(a, b, Function.TheFunction))
        {
            throw new InvalidOperationException("Функція не має коренів на цьому проміжку. Виберіть інший проміжок.");
        }

        var t = (a + b) / 2;

        // add iteration point to the plot
        //plotPoints.Add(new Point(iterationNumber++, t));

        if (Function.TheFunction(t) == 0.0 || Auxiliary.SimplifiedStopCriteria(a, b, Function.Epsilon))
        {
            //ResultsManager.Plot(plotPoints, plotFilename);
            return t;
        }

        if (Function.TheFunction(a) * Function.TheFunction(t) < 0) return getRoot(a, t);
        else if(Function.TheFunction(t) * Function.TheFunction(b) < 0) return getRoot(t, b);
        
        return double.NaN;
    }

    #region Plot valriables

    private int iterationNumber;
    private List<Point> plotPoints = Enumerable.Empty<Point>().ToList();

    private const string plotFilename = "BisectionMethod";
    #endregion
}
