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

    public override string ToString()
    {
        string resultado = "=== Pedido ===" + Environment.NewLine
                          + $"Numero: {Numero}" + Environment.NewLine
                          + $"DataEmissao: {DataEmissao}" + Environment.NewLine
                          + $"FormaPagamento: {FormaPagamento}" + Environment.NewLine
                          + $"Situacao: {Situacao}" + Environment.NewLine
                          + $"ValorTotal: {ValorTotal}" + Environment.NewLine;

        if (Cliente != null)
        {
            resultado += "Cliente:" + Environment.NewLine;
            resultado += Cliente.ToString() + Environment.NewLine;
        }

        if (EnderecoEntrega != null)
        {
            resultado += "EnderecoEntrega:" + Environment.NewLine;
            resultado += EnderecoEntrega.ToString() + Environment.NewLine;
        }

        resultado += "Itens:" + Environment.NewLine;
        for (int i = 0; i < _qtdItens; i++)
        {
            resultado += $"--- Item {i + 1} ---" + Environment.NewLine;
            resultado += Itens[i].ToString() + Environment.NewLine;
        }

        return resultado.TrimEnd();
    }
}