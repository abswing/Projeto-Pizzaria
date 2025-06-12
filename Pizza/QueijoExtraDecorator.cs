using PizzasNamespace;

namespace PizzasDecoratorNamespace
{
    public class QueijoExtraDecorator : IngredienteDecorator
    {
        public QueijoExtraDecorator(Pizza pizza) : base(pizza) { }

        public override decimal Preco()
        {
            // Adiciona R$5,00 ao preço da pizza original
            return pizza.Preco() + 5.00m;
        }

        public override string Preparar()
        {
            return pizza.Preparar() + "Adicionando queijo extra.\n";
        }
    }
}
