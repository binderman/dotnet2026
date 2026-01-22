namespace model;

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
        return string.Join(Environment.NewLine,
            "=== Endereco ===",
            $"Rua: {Rua}",
            $"Numero: {Numero}",
            $"Complemento: {Complemento}",
            $"Bairro: {Bairro}",
            $"Cidade: {Cidade}",
            $"Estado: {Estado}",
            $"CEP: {Cep}");
    }
}