Reservas[] reservas = new Reservas[100];
int quantidadeReservas = 0;

menu();

void menu()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("Bem vindo ao novo sistema de reservas!\n");
        Console.WriteLine("---------------------------\n1 - Fazer reserva\n2 - Lista de reservas\n3 - Total de pessoas por dia\n4 - Sair\n---------------------------\n");

        ConsoleKeyInfo tecla = Console.ReadKey();
        Console.WriteLine();

        switch (tecla.Key)
        {
            case ConsoleKey.D1:
            case ConsoleKey.NumPad1:
                var novaReserva = Reservas.CriarReserva();
                if (novaReserva != null)
                {
                    reservas[quantidadeReservas] = novaReserva;
                    quantidadeReservas++;
                }
                else
                {
                    Console.WriteLine("Erro ao criar reserva. Tente novamente.");
                    System.Threading.Thread.Sleep(2000);
                }
                break;
            case ConsoleKey.D2:
            case ConsoleKey.NumPad2:
                Reservas.ListarReservas(reservas, quantidadeReservas);
                break;
            case ConsoleKey.D3:
            case ConsoleKey.NumPad3:
                Reservas.TotalPessoasPorDia(reservas, quantidadeReservas);
                break;
            case ConsoleKey.D4:
            case ConsoleKey.NumPad4:
                Sair();
                break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    }
}

void Sair()
{
    Console.WriteLine("Saindo...");
    System.Environment.Exit(0);
    Console.WriteLine("exit");
}