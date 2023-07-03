# GitHubAntiCorruptionAPI

Este é um projeto de exemplo que demonstra como usar a API do GitHub com um serviço de Anti Corrupção.

## Arquitetura

A arquitetura do projeto segue os princípios do SOLID e utiliza as seguintes tecnologias:

- .NET 6
- ASP.NET Core
- Octokit (biblioteca cliente do GitHub)
- XUnit (para testes unitários)
- Dependency Injection (Injeção de Dependência)

O projeto foi estruturado com base em alguns dos princípios do SOLID:

- **Single Responsibility Principle (SRP)**: Cada classe do projeto tem uma única responsabilidade. Por exemplo, a classe `GitHubService` é responsável por interagir com a API do GitHub e fornecer funcionalidades relacionadas.

- **Dependency Inversion Principle (DIP)**: Através da injeção de dependência, as dependências são invertidas e as classes dependem de abstrações em vez de implementações concretas. Por exemplo, a classe `GitHubService` depende da interface `IGitHubClient` em vez de uma implementação específica.

- **Open-Closed Principle (OCP)**: O projeto foi projetado para ser extensível sem a necessidade de modificar o código existente. Por exemplo, é possível adicionar novas funcionalidades à integração com o GitHub criando novas classes que implementam a interface `IGitHubClient`.

Essa abordagem arquitetural promove a separação de responsabilidades, facilita a manutenção do código e permite a extensibilidade do projeto.

## Configuração

Antes de executar o projeto, é necessário fornecer um token de acesso do GitHub no arquivo `appsettings.json`. Siga as etapas abaixo para configurar o token de acesso:

1. Abra o arquivo `appsettings.json` na raiz do projeto.
2. Localize a seção `"GitHub"` e a propriedade `"AccessToken"`.
3. Substitua o valor `"access-token"` pelo seu token de acesso do GitHub.

Exemplo:

```json
"GitHub": {
  "AccessToken": "seu-token-de-acesso"
}
```

## Executando o projeto

Certifique-se de ter o SDK do .NET 6 instalado em sua máquina.

Para executar o projeto, siga as etapas abaixo:

1. Abra um terminal na pasta raiz do projeto.
2. Execute o seguinte comando para restaurar as dependências:

   ```
   dotnet restore
   ```

3. Em seguida, execute o seguinte comando para iniciar o projeto:

   ```
   dotnet run
   ```

   O projeto será executado e estará disponível em `https://localhost:7295`.

## Documentação da API

A documentação da API está disponível através do Swagger. Para acessar a documentação, abra o seu navegador e vá para:

```
https://localhost:7295/swagger/index.html
```

A documentação do Swagger fornecerá detalhes sobre os endpoints disponíveis e permitirá que você teste a API diretamente pelo navegador.

## Executando os testes unitários

Os testes unitários foram implementados usando a estrutura de teste XUnit. Para executar os testes, siga as etapas abaixo:

1. Abra um terminal na pasta raiz do projeto.
2. Execute o seguinte comando para executar os testes:

   ```
   dotnet test
   ```

   Os resultados dos testes serão exibidos no terminal.

## Contribuição

Sinta-se à vontade para contribuir com este projeto abrindo uma issue ou enviando um pull request.
