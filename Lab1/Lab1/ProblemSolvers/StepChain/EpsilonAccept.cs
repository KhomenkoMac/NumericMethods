

class EpsilonAccept : ProblemSolutionChain
{
    public override void Handle()
    {
        Console.WriteLine("Ввeдiть точнiсть або залиште рядок пустим [ epsilon = 10^(-7) ] :");
        if (double.TryParse(Console.ReadLine(), out double parsedEpsilon))
        {
            Epsillon = parsedEpsilon;
            Console.WriteLine($"1e-10 equls to 10^-10 {1e-10 == Math.Pow(10, -10)}");
        }
        else
        {
            Console.WriteLine("Точність втсановлено за замовчуванням");
        }

        base.Handle();
    }
}
