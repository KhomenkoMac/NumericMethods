

class LobachevskyiSolveAccept : ProblemSolutionChain
{
    public override void Handle()
    {
        RootsByLobachevskyi = LobachevskyiMethod.solve();
        base.Handle();
    }
}
