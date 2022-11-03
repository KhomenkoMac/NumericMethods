

class LobachevskyiMethod
{
    public static readonly double[] koefs = { 17, 268, 472, -837, -744, 414, 124, -34 };

    private const double defaultPrecision = 1e-2; // aka epsilon

    private static double[] Normalize(double[] array)
    {
        double[] res = new double[array.Length];
        
        var norm = Math.Sqrt( array.Sum(x => Math.Pow(x, 2)) );
        
        for (int i = 0; i < array.Length; i++)
        {
            res[i] = array[i] / norm;
        }

        return res;
    }

    public static bool StopCriteria(double[] old, double[] _new)
    {
        for (int i = 0; i < old.Length; i++)
        {
            double diff = Math.Abs(Math.Pow(old[i], 2) / _new[i]);
            if (diff > defaultPrecision)
            {
                return false;
            }
        }
        return true;
    }

    public static double[] solve()
    {
        double[] a = Normalize(koefs);
        double[] b = new double[koefs.Length];

        int n = koefs.Length - 1;
        int p = 0;
        while (!StopCriteria(a, b))
        {
            p++;
            for (int k = 0; k <= n; k++)
            {
                double sum = 0;
                for (int j = 1; j <= Math.Min(k, n - k); j++)
                {
                    sum += Math.Pow(-1, j) * a[k - j] * a[k + j];
                }
                b[k] = Math.Pow(a[k], 2) + 2 * sum;
            }
            Array.Copy(b, a, b.Length);
        }

        double[] res = new double[b.Length - 1];
        double power = Math.Pow(2, -p);

        for (int i = 1; i < b.Length; i++)
        {
            double root = Math.Pow(b[i] / b[i - 1], power);

            if (Math.Abs(ProblemStatedFunctions.lobachevsky(root)) < 5)
            {
                res[i - 1] = root;
            }
            else
            {
                res[i - 1] = -root;
            }
        }

        return res;
    }

    public static double[] preciseRootsBySomeMethod(double[] roots, IMethod method, double eps)
    {
        double[] newRoots = new double[roots.Length];
        
        double delta = 0.01;
        
        method.Function = new MyFunction
        {
            TheFunction = ProblemStatedFunctions.lobachevsky,
            //A = a,
            //B = b,
            Epsilon = eps
        };

        for (int i = 0; i < newRoots.Length; i++)
        {
            method.Function.A = roots[i] - delta;
            method.Function.B = roots[i] + delta;

            newRoots[i] = method.getRoot();
        }
        return newRoots;
    }
}