using System.Globalization;

namespace controller.console;

public enum OpcaoMenu
{
    Login = 1,
    Cadastrar = 2,
    BuscarLivros = 3,
    InserirLivro = 4,
    RemoverLivro = 5,
    VerCarrinho = 6,
    EfetuarCompra = 7,
    MudarRegiao = 8,
    Ajuda = 9,
    Sair = 10
}

// Design Pattern: Façade
public class MenuController
{
    private bool _executando;
    private AuthController _authController;
    private LivroController _livroController;
    private CarrinhoController _carrinhoController;
    private ConfigController _configController;

    public bool Executando => _executando;

    public MenuController(AuthController authController, LivroController livroController, 
                         CarrinhoController carrinhoController, ConfigController configController)
    {
        _executando = true;
        _authController = authController;
        _livroController = livroController;
        _carrinhoController = carrinhoController;
        _configController = configController;
    }

    public void MostrarMenu()
    {
        Console.WriteLine();
        Console.WriteLine($"=========== CultBook - {ObterHoraFormatada()} ===========");
        Console.WriteLine($"Região atual: {_configController.CulturaAtual.DisplayName}");
        Console.WriteLine($"{(int)OpcaoMenu.Login}) Login");
        Console.WriteLine($"{(int)OpcaoMenu.Cadastrar}) Cadastrar");
        Console.WriteLine($"{(int)OpcaoMenu.BuscarLivros}) Buscar livros");
        Console.WriteLine($"{(int)OpcaoMenu.InserirLivro}) Inserir livro no carrinho");
        Console.WriteLine($"{(int)OpcaoMenu.RemoverLivro}) Remover livro do carrinho");
        Console.WriteLine($"{(int)OpcaoMenu.VerCarrinho}) Ver carrinho");

        if (_authController.Logado)
            Console.WriteLine($"{(int)OpcaoMenu.EfetuarCompra}) Efetuar compra");
        else
            Console.WriteLine($"{(int)OpcaoMenu.EfetuarCompra}) Efetuar compra (desabilitado - faça login)");

        Console.WriteLine($"{(int)OpcaoMenu.MudarRegiao}) Mudar região e idioma");
        Console.WriteLine($"{(int)OpcaoMenu.Ajuda}) Ajuda");
        Console.WriteLine($"{(int)OpcaoMenu.Sair}) Sair");
        Console.Write("Escolha uma opção: ");
    }

    private string ObterHoraFormatada()
    {
        return DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy", _configController.CulturaAtual);
    }

    public int LerOpcao()
    {
        return Convert.ToInt32(Console.ReadLine());
    }

    public void ProcessarOpcao(int opcao)
    {
        Console.WriteLine();

        switch ((OpcaoMenu)opcao)
        {
            case OpcaoMenu.Login:
                _authController.Login();
                break;

            case OpcaoMenu.Cadastrar:
                _authController.CadastrarCliente();
                break;

            case OpcaoMenu.BuscarLivros:
                _livroController.BuscarLivros(_configController.CulturaAtual);
                break;

            case OpcaoMenu.InserirLivro:
                _carrinhoController.InserirLivro();
                break;

            case OpcaoMenu.RemoverLivro:
                _carrinhoController.RemoverLivro();
                break;

            case OpcaoMenu.VerCarrinho:
                _carrinhoController.VerCarrinho();
                break;

            case OpcaoMenu.EfetuarCompra:
                if (!_authController.Logado)
                {
                    Console.WriteLine("Efetuar compra está desabilitado. Faça login primeiro.");
                }
                else
                {
                    _carrinhoController.EfetuarCompra(_configController.CulturaAtual);
                }
                break;

            case OpcaoMenu.MudarRegiao:
                _configController.MudarRegiao();
                break;

            case OpcaoMenu.Ajuda:
                _configController.MostrarAjuda();
                break;

            case OpcaoMenu.Sair:
                _executando = false;
                break;

            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }
}
