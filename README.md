# Projeto Pizzaria

## 1ª Entrega: Padrões Criacionais

### Objetivo

Implementar uma solução inicial utilizando um padrão de projeto criacional, com código-fonte funcional, testes automatizados e documentação clara.

---

## Padrão de Projeto Utilizado

**Factory Method**

### Por que escolhi esse padrão?

O padrão Factory Method permite criar objetos (neste caso, diferentes tipos de pizzas) sem acoplar o código principal às classes concretas. Isso facilita a extensão do sistema para novos sabores de pizza, mantendo o código organizado e flexível.

### Como foi implementado?

- Criamos uma interface/fábrica abstrata `PizzaFactory` com o método `CriaPizza()`.
- Cada tipo de pizza possui sua própria fábrica concreta (`PizzaCalabressaFactory`, `PizzaMussarelaFactory`), que implementa o método de criação.
- O código principal utiliza a fábrica para criar a pizza escolhida pelo usuário, sem depender das classes concretas.

#### Exemplo de código:

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

## Testes Unitários

Os testes automatizados estão no projeto `ProjetoPizzaria.Tests` e validam se cada fábrica está criando corretamente o tipo de pizza esperado:

```csharp
[Fact]
public void PizzaCalabressaFactory_DeveCriarPizzaCalabresa()
{
    var factory = new PizzaCalabressaFactory();
    var pizza = factory.CriaPizza();
    Assert.IsType<PizzaCalabresa>(pizza);
}
```

---

## Como executar

- Para rodar o projeto principal:
  ```sh
  dotnet run --project Pizzaria.csproj
  ```
- Para rodar os testes:
  ```sh
  dotnet test ProjetoPizzaria.Tests/ProjetoPizzaria.Tests.csproj
  ```

---

## Estrutura do Projeto

```
Projeto-Pizzaria/
├── Factory/
├── Pizza/
├── ProjetoPizzaria.Tests/
│   └── PizzaFactoryTests.cs
├── Program.cs
├── Pizzaria.csproj
└── README.md
```
