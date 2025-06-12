using PizzasNamespace;

namespace PizzaMussarelaNamespace
{
    public class PizzaMussarela : Pizza
    {
        public PizzaMussarela()
        {
            Nome = "Pizza Mussarela";
            massa = "Massa fina crocante";
            molho = "Molho de tomate italiano";
            ingredientes.Add("Queijo mussarela");
            ingredientes.Add("Orégano");
        }

        public override decimal Preco()
        {
            return 35.00m;
        }
    }
}