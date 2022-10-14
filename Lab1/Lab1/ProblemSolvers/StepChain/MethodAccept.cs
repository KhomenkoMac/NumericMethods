using Lab1.ReportWrappers;

class MethodAccept : ProblemSolutionChain
{
    public override void Handle()
    {
        Console.WriteLine("\n\nВиберiть метод уточнення коренів :" +
                              "\n  1. Метод поділу навпіл." +
                              "\n  2. Метод дотичних." +
                              "\n  3. Метод простих ітерацій." +
                              "\n  4. Вийти.");
        var method = Console.ReadLine();
        switch (method)
        {
            case "1":
                GetRootFunction = new BisectionMethod();
                Console.WriteLine("----------------- Метод поділу навпіл  -----------------");
                break;
            case "2":
                GetRootFunction = new NewtonMethod();
                Console.WriteLine("----------------- Метод дотичних  -----------------");
                break;
            case "3":
                GetRootFunction = new FixedPointIterationMethod();
                Console.WriteLine("----------------- Метод простих ітерацій  -----------------");
                break;
            case "4":
                Console.WriteLine("------------------- Вихід з опції  ---------------------");
                return;
            default:
                throw new Exception("Такого методу немає. Спробуйте ще раз.");
        }

        base.Handle();
    }
}
