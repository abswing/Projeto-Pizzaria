using Xunit;
using PizzaCalabresaNamespace;
using PizzaMussarelaNamespace;
using PizzasDecoratorNamespace;
using PizzasNamespace;
using PagamentoNamespace;

public class DecoratorAndPagamentoTests
{
    [Fact]
    public void QueijoExtraDecorator_DeveAdicionarCincoReaisAoPreco()
    {
        Pizza pizza = new PizzaCalabresa();
        decimal precoOriginal = pizza.Preco();
        pizza = new QueijoExtraDecorator(pizza);
        decimal precoComQueijo = pizza.Preco();
        Assert.Equal(precoOriginal + 5.00m, precoComQueijo);
    }

    [Fact]
    public void QueijoExtraDecorator_PrepararAdicionaMensagem()
    {
        Pizza pizza = new PizzaMussarela();
        pizza = new QueijoExtraDecorator(pizza);
        string preparo = pizza.Preparar();
        Assert.Contains("Adicionando queijo extra", preparo);
    }

    [Fact]
    public void PagamentoAdapter_DeveChamarServicoPagamento()
    {
        
        var servicoPagamento = new PagamentoServicoFake();
        Pagamentos pagamento = new PagamentoAdapter(servicoPagamento);
        decimal valor = 42.50m;
        
        pagamento.Pagar(valor.ToString());
        
        Assert.True(servicoPagamento.PagamentoEfetuado);
        Assert.Equal(valor.ToString(), servicoPagamento.ValorPago);
    }

    //para testar o Adapter 
    private class PagamentoServicoFake : PagamentoServico
    {
        public bool PagamentoEfetuado { get; private set; } = false;
        public string ValorPago { get; private set; } = string.Empty;
        public override void EfetuarPagamento(string quantia)
        {
            PagamentoEfetuado = true;
            ValorPago = quantia;
        }
    }
}
