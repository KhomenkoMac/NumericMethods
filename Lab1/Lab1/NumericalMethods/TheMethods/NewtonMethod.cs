using Lab1.ReportWrappers;

public class NewtonMethod : IMethod
{
    public MyFunction Function { get; set; } = new MyFunction
    {
        TheFunction = ProblemStatedFunctions.f2
    };

    public double getRoot()
    {
        if (!Auxiliary.IsMonotonous(Function.TheFunction, Function.A, Function.B))
        {
            throw new InvalidOperationException("Функція не строго монотонна на цьому проміжку. Виберіть інший проміжок.");
        }
        else if (!Auxiliary.IsRootOnRange(Function.A, Function.B, Function.TheFunction))
        {
            throw new InvalidOperationException("Функція не має коренів на цьому проміжку. Виберіть інший проміжок.");
        }

        return getRoot(Function.A, Function.B);
    }

    public double getRoot(double a, double b)
    {
        var twoStepDerivative = Derivative.Solve((a) => Function.TheFunctionDerivative(a));
        var fourierCondition = Function.TheFunction(a) * twoStepDerivative(a) > 0;
        
        if (fourierCondition)  return getRoot(a);
        else return getRoot(b);
    }

    private double getRoot(double x_current)
    {
        var x_next = x_current - Function.TheFunction(x_current) 
                               / Function.TheFunctionDerivative(x_current);

        // add iteration point to the plot
        //plotPoints.Add(new Point(iterationNumber++, x_next));

        if (Auxiliary.SimplifiedStopCriteria(x_current, x_next, Function.Epsilon))
        {
            //ResultsManager.Plot(plotPoints, plotFilename);
            return x_next;
        }
        else
            return getRoot(x_next);
    }

    #region Plot valriables

    private int iterationNumber;
    private List<Point> plotPoints = Enumerable.Empty<Point>().ToList();

    private const string plotFilename = "NewtonMethod";
    #endregion
}
