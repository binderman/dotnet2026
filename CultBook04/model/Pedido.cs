namespace model;

public class Pedido
{
    public int Numero { get; set; }
    public string DataEmissao { get; set; }
    public string FormaPagamento { get; set; }
    public double ValorTotal { get; set; }
    public string Situacao { get; set; }

    public Cliente? Cliente { get; set; }
    public Endereco? EnderecoEntrega { get; set; }

    public ItemDePedido[] Itens { get; set; }
    private int _qtdItens;

    public Pedido(int numero, string dataEmissao, string formaPagamento,
                  string situacao, ItemDePedido item)
    {
        Numero = numero;
        DataEmissao = dataEmissao;
        FormaPagamento = formaPagamento;
        Situacao = situacao;

        Itens = new ItemDePedido[10];
        _qtdItens = 0;
        ValorTotal = 0;

        InserirItem(item);
    }

    public bool InserirItem(ItemDePedido item)
    {
        // array fixo: insere se houver espaço
        if (_qtdItens >= Itens.Length)
            return false;

        Itens[_qtdItens] = item;
        _qtdItens++;

        ValorTotal += item.Preco * item.Qtde;
        return true;
    }

    public void Mostrar()
    {
        Console.WriteLine("=== Pedido ===");
        Console.WriteLine($"Numero: {Numero}");
        Console.WriteLine($"DataEmissao: {DataEmissao}");
        Console.WriteLine($"FormaPagamento: {FormaPagamento}");
        Console.WriteLine($"Situacao: {Situacao}");
        Console.WriteLine($"ValorTotal: {ValorTotal}");

        if (Cliente != null)
        {
            Console.WriteLine("Cliente:");
            Cliente.Mostrar();
        }

        if (EnderecoEntrega != null)
        {
            Console.WriteLine("EnderecoEntrega:");
            EnderecoEntrega.Mostrar();
        }

        Console.WriteLine("Itens:");
        for (int i = 0; i < _qtdItens; i++)
        {
            Console.WriteLine($"--- Item {i + 1} ---");
            Itens[i].Mostrar();
        }
    }
}