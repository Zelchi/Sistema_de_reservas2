class Reservas
{
    public string nome { get; set; }
    public string cpf { get; set; }
    public int diaReserva{ get; set; }
    public int quantidadePessoas { get; set; }

    public Reservas(string nome, string cpf, int diaReserva, int quantidadePessoas)
    {
        this.nome = nome;
        this.cpf = cpf;
        this.diaReserva = diaReserva;
        this.quantidadePessoas = quantidadePessoas;
    }
}