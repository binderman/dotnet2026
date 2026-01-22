using model;

public class CultBook
{
    private bool _logado = false;
    private bool _executando = true;

    private Pedido? pedido;

    Livro[] livros = new Livro[]
    {
        new Livro("978-3-16-148410-0", "O Senhor dos Anéis", "Uma épica aventura na Terra Média.", "J.R.R. Tolkien", 10, 59.90, "Fantasia"),
        new Livro("978-0-7432-7356-5", "O Código Da Vinci", "Um thriller de mistério envolvendo arte e história.", "Dan Brown", 5, 39.90, "Suspense"),
        new Livro("978-1-56619-909-4", "1984", "Um romance distópico sobre vigilância e totalitarismo.", "George Orwell", 8, 29.90, "Ficção Científica"),
        new Livro("978-0-452-28423-4", "Orgulho e Preconceito", "Um clássico romance sobre amor e sociedade.", "Jane Austen", 7, 24.90, "Romance"),
        new Livro("978-0-14-044913-6", "Crime e Castigo", "Um mergulho profundo na mente de um assassino.", "Fiódor Dostoiévski", 4, 34.90, "Ficção")
    };

    public static void Main(string[] args)
    {
        CultBook app = new CultBook();
        app.Executar();
    }

    private void Executar()
    {
        while (_executando)
        {
            MostrarMenu();
            int opcao = LerOpcao();
            ProcessarOpcao(opcao);
        }
    }

    private void MostrarMenu()
    {
        Console.WriteLine();
        Console.WriteLine("=========== CultBook ===========");
        Console.WriteLine("1) Login");
        Console.WriteLine("2) Cadastrar");
        Console.WriteLine("3) Buscar livros");
        Console.WriteLine("4) Inserir livro no carrinho");
        Console.WriteLine("5) Remover livro do carrinho");
        Console.WriteLine("6) Ver carrinho");

        if (_logado)
            Console.WriteLine("7) Efetuar compra");
        else
            Console.WriteLine("7) Efetuar compra (desabilitado - faça login)");

        Console.WriteLine("8) Sair");
        Console.Write("Escolha uma opção: ");
    }

    private int LerOpcao()
    {
        return Convert.ToInt32(Console.ReadLine());
    }

    private void ProcessarOpcao(int opcao)
    {
        Console.WriteLine();

        switch (opcao)
        {
            case 1:
                Login();
                break;

            case 2:
                Console.WriteLine("Cadastrar em construção.");
                break;

            case 3:
                BuscarLivros();
                break;

            case 4:
                InserirLivro();
                break;

            case 5:
                Console.WriteLine("Remover livro do carrinho em construção.");
                break;

            case 6:
                VerCarrinho();
                break;

            case 7:
                if (!_logado)
                {
                    Console.WriteLine("Efetuar compra está desabilitado. Faça login primeiro.");
                }
                else
                {
                    Console.WriteLine("Efetuar compra em construção.");
                }
                break;

            case 8:
                _executando = false;
                break;

            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }

    private void Login()
    {
        Console.WriteLine("Login em construção.");
        _logado = true; // "login executado" habilita compra
    }

    public void BuscarLivros()
    {
        for (int i = 0; i < livros.Length; i++)
        {
            if (livros[i] != null)
            {
                livros[i].Mostrar();
            }
        }
    }

    public void InserirLivro()
    {
        // Lê o livro escolhido do teclado
        Console.WriteLine("=== Inserir Livro no Carrinho ===");
        Console.Write("Digite o ISBN do livro para compra: ");
        String? isbn = Console.ReadLine();

        // Busca livro selecionado
        Livro? aux = null;
        for (int i = 0; i < livros.Length; i++)
        {
            if (livros[i] != null && livros[i].Isbn.Equals(isbn))
            {
                aux = livros[i];
                break;
            }
        }

        // Se não existir, interrompe
        if (aux == null)
        {
            return;
        }

        // Cria item
        ItemDePedido item = new ItemDePedido(aux, 1, aux.Preco);

        // Cria pedido se não existir
        if (pedido == null)
        {
            pedido = new Pedido(1, "2024-01-01", "Cartão de Crédito", "Em Processamento", item);
        }
        else
        {
            pedido.InserirItem(item);
        }
    }

    public void VerCarrinho()
    {
        if (pedido != null)
        {
            pedido.Mostrar();
        }
        else
        {
            Console.WriteLine("Carrinho vazio.");
        }
    }
}