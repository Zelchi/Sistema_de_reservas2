using System.Text.RegularExpressions;

public class Reservas
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public int DiaReserva { get; set; }
    public int QuantidadePessoas { get; set; }

    public Reservas(string nome, string cpf, int diaReserva, int quantidadePessoas)
    {
        Nome = nome;
        CPF = cpf;
        DiaReserva = diaReserva;
        QuantidadePessoas = quantidadePessoas;
    }

    public static Reservas? CriarReserva()
    {
        Console.Clear();

        Console.Write("Digite o nome do cliente: ");
        string? nome = Console.ReadLine();
        if (string.IsNullOrEmpty(nome))
        {
            Console.Clear();
            Console.WriteLine("Nome inválido. Tente novamente.");
            System.Threading.Thread.Sleep(2000);
            return null;
        }

        Console.Write("Digite o CPF do cliente: ");
        string? cpf = Console.ReadLine();

        if (string.IsNullOrEmpty(cpf))
        {
            Console.Clear();
            Console.WriteLine("CPF inválido. Tente novamente.");
            System.Threading.Thread.Sleep(2000);
            return null;
        }

        Regex regex = new Regex(@"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})");
        Match matchCPF = regex.Match(cpf);

        if (!matchCPF.Success)
        {
            Console.Clear();
            Console.WriteLine("CPF inválido. Tente novamente.");
            System.Threading.Thread.Sleep(2000);
            return null;
        }

        Console.Write("Digite o dia da reserva: ");
        string? diaReservaInput = Console.ReadLine();
        if (!int.TryParse(diaReservaInput, out int diaReserva))
        {
            Console.Clear();
            Console.WriteLine("Dia da reserva inválido. Tente novamente.");
            System.Threading.Thread.Sleep(2000);
            return null;
        }

        Console.Write("Digite a quantidade de pessoas: ");
        string? quantidadePessoasInput = Console.ReadLine();
        if (!int.TryParse(quantidadePessoasInput, out int quantidadePessoas))
        {
            Console.Clear();
            Console.WriteLine("Quantidade de pessoas inválida. Tente novamente.");
            System.Threading.Thread.Sleep(2000);
            return null;
        }

        return new Reservas(nome, cpf, diaReserva, quantidadePessoas);
    }

    public string MostrarReservas()
    {
        string dia = DiaReserva switch
        {
            1 => "Quarta-Feira",
            2 => "Quinta-Feira",
            3 => "Sexta-Feira",
            4 => "Sábado",
            5 => "Domingo",
            _ => "Dia inválido"
        };
        return $"Nome: {Nome}, CPF: {CPF}, Dia da Reserva: {dia}, Quantidade de Pessoas: {QuantidadePessoas}";
    }

    public static void ListarReservas(Reservas[] reservas, int quantidadeReservas)
    {
        if (quantidadeReservas == 0)
        {
            Console.Clear();
            Console.WriteLine("Nenhuma reserva feita ainda.");
            System.Threading.Thread.Sleep(2000);
            return;
        }
        Console.Clear();
        Console.WriteLine("Lista de Reservas:\n");
        for (int i = 0; i < quantidadeReservas; i++)
        {
            Console.WriteLine(reservas[i].MostrarReservas());
        }
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }

    public static void TotalPessoasPorDia(Reservas[] reservas, int quantidadeReservas)
    {
        if (quantidadeReservas == 0)
        {
            Console.Clear();
            Console.WriteLine("Nenhuma reserva feita ainda.");
            System.Threading.Thread.Sleep(2000);
            return;
        }
        Console.Clear();

        Console.WriteLine("1 - Quarta-Feira\n2 - Quinta-Feira\n3 - Sexta-Feira\n4 - Sábado\n5 - Domingo");
        string? DiaReserva = Console.ReadLine();

        if (!int.TryParse(DiaReserva, out int diaReserva))
        {
            Console.Clear();
            Console.WriteLine("Dia da reserva inválido");
            System.Threading.Thread.Sleep(2000);

            TotalPessoasPorDia(reservas, quantidadeReservas);
        }

        int quantidadeDePessoasPorReserva = 0;
        for (int i = 0; i < quantidadeReservas; i++)
        {
            if (reservas[i] != null && reservas[i].DiaReserva == diaReserva)
            {
                quantidadeDePessoasPorReserva += reservas[i].QuantidadePessoas;
            }
        }

        Console.WriteLine($"Total de pessoas por dia: {quantidadeDePessoasPorReserva}");

        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }
}