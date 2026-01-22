namespace model;

public class Cliente
{
    public string Nome { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
    public string Email { get; set; }
    public string Fone { get; set; }

    public Endereco[] Enderecos { get; set; }
    public Pedido[] Pedidos { get; set; }

    private int _qtdEnderecos;
    private int _qtdPedidos;

    public Cliente(string nome, string login, string senha, string email, string fone, Endereco endereco)
    {
        Nome = nome;
        Login = login;
        Senha = senha;
        Email = email;
        Fone = fone;

        Enderecos = new Endereco[10];
        Pedidos = new Pedido[10];

        _qtdEnderecos = 0;
        _qtdPedidos = 0;

        InserirEndereco(endereco);
    }

    public bool InserirPedido(Pedido pedido)
    {
        if (_qtdPedidos >= Pedidos.Length)
            return false;

        Pedidos[_qtdPedidos] = pedido;
        _qtdPedidos++;
        return true;
    }

    public bool InserirEndereco(Endereco endereco)
    {
        if (_qtdEnderecos >= Enderecos.Length)
            return false;

        Enderecos[_qtdEnderecos] = endereco;
        _qtdEnderecos++;
        return true;
    }

    public void Mostrar()
    {
        Console.WriteLine("=== Cliente ===");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Login: {Login}");
        Console.WriteLine($"Senha: {Senha}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Fone: {Fone}");

        Console.WriteLine("Enderecos:");
        for (int i = 0; i < _qtdEnderecos; i++)
        {
            Console.WriteLine($"--- Endereco {i + 1} ---");
            Enderecos[i].Mostrar();
        }

        Console.WriteLine("Pedidos:");
        for (int i = 0; i < _qtdPedidos; i++)
        {
            Console.WriteLine($"--- Pedido {i + 1} ---");
            Pedidos[i].Mostrar();
        }
    }
}
