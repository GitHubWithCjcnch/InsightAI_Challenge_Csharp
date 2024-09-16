# InsightAI

## Integrantes do Grupo

- **[Seu Nome]** (Descri��o da fun��o que voc� desempenha no projeto, ex: Desenvolvimento Backend)
- **[Nome do Integrante 2]** (Descri��o da fun��o que desempenha, ex: Desenvolvimento Frontend)
- *(Se houver mais membros, adicione-os aqui)*

---

## Arquitetura do Projeto

Este projeto segue uma arquitetura multicamada (layered architecture), dividida em quatro projetos principais:

1. **InsightAI.Api**: Respons�vel pela interface HTTP da aplica��o, onde as requisi��es s�o recebidas e respondidas. Este projeto cont�m os **controllers** que orquestram o fluxo de dados entre a interface do usu�rio e o restante do sistema.

2. **InsightAI.Core**: Cont�m as regras de neg�cio, **entidades** e **interfaces** da aplica��o. Nesta camada, s�o definidos os contratos que o restante do sistema utiliza para se comunicar com as outras partes, al�m de definir os modelos de dados e l�gica de neg�cios.

3. **InsightAI.Infrastructure**: Cont�m a implementa��o dos servi�os de infraestrutura, como **reposit�rios**, **migrations** e comunica��o com bancos de dados. Esta camada utiliza os contratos definidos no Core para garantir a separa��o de responsabilidades e facilitar a manuten��o e testes.

4. **InsightAI.Tests**: Projeto dedicado a testes unit�rios e de integra��o, garantindo que todas as partes do sistema funcionem conforme esperado. Aqui, s�o testados os controllers e servi�os definidos nos outros projetos.

### Depend�ncias Utilizadas:
- **ASP.NET Core**: Framework principal utilizado para construir a API.
- **Entity Framework Core**: Utilizado para gerenciamento de banco de dados e Migrations.
- **XUnit**: Framework de testes unit�rios.

---

## Design Patterns Utilizados

- **Repository Pattern**: Utilizado na camada de infraestrutura para abstrair a intera��o com o banco de dados e permitir uma comunica��o mais f�cil entre o Core e o banco de dados.
  
- **Dependency Injection (DI)**: Implementado em toda a aplica��o para permitir que as depend�ncias sejam resolvidas automaticamente, facilitando a testabilidade e a troca de implementa��es.
  
- **Factory Pattern**: Utilizado para criar objetos sem expor a l�gica de cria��o diretamente ao cliente. Este padr�o permite criar objetos complexos em diferentes cen�rios sem alterar o c�digo cliente.

- **Service Layer**: Aplicado na camada de Core para encapsular a l�gica de neg�cio, separando-a das preocupa��es de infraestrutura e interface.

- **Singleton Pattern**: aplicado em apenas uma �nica service para entendimento de como funciona (no caso a service de Usuarios)
---

### Configura��es

1. Clone o reposit�rio do projeto:
   ```bash
   git clone https://github.com/seu-usuario/InsightAI.git

2. Abra o projeto em sua IDE de prefer�ncia (como Visual Studio ou VS Code).

3. Configura��o da Connection String:
    Se necess�rio, edite o arquivo appsettings.json e altere a Connection String para o banco de dados correto. Por padr�o, ela est� configurada para uma conta de estudante:

4. Rodando as Migrations:

    Para rodar as migrations corretamente, � necess�rio trocar o projeto de migra��es para InsightAI.Infraestructure, onde as classes de contexto e as migrations est�o configuradas. Voc� pode fazer isso de duas formas:

    Usando o Gerenciador de Pacotes do Visual Studio:
    No Visual Studio, v� em Ferramentas > Gerenciador de Pacotes NuGet > Console do Gerenciador de Pacotes.
    No console, altere o projeto padr�o para InsightAI.Infraestructure utilizando o menu suspenso localizado no canto superior direito do console.
    Depois, execute o seguinte comando para aplicar as migrations:
   ```bash
   Add-Migration FirstMigration
   Update-Database
   
   - Usando a Linha de Comando:
     Voc� tamb�m pode rodar o comando via terminal ou Prompt de Comando, certificando-se de estar no diret�rio raiz do projeto. Utilize o seguinte comando para adicionar ou aplicar as migrations:

     ```bash
        dotnet ef migrations add InitialCreate -p InsightAI.Infraestructure -s InsightAI.Api
        dotnet ef database update -p InsightAI.Infraestructure -s InsightAI.Api
        dotnet run --project InsightAI.Api
