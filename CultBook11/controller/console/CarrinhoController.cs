using model;
using System.Globalization;

namespace controller.console;

public class CarrinhoController
{
    private Pedido? _pedido;
    private LivroController _livroController;

    public CarrinhoController(LivroController livroController)
    {
        _livroController = livroController;
        _pedido = null;
    }

    public void InserirLivro()
    {
        Console.WriteLine("=== Inserir Livro no Carrinho ===");
        Console.Write("Digite o ISBN do livro para compra: ");
        string? isbn = Console.ReadLine();

        // Busca livro selecionado
        Livro? livro = _livroController.BuscarPorIsbn(isbn ?? "");

        // Se não existir, interrompe
        if (livro == null)
        {
            Console.WriteLine("Livro não encontrado.");
            return;
        }

        // Cria item
        ItemDePedido item = new ItemDePedido(livro, 1, livro.Preco);

        // Cria pedido se não existir
        if (_pedido == null)
        {
            _pedido = new Pedido(1, DateTime.Now.ToString("dd/MM/yyyy"), "Cartão de Crédito", "Em Processamento", item);
            Console.WriteLine("Livro adicionado ao carrinho!");
        }
        else
        {
            _pedido.InserirItem(item);
            Console.WriteLine("Livro adicionado ao carrinho!");
        }
    }

    public void RemoverLivro()
    {
        if (_pedido == null || _pedido.Itens.Count == 0)
        {
            Console.WriteLine("Carrinho vazio. Não há itens para remover.");
            return;
        }

        Console.WriteLine("=== Remover Livro do Carrinho ===");
        Console.Write("Digite o ISBN do livro para remover: ");
        string? isbn = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(isbn))
        {
            Console.WriteLine("ISBN inválido.");
            return;
        }

        if (_pedido.RemoverItem(isbn))
        {
            Console.WriteLine("Livro removido com sucesso!");
            
            // Se o carrinho ficar vazio, limpa o pedido
            if (_pedido.Itens.Count == 0)
            {
                _pedido = null;
                Console.WriteLine("Carrinho agora está vazio.");
            }
        }
        else
        {
            Console.WriteLine("Livro não encontrado no carrinho.");
        }
    }

    public void VerCarrinho()
    {
        if (_pedido != null)
        {
            Console.WriteLine(_pedido);
        }
        else
        {
            Console.WriteLine("Carrinho vazio.");
        }
    }

    public void EfetuarCompra(CultureInfo cultura)
    {
        if (_pedido == null || _pedido.Itens.Count == 0)
        {
            Console.WriteLine("Carrinho vazio. Não há itens para comprar.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("=== Efetuar Compra ===");
        Console.WriteLine();
        Console.WriteLine(_pedido);
        Console.WriteLine();
        Console.WriteLine($"Valor Total da Compra: {_pedido.ValorTotal.ToString("C", cultura)}");
        Console.WriteLine();
        Console.Write("Deseja confirmar a compra? (S/N): ");
        string? resposta = Console.ReadLine()?.ToUpper();

        if (resposta == "S")
        {
            Console.WriteLine();
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("  ✓ Compra realizada com sucesso!");
            Console.WriteLine("  Obrigado por comprar na CultBook!");
            Console.WriteLine("═══════════════════════════════════════");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Compra cancelada.");
        }

        // Zera o pedido em ambos os casos
        _pedido = null;
    }
}
