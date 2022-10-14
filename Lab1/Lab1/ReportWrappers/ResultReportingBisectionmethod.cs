namespace Lab1.ReportWrappers
{
    public class ResultReportingBisectionmethod : BisectionMethod
    {
        private int iteration;
        private const string plotFile = "./bisection.png";

        List<Point> points = new();

		
        public override double getRoot() => getRoot(Function.A, Function.B);

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
            points.Add(new Point(iteration++, t));
            //ResultsManager.SaveResultToCSV(result: t, iteration: iteration, );

            if (Function.TheFunction(t) == 0.0 || Auxiliary.SimplifiedStopCriteria(a, b, Function.Epsilon))
            {
                ResultsManager.Plot(points, plotFile);
                return t;
            }

            if (Function.TheFunction(a) * Function.TheFunction(t) < 0) return getRoot(a, t);
            else if (Function.TheFunction(t) * Function.TheFunction(b) < 0) return getRoot(t, b);

            return double.NaN;
        }

        
    }

}
