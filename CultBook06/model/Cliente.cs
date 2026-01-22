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

    public override string ToString()
    {
        string resultado = "=== Cliente ===" + Environment.NewLine
                         + $"Nome: {Nome}" + Environment.NewLine
                         + $"Login: {Login}" + Environment.NewLine
                         + $"Senha: {Senha}" + Environment.NewLine
                         + $"Email: {Email}" + Environment.NewLine
                         + $"Fone: {Fone}" + Environment.NewLine;

        resultado += "Enderecos:" + Environment.NewLine;
        for (int i = 0; i < _qtdEnderecos; i++)
        {
            resultado += $"--- Endereco {i + 1} ---" + Environment.NewLine;
            resultado += Enderecos[i].ToString() + Environment.NewLine;
        }

        resultado += "Pedidos:" + Environment.NewLine;
        for (int i = 0; i < _qtdPedidos; i++)
        {
            resultado += $"--- Pedido {i + 1} ---" + Environment.NewLine;
            resultado += Pedidos[i].ToString() + Environment.NewLine;
        }

        return resultado.TrimEnd();
    }
}
