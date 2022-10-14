

public class MyFunction
{
    public double Epsilon { get; set; } = 1e-7;

    //boundaries
    public double A { get; set; }
    public double B { get; set; }

    // 
    public Func<double, double> TheFunction { get; init; }
    public Func<double, double> TheFunctionDerivative => Derivative.Solve(TheFunction);
}
