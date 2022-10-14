using Lab1.ReportWrappers;

namespace Lab1Tests
{

    public class FixedPointMethodTest
    {
        class ValidPrecisions : TheoryData
        {
            public ValidPrecisions()
            {
                //equation roots
                const double root1 = -3.60705853614064;
                const double root2 = -3.14545861215660;
                const double root3 = -1.16713337780109;
                const double root4 = 1.12974083456884;
                const double root5 = 3.14548028055041;
                const double root6 = 3.60705756178907;
                AddRow(-3.7, -3.55, null, root1);
                AddRow(-3.2, -3.0, null, root2);
                AddRow(-1.3, -1.0, null, root3);
                AddRow(1, 1.3, null, root4);
                AddRow(3.0, 3.3, null, root5);
                AddRow(3.55, 3.8, null, root6);
            }
        }

        [Theory]
        [ClassData(typeof(ValidPrecisions))]
        public void PreciseRoots_WithValidFixedPointIterMethod_ReturnsResultWithSpecifiedPrecision(double a, double b, double? precisionEpsilon, double precisedRoot)
        {
            var service = new FixedPointIterationMethod();
            service.Function.A = a;
            service.Function.B = b;
            if (precisionEpsilon is not null) service.Function.Epsilon = precisionEpsilon.Value;
            var digits_after_point = int.Parse($"{service.Function.Epsilon}".Split("-")[1]);

            var result = service.getRoot();
            
            Assert.Equal(result, precisedRoot, digits_after_point);
            ResultsManager.SaveResultToCSV(result, "./fixedPointResults.csv");
        }

       
    }
}