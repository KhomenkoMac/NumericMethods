Console.OutputEncoding = System.Text.Encoding.Unicode;

IProblemHandler handler = default;

do
{
    Console.WriteLine("\n\n1. Вивести корені алгебреїчного рівняння методом Лобачевсього." +
                        "\n2. Уточнити корені рівнянь за допомогою методів задані за варіантом.");
    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            handler = new OutputAlgabricEquationWithLobachevskyi();
            break;
        case "2":
            handler = new PreciseEquationRoots();
            break;
        default:
            Console.WriteLine("Кінець програми!");
            return;
    }

    handler.HandleProblem();

} while (true);
