namespace model;

using System.Text;

public class Endereco
{
    public string Rua { get; set; }
    public int Numero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Cep { get; set; }

    public Endereco(string rua, int numero, string complemento,
                    string bairro, string cidade, string estado, string cep)
    {
        Rua = rua;
        Numero = numero;
        Complemento = complemento;
        Bairro = bairro;
        Cidade = cidade;
        Estado = estado;
        Cep = cep;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("=== Endereco ===");
        sb.Append(Environment.NewLine);
        sb.Append("Rua: ");
        sb.Append(Rua);
        sb.Append(Environment.NewLine);
        sb.Append("Numero: ");
        sb.Append(Numero);
        sb.Append(Environment.NewLine);
        sb.Append("Complemento: ");
        sb.Append(Complemento);
        sb.Append(Environment.NewLine);
        sb.Append("Bairro: ");
        sb.Append(Bairro);
        sb.Append(Environment.NewLine);
        sb.Append("Cidade: ");
        sb.Append(Cidade);
        sb.Append(Environment.NewLine);
        sb.Append("Estado: ");
        sb.Append(Estado);
        sb.Append(Environment.NewLine);
        sb.Append("CEP: ");
        sb.Append(Cep);
        return sb.ToString();
    }
}