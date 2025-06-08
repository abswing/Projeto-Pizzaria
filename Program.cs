using PizzasNamespace;
using PizzaCalabressaFactoryNamespace;
using PizzaMussarelaFactoryNamespace;
using PizzaFactoryNamespace;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n");
        Console.WriteLine("Bem-vindo à Pizzaria!");
        Console.WriteLine("====================================================\n");
        Console.WriteLine("Hoje temos as seguintes pizzas disponíveis:\n");
        Console.WriteLine("====================================================\n");
        Console.WriteLine("1. Pizza Calabresa");
        Console.WriteLine("2. Pizza Mussarela\n");
        Console.WriteLine("====================================================\n");
        Console.WriteLine("Digite o número da pizza que você deseja preparar:");
        string? input = Console.ReadLine();
        int opcao;
        if (!int.TryParse(input, out opcao))
        {
            Console.WriteLine("Entrada inválida. Encerrando o programa.");
            return;
        }

        PizzaFactory pizzaFactory;

        if (opcao == 1)
        {
            pizzaFactory = new PizzaCalabressaFactory();
        }
        else if (opcao == 2)
        {
            pizzaFactory = new PizzaMussarelaFactory();
        }
        else
        {         
            Console.WriteLine("Opção inválida. Por favor, escolha 1 ou 2.");
            Console.WriteLine("Encerrando o programa.");
            return;
        }

        Pizza pizzaEscolhida = pizzaFactory.CriaPizza();
        Console.WriteLine(pizzaEscolhida.Preparar());
        Console.WriteLine("====================================================\n");
        Console.WriteLine("Obrigado por escolher nossa pizzaria! Volte sempre!");
    }
}