# GitHubAntiCorruptionAPI

Este é um projeto de exemplo que demonstra como usar a API do GitHub com um serviço de Anti Corrupção.

## Arquitetura

A arquitetura do projeto segue os princípios do SOLID (SRP, OCP, LSP, ISP, DIP) e utiliza as seguintes tecnologias:

- .NET 6
- ASP.NET Core
- Octokit (biblioteca cliente do GitHub)
- XUnit (para testes unitários)
- Dependency Injection (Injeção de Dependência)

A estrutura do projeto é a seguinte:

- `Controllers`: contém os controladores do ASP.NET Core que definem as rotas da API.
- `Services`: contém a classe `GitHubService`, que encapsula a lógica para interagir com a API do GitHub.
- `Tests`: contém os testes unitários para o serviço `GitHubService`.

## Configuração

Antes de executar o projeto, você precisa fornecer um token de acesso do GitHub no arquivo `appsettings.json`. Siga as etapas abaixo para configurar o token de acesso:

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
