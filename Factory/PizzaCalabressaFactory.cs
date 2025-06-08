using PizzaFactoryNamespace;
using PizzasNamespace;
using PizzaCalabresaNamespace;

namespace PizzaCalabressaFactoryNamespace
{
    public class PizzaCalabressaFactory : PizzaFactory
    {
        public override Pizza CriaPizza()
        {
            return new PizzaCalabresa();
        }
    }
}