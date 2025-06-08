using PizzasNamespace;

namespace PizzaCalabresaNamespace
{
    public class PizzaCalabresa : Pizza
    {
        public PizzaCalabresa()
        {
            Nome = "Pizza Calabresa";
            massa = "Massa fina crocante";
            molho = "Molho de tomate italiano";
            ingredientes.Add("Queijo mussarela");
            ingredientes.Add("Calabresa");
        }
    }
}