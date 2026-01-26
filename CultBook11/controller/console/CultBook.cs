using model;
using controller.console;

public class CultBook
{
    private List<Cliente> _clientes;
    private AuthController _authController;
    private LivroController _livroController;
    private CarrinhoController _carrinhoController;
    private ConfigController _configController;
    private MenuController _menuController;

    public CultBook()
    {
        // Inicializa lista de clientes
        _clientes = new List<Cliente>();

        // Inicializa controllers
        _configController = new ConfigController();
        _authController = new AuthController(_clientes);
        _livroController = new LivroController();
        _carrinhoController = new CarrinhoController(_livroController);
        _menuController = new MenuController(_authController, _livroController, 
                                            _carrinhoController, _configController);
    }

    public static void Main(string[] args)
    {
        CultBook app = new CultBook();
        app.Executar();
    }

    private void Executar()
    {
        while (_menuController.Executando)
        {
            _menuController.MostrarMenu();
            int opcao = _menuController.LerOpcao();
            _menuController.ProcessarOpcao(opcao);
        }
    }
}