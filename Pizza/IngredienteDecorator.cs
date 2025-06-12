using PizzasNamespace;

namespace PizzasDecoratorNamespace
{
    // Decorator base para ingredientes extras
    public abstract class IngredienteDecorator : Pizza
    {
        protected Pizza pizza;

        public IngredienteDecorator(Pizza pizza)
        {
            this.pizza = pizza;
        }

        public override decimal Preco()
        {
            return pizza.Preco();
        }

        public override string Preparar()
        {
            return pizza.Preparar();
        }
    }
}
