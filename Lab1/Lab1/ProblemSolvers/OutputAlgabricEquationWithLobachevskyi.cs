

class OutputAlgabricEquationWithLobachevskyi : ProblemSolutionChain, IProblemHandler
{
    public override void Handle()
    {
        try
        {
            double[] newRoots = LobachevskyiMethod.preciseRootsBySomeMethod(RootsByLobachevskyi, GetRootFunction, Epsillon);
            Console.WriteLine("\nУточнені корені рівняння обраним методом:\n ");

            for (int i = 0; i < newRoots.Length; i++)
            {
                Console.WriteLine($"Корінь до уточнення: {RootsByLobachevskyi[i], 20}.......Після уточнення: {newRoots[i], 20}");
            }

            Console.ReadKey();
        }
        catch (Exception e)
        {
            Console.Write(e.Message);
        }
    }

    public void HandleProblem()
    {
        var methodAccepting = new MethodAccept();
        var epsilonAccepting = new EpsilonAccept();
        var lobachevskyiSolveAccepting = new LobachevskyiSolveAccept();

        lobachevskyiSolveAccepting
            .Next(methodAccepting)
            .Next(epsilonAccepting)
            .Next(this);

        lobachevskyiSolveAccepting.Handle();
    }
}
