

class Auxiliary
{
    public static bool IsRootOnRange(double a, double b, Func<double, double> f)
    {
        return f(a) * f(b) < 0;
    }

    public static bool SimplifiedStopCriteria(double a, double b, double epsilon)
    {
        return Math.Abs(a - b) < epsilon;
    }

    public static bool IsMonotonous(Func<double, double> f, double a, double b)
    {
        double step = 0.0001;
        bool grows = f(a) < f(a + step);
        for (double x = a; x < b; x += step)
        {
            if (f(x) < f(x + step) != grows)
                return false;
        }
        return true;
    }
}
