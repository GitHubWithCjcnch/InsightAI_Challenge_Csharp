# InsightAI

## Integrantes do Grupo

- **[Seu Nome]** (Descrição da função que você desempenha no projeto, ex: Desenvolvimento Backend)
- **[Nome do Integrante 2]** (Descrição da função que desempenha, ex: Desenvolvimento Frontend)
- *(Se houver mais membros, adicione-os aqui)*

---

## Arquitetura do Projeto

Este projeto segue uma arquitetura multicamada (layered architecture), dividida em quatro projetos principais:

1. **InsightAI.Api**: Responsável pela interface HTTP da aplicação, onde as requisições são recebidas e respondidas. Este projeto contém os **controllers** que orquestram o fluxo de dados entre a interface do usuário e o restante do sistema.

2. **InsightAI.Core**: Contém as regras de negócio, **entidades** e **interfaces** da aplicação. Nesta camada, são definidos os contratos que o restante do sistema utiliza para se comunicar com as outras partes, além de definir os modelos de dados e lógica de negócios.

3. **InsightAI.Infrastructure**: Contém a implementação dos serviços de infraestrutura, como **repositórios**, **migrations** e comunicação com bancos de dados. Esta camada utiliza os contratos definidos no Core para garantir a separação de responsabilidades e facilitar a manutenção e testes.

4. **InsightAI.Tests**: Projeto dedicado a testes unitários e de integração, garantindo que todas as partes do sistema funcionem conforme esperado. Aqui, são testados os controllers e serviços definidos nos outros projetos.

### Dependências Utilizadas:
- **ASP.NET Core**: Framework principal utilizado para construir a API.
- **Entity Framework Core**: Utilizado para gerenciamento de banco de dados e Migrations.
- **XUnit**: Framework de testes unitários.

---

## Design Patterns Utilizados

- **Repository Pattern**: Utilizado na camada de infraestrutura para abstrair a interação com o banco de dados e permitir uma comunicação mais fácil entre o Core e o banco de dados.
  
- **Dependency Injection (DI)**: Implementado em toda a aplicação para permitir que as dependências sejam resolvidas automaticamente, facilitando a testabilidade e a troca de implementações.
  
- **Factory Pattern**: Utilizado para criar objetos sem expor a lógica de criação diretamente ao cliente. Este padrão permite criar objetos complexos em diferentes cenários sem alterar o código cliente.

- **Service Layer**: Aplicado na camada de Core para encapsular a lógica de negócio, separando-a das preocupações de infraestrutura e interface.

- **Singleton Pattern**: aplicado em apenas uma única service para entendimento de como funciona (no caso a service de Usuarios)
---

### Configurações

1. Clone o repositório do projeto:
   ```bash
   git clone https://github.com/seu-usuario/InsightAI.git

2. Abra o projeto em sua IDE de preferência (como Visual Studio ou VS Code).

3. Configuração da Connection String:
    Se necessário, edite o arquivo appsettings.json e altere a Connection String para o banco de dados correto. Por padrão, ela está configurada para uma conta de estudante:

4. Rodando as Migrations:

    Para rodar as migrations corretamente, é necessário trocar o projeto de migrações para InsightAI.Infraestructure, onde as classes de contexto e as migrations estão configuradas. Você pode fazer isso de duas formas:

    Usando o Gerenciador de Pacotes do Visual Studio:
    No Visual Studio, vá em Ferramentas > Gerenciador de Pacotes NuGet > Console do Gerenciador de Pacotes.
    No console, altere o projeto padrão para InsightAI.Infraestructure utilizando o menu suspenso localizado no canto superior direito do console.
    Depois, execute o seguinte comando para aplicar as migrations:
   ```bash
   Add-Migration FirstMigration
   Update-Database
   
   - Usando a Linha de Comando:
     Você também pode rodar o comando via terminal ou Prompt de Comando, certificando-se de estar no diretório raiz do projeto. Utilize o seguinte comando para adicionar ou aplicar as migrations:

     ```bash
        dotnet ef migrations add InitialCreate -p InsightAI.Infraestructure -s InsightAI.Api
        dotnet ef database update -p InsightAI.Infraestructure -s InsightAI.Api
        dotnet run --project InsightAI.Api
