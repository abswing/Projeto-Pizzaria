namespace Pizza
{
    // Classe que representa uma pizza de calabresa
    // Esta classe herda da classe Pizza e define os detalhes específicos da pizza de calabresa
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