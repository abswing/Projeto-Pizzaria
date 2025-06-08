using Xunit;
using PizzaCalabressaFactoryNamespace;
using PizzaMussarelaFactoryNamespace;
using PizzaCalabresaNamespace;
using PizzaMussarelaNamespace;
public class PizzaFactoryTests
{
    [Fact] 
    public void PizzaCalabressaFactory_DeveCriarPizzaCalabresa()
    {
        var factory = new PizzaCalabressaFactory();
        var pizza = factory.CriaPizza();
        Assert.IsType<PizzaCalabresa>(pizza);
    }

    [Fact]
    public void PizzaMussarelaFactory_DeveCriarPizzaMussarela()
    {
        var factory = new PizzaMussarelaFactory();
        var pizza = factory.CriaPizza();
        Assert.IsType<PizzaMussarela>(pizza);
    }
}