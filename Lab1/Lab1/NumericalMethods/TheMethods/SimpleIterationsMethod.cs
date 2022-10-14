using static System.Math;

class FixedPoint : IMethod
{
    private double Lambda => 1 / Math.Max(Math.Abs(Function.TheFunctionDerivative(Function.A)),
                                          Math.Abs(Function.TheFunctionDerivative(Function.B)));
    
    public MyFunction Function { get; set; } = new MyFunction
    {
        TheFunction = ProblemStatedFunctions.f2,
    };

    public double Phi(double x) => x - Lambda * Function.TheFunction(x);


    public double Phi1(double x) =>
        Pow(13 - Exp(Cosh(x) - Pow(x, 15) * Sin(x)), 1 / 5);

    public double Phi2(double x) =>
        Pow((13 - Exp(Cosh(x) - Pow(x, 5))) / Sin(x), 1.0 / 15);

    public double getRoot(double x_current)
    {
        var x_next = Phi2(x_current);
        
        if (Auxiliary.SimplifiedStopCriteria(x_current, x_next, Function.Epsilon)) 
            return x_next;
        
        return getRoot(x_next);
    }

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
        return getRoot((Function.A + Function.B) / 2);
    }
}
