namespace model;

using System.Text;

public class Cliente
{
    public string Nome { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
    public string Email { get; set; }
    public string Fone { get; set; }

    public List<Endereco> Enderecos { get; set; }
    public List<Pedido> Pedidos { get; set; }

    public Cliente(string nome, string login, string senha, string email, string fone, Endereco endereco)
    {
        Nome = nome;
        Login = login;
        Senha = senha;
        Email = email;
        Fone = fone;

        Enderecos = new List<Endereco>();
        Pedidos = new List<Pedido>();

        InserirEndereco(endereco);
    }

    public void InserirPedido(Pedido pedido)
    {
        Pedidos.Add(pedido);
    }

    public void InserirEndereco(Endereco endereco)
    {
        Enderecos.Add(endereco);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("=== Cliente ===");
        sb.Append(Environment.NewLine);
        sb.Append("Nome: ");
        sb.Append(Nome);
        sb.Append(Environment.NewLine);
        sb.Append("Login: ");
        sb.Append(Login);
        sb.Append(Environment.NewLine);
        sb.Append("Senha: ");
        sb.Append(Senha);
        sb.Append(Environment.NewLine);
        sb.Append("Email: ");
        sb.Append(Email);
        sb.Append(Environment.NewLine);
        sb.Append("Fone: ");
        sb.Append(Fone);
        sb.Append(Environment.NewLine);

        sb.Append("Enderecos:");
        sb.Append(Environment.NewLine);
        int contadorEndereco = 1;
        foreach (var endereco in Enderecos)
        {
            sb.Append("--- Endereco ");
            sb.Append(contadorEndereco);
            sb.Append(" ---");
            sb.Append(Environment.NewLine);
            sb.Append(endereco.ToString());
            sb.Append(Environment.NewLine);
            contadorEndereco++;
        }

        sb.Append("Pedidos:");
        sb.Append(Environment.NewLine);
        int contadorPedido = 1;
        foreach (var pedido in Pedidos)
        {
            sb.Append("--- Pedido ");
            sb.Append(contadorPedido);
            sb.Append(" ---");
            sb.Append(Environment.NewLine);
            sb.Append(pedido.ToString());
            sb.Append(Environment.NewLine);
            contadorPedido++;
        }

        return sb.ToString().TrimEnd();
    }
}
