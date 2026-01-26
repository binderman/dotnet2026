using model;
using System.Text;

namespace controller.console;

public class AuthController
{
    private List<Cliente> _clientes;
    private bool _logado;
    private Cliente? _clienteLogado;

    public bool Logado => _logado;
    public Cliente? ClienteLogado => _clienteLogado;

    public AuthController(List<Cliente> clientes)
    {
        _clientes = clientes;
        _logado = false;
        _clienteLogado = null;
    }

    public void Login()
    {
        Console.WriteLine("=== Login ===");
        Console.Write("Login: ");
        string? login = Console.ReadLine();
        Console.Write("Senha: ");
        string? senha = Console.ReadLine();

        // Busca o cliente na lista
        Cliente? cliente = _clientes.Find(c => c.Login == login && c.Senha == senha);

        if (cliente != null)
        {
            _logado = true;
            _clienteLogado = cliente;
            Console.WriteLine($"Login realizado com sucesso! Bem-vindo(a), {cliente.Nome}!");
        }
        else
        {
            Console.WriteLine("Login ou senha incorretos!");
        }
    }

    public void CadastrarCliente()
    {
        Console.WriteLine("=== Cadastrar Cliente ===");
        Console.Write("Nome: ");
        string? nome = Console.ReadLine();
        Console.Write("Login: ");
        string? login = Console.ReadLine();
        Console.Write("Senha (deixe em branco para gerar automaticamente): ");
        string? senha = Console.ReadLine();
        
        // Gera senha aleatória se deixada em branco
        if (string.IsNullOrWhiteSpace(senha))
        {
            senha = GerarSenhaAleatoria();
            Console.WriteLine($"Senha gerada automaticamente: {senha}");
        }
        
        Console.Write("Email: ");
        string? email = Console.ReadLine();
        Console.Write("Telefone: ");
        string? fone = Console.ReadLine();
        
        Console.WriteLine("--- Endereço ---");
        Console.Write("Rua: ");
        string? rua = Console.ReadLine();
        Console.Write("Número: ");
        int numero = Convert.ToInt32(Console.ReadLine());
        Console.Write("Complemento: ");
        string? complemento = Console.ReadLine();
        Console.Write("Bairro: ");
        string? bairro = Console.ReadLine();
        Console.Write("Cidade: ");
        string? cidade = Console.ReadLine();
        Console.Write("Estado: ");
        string? estado = Console.ReadLine();
        Console.Write("CEP: ");
        string? cep = Console.ReadLine();
        
        Endereco endereco = new Endereco(rua ?? "", numero, complemento ?? "", 
                                         bairro ?? "", cidade ?? "", estado ?? "", cep ?? "");
        Cliente cliente = new Cliente(nome ?? "", login ?? "", senha, email ?? "", fone ?? "", endereco);
        
        _clientes.Add(cliente);
        Console.WriteLine("Cliente cadastrado com sucesso!");
    }

    private string GerarSenhaAleatoria()
    {
        const string letras = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string digitos = "0123456789";
        const string simbolos = "!@#$%&*";
        const string todosCaracteres = letras + digitos + simbolos;
        
        Random random = new Random();
        StringBuilder senha = new StringBuilder();
        
        // Garante pelo menos uma letra, um dígito e um símbolo
        senha.Append(letras[random.Next(letras.Length)]);
        senha.Append(digitos[random.Next(digitos.Length)]);
        senha.Append(simbolos[random.Next(simbolos.Length)]);
        
        // Completa com caracteres aleatórios até 8 caracteres
        for (int i = 3; i < 8; i++)
        {
            senha.Append(todosCaracteres[random.Next(todosCaracteres.Length)]);
        }
        
        // Embaralha os caracteres
        return new string(senha.ToString().OrderBy(x => random.Next()).ToArray());
    }
}
