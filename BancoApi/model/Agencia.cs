namespace exemplo.model;

public class Agencia
{
    List<ContaCorrente> contas = new List<ContaCorrente>();

    public void AbrirConta(ContaCorrente conta) {
        contas.Add(conta);
    }

    public ContaCorrente? BuscarConta(int numero)
    {
        foreach (var conta in contas)
        {
            if (conta.Numero == numero)
            {
                return conta;
            }
        }
        return null;
    }

    public bool RemoverConta(int numero)
    {
        var conta = BuscarConta(numero);
        if (conta == null)
        {
            return false;
        }
        return contas.Remove(conta);
    }

    public List<ContaCorrente> ListarContas()
    {
        return contas;
    }

    public double CalcularTotalGeral()
    {
        double total = 0.0;

        foreach (var conta in contas)
        {
            total += conta.ConsultarSaldo();
        }

        return total;
    }
}