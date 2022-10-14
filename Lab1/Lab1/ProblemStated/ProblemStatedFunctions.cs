

static class ProblemStatedFunctions
{
    public static double f1(double x) // [0.25; 1]
    {
        return Math.Pow(x, 2) * Math.Cos(x) +  Math.Log2(Math.Pow(Math.E, x)) + Math.PI - 9 * Math.PI * Math.Pow(x, 3);
    }

    public static double f2(double x)
    {
        return Math.Pow(Math.E, Math.Cosh(x)) + Math.Pow(x, 5) + Math.Pow(x, 15) * Math.Sin(x) - 13;
    }

    public static double lobachevsky(double x)
    {
        double[] koefs = LobachevskyiMethod.koefs;

        double sum = 0;
        for (int i = 0; i < koefs.Length; i++)
        {
            sum += koefs[i] * Math.Pow(x, koefs.Length - i - 1);
        }
        return sum;
    }
}
