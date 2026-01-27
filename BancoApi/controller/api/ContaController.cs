using Microsoft.AspNetCore.Mvc;
using exemplo.model;
using exemplo.service;

namespace exemplo.controller.api;

[ApiController]
[Route("api/[controller]")]
public class ContaController : ControllerBase
{
    private readonly ContaService _contaService;

    // Construtor que recebe o ContaService via injeção de dependência
    public ContaController(ContaService contaService)
    {
        _contaService = contaService;
    }

    /// <summary>
    /// GET /api/conta - Lista todas as contas correntes cadastradas na agência
    /// Retorna um array com número, titular e saldo de cada conta
    /// </summary>
    [HttpGet]
    public IActionResult ListarContas()
    {
        // Busca todas as contas através do serviço
        var contas = _contaService.ListarContas();
        // Projeta apenas os dados necessários para a resposta usando foreach
        var resultado = new List<object>();
        foreach (var c in contas)
        {
            resultado.Add(new {
                numero = c.Numero,
                titular = c.Titular,
                saldo = c.ConsultarSaldo()
            });
        }
        
        return Ok(resultado);
    }

    /// <summary>
    /// POST /api/conta - Cria uma nova conta corrente
    /// Recebe número, titular, senha e saldo inicial (opcional)
    /// Retorna 201 Created com os dados da conta criada
    /// </summary>
    [HttpPost]
    public IActionResult CriarConta([FromBody] ContaCorrenteRequest request)
    {
        try
        {
            // Delega a criação da conta para o serviço
            var conta = _contaService.CriarConta(
                request.Numero, 
                request.Titular, 
                request.Senha, 
                request.SaldoInicial
            );

            // Retorna 201 Created com link para consultar a conta criada
            return CreatedAtAction(
                nameof(ConsultarSaldo), 
                new { numero = conta.Numero }, 
                new { 
                    numero = conta.Numero,
                    titular = conta.Titular,
                    saldo = conta.ConsultarSaldo()
                });
        }
        catch (ArgumentException ex)
        {
            // Retorna 400 Bad Request se houver erro de validação
            return BadRequest(new { erro = ex.Message });
        }
    }

    /// <summary>
    /// GET /api/conta/{numero}/saldo - Consulta o saldo de uma conta específica
    /// Retorna 404 se a conta não existir
    /// </summary>
    [HttpGet("{numero}/saldo")]
    public IActionResult ConsultarSaldo(int numero)
    {
        // Busca a conta pelo número
        var conta = _contaService.BuscarConta(numero);
        if (conta == null)
        {
            return NotFound(new { erro = "Conta não encontrada" });
        }

        // Retorna os dados da conta com o saldo atual
        return Ok(new { 
            numero = conta.Numero,
            titular = conta.Titular,
            saldo = conta.ConsultarSaldo()
        });
    }

    /// <summary>
    /// POST /api/conta/{numero}/depositar - Realiza um depósito na conta
    /// Recebe o valor a ser depositado no corpo da requisição
    /// Retorna o novo saldo após o depósito
    /// </summary>
    [HttpPost("{numero}/depositar")]
    public IActionResult Depositar(int numero, [FromBody] OperacaoRequest request)
    {
        // Verifica se a conta existe
        var conta = _contaService.BuscarConta(numero);
        if (conta == null)
        {
            return NotFound(new { erro = "Conta não encontrada" });
        }

        try
        {
            // Executa o depósito através do serviço
            _contaService.Depositar(conta, request.Valor);
            return Ok(new { 
                mensagem = "Depósito realizado com sucesso",
                numero = conta.Numero,
                saldo = conta.ConsultarSaldo()
            });
        }
        catch (ArgumentException ex)
        {
            // Retorna erro se o valor for inválido
            return BadRequest(new { erro = ex.Message });
        }
    }

    /// <summary>
    /// POST /api/conta/{numero}/sacar - Realiza um saque da conta
    /// Recebe o valor a ser sacado no corpo da requisição
    /// Valida se há saldo suficiente antes de realizar o saque
    /// </summary>
    [HttpPost("{numero}/sacar")]
    public IActionResult Sacar(int numero, [FromBody] OperacaoRequest request)
    {
        // Verifica se a conta existe
        var conta = _contaService.BuscarConta(numero);
        if (conta == null)
        {
            return NotFound(new { erro = "Conta não encontrada" });
        }

        try
        {
            // Executa o saque através do serviço
            _contaService.Sacar(conta, request.Valor);
            return Ok(new { 
                mensagem = "Saque realizado com sucesso",
                numero = conta.Numero,
                saldo = conta.ConsultarSaldo()
            });
        }
        catch (ArgumentException ex)
        {
            // Retorna erro se o valor for inválido ou saldo insuficiente
            return BadRequest(new { erro = ex.Message });
        }
    }

    /// <summary>
    /// DELETE /api/conta/{numero} - Remove uma conta da agência
    /// Retorna 404 se a conta não existir
    /// </summary>
    [HttpDelete("{numero}")]
    public IActionResult RemoverConta(int numero)
    {
        // Tenta remover a conta através do serviço
        var removida = _contaService.RemoverConta(numero);
        if (!removida)
        {
            return NotFound(new { erro = "Conta não encontrada" });
        }

        return Ok(new { mensagem = "Conta removida com sucesso", numero });
    }

    /// <summary>
    /// PUT /api/conta/{numero}/titular - Altera o titular de uma conta
    /// Recebe o novo nome do titular no corpo da requisição
    /// </summary>
    [HttpPut("{numero}/titular")]
    public IActionResult AlterarTitular(int numero, [FromBody] TitularRequest request)
    {
        // Verifica se a conta existe
        var conta = _contaService.BuscarConta(numero);
        if (conta == null)
        {
            return NotFound(new { erro = "Conta não encontrada" });
        }

        // Altera o titular através do serviço
        _contaService.AlterarTitular(conta, request.NovoTitular);
        
        return Ok(new { 
            mensagem = "Titular alterado com sucesso",
            numero = conta.Numero,
            titular = conta.Titular
        });
    }
}

public record ContaCorrenteRequest(
    int Numero,
    string Titular,
    string Senha,
    double SaldoInicial = 0.0
);

public record OperacaoRequest(
    double Valor
);

public record TitularRequest(
    string NovoTitular
);
