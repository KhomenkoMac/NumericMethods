using System.Text;
using QuickChart;
using Newtonsoft.Json;

namespace Lab1.ReportWrappers
{
    public static class ResultsManager
    {
        public static void SaveResultToCSV(double result, string pathToCSV)
        {
            IList<double> resultsFromFile;

            if (File.Exists(pathToCSV))
            {
                resultsFromFile = File.ReadLines(pathToCSV).Select(x => double.Parse(x)).ToList();
            }
            else
            {
                resultsFromFile = Enumerable.Empty<double>().ToList();
            }

            resultsFromFile.Add(result);

            var arr = resultsFromFile.OrderBy(x => x)
                                     .Select(x => $"{x}")
                                     .ToArray();
            File.WriteAllLines(pathToCSV, arr);
        }

        public static void SaveResultToCSV(double iteration, double result, string pathToCSV)
        {
            IList<string> resultsFromFile = File.Exists(pathToCSV) 
                ? File.ReadLines(pathToCSV).ToList()
                : Enumerable.Empty<string>().ToList();

            resultsFromFile.Add(string.Join(';', iteration, result));
            File.WriteAllLines(pathToCSV, resultsFromFile.ToArray());
        }

        public static void Plot(IEnumerable<Point> points, string fileName)
        {
            Chart qc = new();

            qc.Width = 1024;
            qc.Height = 900;
            qc.Version = "2";

            qc.Config = @"{
						  type: 'line',
						  data: {
						    labels: " + JsonConvert.SerializeObject(points.Select(x => x.iterations).ToArray()) + @",
						    datasets: [
						      {
						        label: 'Iteration Points',
						        backgroundColor: 'rgb(255, 99, 132)',
						        borderColor: 'rgb(255, 99, 132)',
						        data: " + JsonConvert.SerializeObject(points.Select(x => x.values).ToArray()) + @",
						        fill: false,
						      }
						    ],
						  },
						  options: {
						    title: {
						      display: true,
						      text: 'point convergence visualised',
						    },
						  },
						}";
            Console.WriteLine(qc.GetUrl());
            qc.ToFile($"{fileName}.png");
        }
    }
}