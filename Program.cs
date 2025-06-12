using PagamentoNamespace;


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
        int opcao;
        while (true)
        {
            Console.WriteLine("Digite o número da pizza que você deseja preparar:");
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out opcao) || (opcao != 1 && opcao != 2))
            {
                Console.WriteLine("Opção inválida. Por favor, escolha 1 ou 2.");
                continue;
            }
            break;
        }

        PizzaFactory pizzaFactory = (opcao == 1)
            ? new PizzaCalabressaFactory()
            : new PizzaMussarelaFactory();
        Console.WriteLine("====================================================\n");

        Pizza pizzaEscolhida = pizzaFactory.CriaPizza();
        Console.WriteLine("Deseja adicionar queijo extra por R$5,00? (S/N)");
        string? extraInput = Console.ReadLine();
        if (extraInput?.Trim().ToUpper() == "S")
        {
            pizzaEscolhida = new PizzasDecoratorNamespace.QueijoExtraDecorator(pizzaEscolhida);
        }
        else if (extraInput?.Trim().ToUpper() != "N")
        {
            Console.WriteLine("Prosseguindo sem queijo extra.");
        }
        Console.WriteLine("Você escolheu a opção " + opcao + ". Preço dessa pizza é: R$" + pizzaEscolhida.Preco() + "\n");

        string? pagamentoInput;
        while (true)
        {
            Console.WriteLine("Deseja efetuar o pagamento? (S/N)");
            pagamentoInput = Console.ReadLine();
            if (pagamentoInput?.Trim().ToUpper() == "S")
            {
                var servicoPagamento = new PagamentoServico();
                Pagamentos pagamento = new PagamentoAdapter(servicoPagamento);
                pagamento.Pagar(pizzaEscolhida.Preco().ToString());
                Console.WriteLine(pizzaEscolhida.Preparar());
                break;
            }
            else if (pagamentoInput?.Trim().ToUpper() == "N")
            {
                Console.WriteLine("Pagamento não realizado. Você pode pagar na retirada.");
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida. Por favor, responda S ou N.");
            }
        }
        Console.WriteLine("====================================================\n");
        Console.WriteLine("Obrigado por escolher nossa pizzaria! Volte sempre!");
    }
}