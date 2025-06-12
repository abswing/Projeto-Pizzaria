# Projeto Pizzaria

## 1ª Entrega: Padrões Criacionais

### Objetivo

Implementar uma solução inicial utilizando um padrão de projeto criacional, com código-fonte funcional, testes automatizados e documentação clara.

---

## Padrão de Projeto Utilizado

***Factory Method**

### Por que escolhi esse padrão?

O padrão Factory Method permite criar objetos (neste caso, diferentes tipos de pizzas e eu vi um video no youtube) sem acoplar o código principal às classes concretas. Isso facilita a extensão do sistema para novos sabores de pizza, mantendo o código organizado e flexível.

### Como foi implementado?

- Criamos uma interface/fábrica abstrata `PizzaFactory` com o método `CriaPizza()`.
- Cada tipo de pizza possui sua própria fábrica concreta (`PizzaCalabressaFactory`, `PizzaMussarelaFactory`), que implementa o método de criação.
- O código principal utiliza a fábrica para criar a pizza escolhida pelo usuário, sem depender das classes concretas.

#### Exemplo de código

```csharp
// Seleção da fábrica conforme a escolha do usuário
PizzaFactory pizzaFactory;

if (opcao == 1)
    pizzaFactory = new PizzaCalabressaFactory();
else if (opcao == 2)
    pizzaFactory = new PizzaMussarelaFactory();
else
    // tratamento de erro

Pizza pizzaEscolhida = pizzaFactory.CriaPizza();
Console.WriteLine(pizzaEscolhida.Preparar());
```

---

## 2ª Entrega: Padrões Estruturais

### objetivo

Incrementar o projeto com componentes estruturais que favoreçam reutilização e flexibilidade, utilizando pelo menos dois padrões estruturais.

---

## Padrões Estruturais Utilizados

### Adapter

**Por que?**
Permite integrar um serviço externo de pagamento ao sistema, adaptando sua interface para a interface esperada pelo sistema.

**Como foi implementado?**

- Criamos a interface `Pagamentos` com o método `Pagar`.
- O serviço externo (`ServicoPagamento`) possui uma interface diferente.
- O `PagamentoAdapter` implementa a interface do sistema e faz a ponte com o serviço externo.

**Exemplo de código:**

```csharp
var servicoPagamento = new PagamentoServico();
Pagamentos pagamento = new PagamentoAdapter(servicoPagamento);
pagamento.Pagar(pizzaEscolhida.Preco().ToString());
```

### Decorator

**Por que?**
Permite adicionar ingredientes extras à pizza de forma flexível, sem criar subclasses para cada combinação.

**Como foi implementado?**

- Criamos a classe abstrata `IngredienteDecorator` que herda de `Pizza`.
- Cada ingrediente extra (ex: `QueijoExtraDecorator`) herda de `IngredienteDecorator` e incrementa o preço e a descrição do preparo.

**Exemplo de código:**

```csharp
Pizza pizza = new PizzaCalabresa();
pizza = new QueijoExtraDecorator(pizza);
Console.WriteLine(pizza.Preparar());
Console.WriteLine($"Preço: R${pizza.Preco()}");
```

---

## Testes Unitários

Os testes automatizados estão no projeto `ProjetoPizzaria.Tests` e validam:

- Se cada fábrica está criando corretamente o tipo de pizza esperado.
- Se o decorator de queijo extra soma corretamente ao preço e adiciona a mensagem no preparo.
- Se o adapter de pagamento chama corretamente o serviço externo.

**Exemplo de teste do factory:**

```csharp
[Fact]
public void PizzaCalabressaFactory_DeveCriarPizzaCalabresa()
{
    var factory = new PizzaCalabressaFactory();
    var pizza = factory.CriaPizza();
    Assert.IsType<PizzaCalabresa>(pizza);
}

```

**Exemplo de teste do decorator:**

```csharp
[Fact]
public void QueijoExtraDecorator_DeveAdicionarCincoReaisAoPreco()
{
    Pizza pizza = new PizzaCalabresa();
    decimal precoOriginal = pizza.Preco();
    pizza = new QueijoExtraDecorator(pizza);
    decimal precoComQueijo = pizza.Preco();
    Assert.Equal(precoOriginal + 5.00m, precoComQueijo);
}

```

**Exemplo de teste do adapter:**

```csharp
[Fact]
public void PagamentoAdapter_DeveChamarServicoPagamento()
{
    var servicoPagamento = new PagamentoServicoFake();
    Pagamentos pagamento = new PagamentoAdapter(servicoPagamento);
    decimal valor = 42.50m;
    pagamento.Pagar(valor.ToString());
    Assert.True(servicoPagamento.PagamentoEfetuado);
    Assert.Equal(valor.ToString(), servicoPagamento.ValorPago);
}

```

---

## Como executar

- ***Para rodar o projeto principal:***

  ```sh

  dotnet run 

  ```

- ***Para rodar os testes:***

  ```sh
  
  dotnet test 
  ```

---

## Estrutura do Projeto

│   Pizzaria.csproj
│   Pizzaria.sln
│   Program.cs
│   README.md
│
├───Factory/
│       PizzaCalabressaFactory.cs
│       PizzaFactory.cs
│       PIzzaMussarelaFactory.cs
│
│
├───Pagamento/
│       Pagamento.cs
│       PagamentoAdapter.cs
│       ServicoPagamento.cs
│
├───Pizza/
│       IngredienteDecorator.cs
│       Pizza.cs
│       PizzaCalabresa.cs
│       PizzaMussarela.cs
│       QueijoExtraDecorator.cs
│
└───ProjetoPizzaria.Tests/
    │   DecoratorAndPagamentoTests.cs
    │   PizzaFactoryTests.cs
    │   ProjetoPizzaria.Tests.csproj
    │
    └───
