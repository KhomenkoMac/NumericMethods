

class Derivative
{
    private const double STEP = 1e-5;
    public static Func<double, double> Solve(Func<double, double> f) => (x) => ( f(x) - f(x - STEP) ) / STEP;
}
