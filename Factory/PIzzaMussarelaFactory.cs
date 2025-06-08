using PizzaFactoryNamespace;
using PizzasNamespace;
using PizzaMussarelaNamespace;

namespace PizzaMussarelaFactoryNamespace
{
    public class PizzaMussarelaFactory : PizzaFactory
    {
        public override Pizza CriaPizza()
        {
            return new PizzaMussarela();
        }
    }
}