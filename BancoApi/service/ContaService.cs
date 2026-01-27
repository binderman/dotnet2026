using exemplo.model;

namespace exemplo.service;

public class ContaService
{
    private readonly Agencia _agencia;

    public ContaService()
    {
        _agencia = AgenciaFactory.CriarAgenciaComMockupData();
    }

    public List<ContaCorrente> ListarContas()
    {
        return _agencia.ListarContas();
    }

    public ContaCorrente CriarConta(int numero, string titular, string senha, double saldoInicial)
    {
        var conta = new ContaCorrente(numero, titular, senha);
        
        if (saldoInicial > 0)
        {
            conta.Depositar(saldoInicial);
        }

        _agencia.AbrirConta(conta);
        return conta;
    }

    public ContaCorrente? BuscarConta(int numero)
    {
        return _agencia.BuscarConta(numero);
    }

    public void Depositar(ContaCorrente conta, double valor)
    {
        conta.Depositar(valor);
    }

    public void Sacar(ContaCorrente conta, double valor)
    {
        conta.Sacar(valor);
    }

    public bool RemoverConta(int numero)
    {
        return _agencia.RemoverConta(numero);
    }

    public void AlterarTitular(ContaCorrente conta, string novoTitular)
    {
        conta.Titular = novoTitular;
    }
}
