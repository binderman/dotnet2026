using service;
using System.Globalization;

namespace controller.console;

public class ConfigController
{
    private CultureInfo _culturaAtual;
    private Configurador _configurador;
    private Ajuda _ajuda;

    public CultureInfo CulturaAtual => _culturaAtual;

    public ConfigController()
    {
        // Inicializa configurador e carrega configurações
        _configurador = new Configurador();
        
        // Define cultura com base na configuração
        try
        {
            _culturaAtual = new CultureInfo(_configurador.Regiao);
        }
        catch
        {
            _culturaAtual = new CultureInfo("pt-BR");
            Console.WriteLine("Aviso: Região inválida no arquivo de configuração. Usando pt-BR.");
        }
        
        // Inicializa ajuda com o arquivo especificado
        _ajuda = new Ajuda(_configurador.ArquivoAjuda);
    }

    public void MudarRegiao()
    {
        Console.WriteLine("=== Mudar Região e Idioma ===");
        Console.WriteLine("1) Brasil (Português - pt-BR)");
        Console.WriteLine("2) França (Francês - fr-FR)");
        Console.WriteLine("3) Estados Unidos (Inglês - en-US)");
        Console.Write("Escolha uma opção: ");
        
        int opcao = Convert.ToInt32(Console.ReadLine());
        
        switch (opcao)
        {
            case 1:
                _culturaAtual = new CultureInfo("pt-BR");
                Console.WriteLine("Região alterada para Brasil (Português)");
                break;
            case 2:
                _culturaAtual = new CultureInfo("fr-FR");
                Console.WriteLine("Região alterada para França (Francês)");
                break;
            case 3:
                _culturaAtual = new CultureInfo("en-US");
                Console.WriteLine("Região alterada para Estados Unidos (Inglês)");
                break;
            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }

    public void MostrarAjuda()
    {
        Console.WriteLine();
        Console.WriteLine(_ajuda.Texto);
        Console.WriteLine();
        Console.Write("Pressione Enter para continuar...");
        Console.ReadLine();
    }
}
