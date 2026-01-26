namespace model;

using System.Text;

public class Pedido
{
    public int Numero { get; set; }
    public string DataEmissao { get; set; }
    public string FormaPagamento { get; set; }
    public double ValorTotal { get; set; }
    public string Situacao { get; set; }

    public Cliente? Cliente { get; set; }
    public Endereco? EnderecoEntrega { get; set; }

    public List<ItemDePedido> Itens { get; set; }

    public Pedido(int numero, string dataEmissao, string formaPagamento,
                  string situacao, ItemDePedido item)
    {
        Numero = numero;
        DataEmissao = dataEmissao;
        FormaPagamento = formaPagamento;
        Situacao = situacao;

        Itens = new List<ItemDePedido>();
        ValorTotal = 0;

        InserirItem(item);
    }

    public void InserirItem(ItemDePedido item)
    {
        Itens.Add(item);
        ValorTotal += item.Preco * item.Qtde;
    }

    public bool RemoverItem(string isbn)
    {
        ItemDePedido? itemParaRemover = Itens.Find(i => i.Livro.Isbn.Equals(isbn));
        
        if (itemParaRemover != null)
        {
            ValorTotal -= itemParaRemover.Preco * itemParaRemover.Qtde;
            Itens.Remove(itemParaRemover);
            return true;
        }
        
        return false;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("=== Pedido ===");
        sb.Append(Environment.NewLine);
        sb.Append("Numero: ");
        sb.Append(Numero);
        sb.Append(Environment.NewLine);
        sb.Append("DataEmissao: ");
        sb.Append(DataEmissao);
        sb.Append(Environment.NewLine);
        sb.Append("FormaPagamento: ");
        sb.Append(FormaPagamento);
        sb.Append(Environment.NewLine);
        sb.Append("Situacao: ");
        sb.Append(Situacao);
        sb.Append(Environment.NewLine);
        sb.Append("ValorTotal: ");
        sb.Append(ValorTotal);
        sb.Append(Environment.NewLine);

        if (Cliente != null)
        {
            sb.Append("Cliente:");
            sb.Append(Environment.NewLine);
            sb.Append(Cliente.ToString());
            sb.Append(Environment.NewLine);
        }

        if (EnderecoEntrega != null)
        {
            sb.Append("EnderecoEntrega:");
            sb.Append(Environment.NewLine);
            sb.Append(EnderecoEntrega.ToString());
            sb.Append(Environment.NewLine);
        }

        sb.Append("Itens:");
        sb.Append(Environment.NewLine);
        int contador = 1;
        foreach (var item in Itens)
        {
            sb.Append("--- Item ");
            sb.Append(contador);
            sb.Append(" ---");
            sb.Append(Environment.NewLine);
            sb.Append(item.ToString());
            sb.Append(Environment.NewLine);
            contador++;
        }

        return sb.ToString().TrimEnd();
    }
}