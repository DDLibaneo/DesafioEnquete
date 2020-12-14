# DesafioEnquete
Desafio de desenvolver uma API para criar e usar enquetes.

### Ferramentas utilizadas
Foi utilizado .NET Core para desenvolver este projeto e Enitity Framework para criar o banco de dados com migrações code-first. 
O Banco de dados utilizado foi o SQL Server.

### Passos para instalar/rodar o projeto
##### 1. Recuperar dependencias pelo Nuget
Abra a solução no Visual Studio e em seguida abra o Nuget Package Manager Console. Ele notificará que algumas packages estão faltando 
no projeto e dará a opção de baixar as dependencias.

##### 2. Configurar o Banco de dados
Recomendo duas alternativas para configurar o banco:

- Criar uma base de dados pelo SQL Server Management Studio e rodando nela o arquivo ScriptDatabase.sql (disponível na raíz do projeto). Configure o appsettings.json para apontar para esse banco.
- Gerar o banco de dados pelo Nuget Package Manager usando as migrations do Entity Framework. Para isso no Nuget Package Manager Console 
digite o comando `update-database`. Isso irá criar uma base de dados no Servidor local `(LocalDb)\MSSQLLocalDB`.

##### 3. Rode o projeto
Rode o projeto clicando no botão Run do Visual Studio. Você pode tambem gerar um publish da API e subir no IIS por exemplo.

##### 5. Endpoints
* GetPoll
  * Método: GET
  * Url exemplo: https://localhost/api/Poll/5
  * Corpo json: Não tem.
* GetPolls
  * Método: GET
  * Url exemplo: https://localhost/api/Poll
  * Corpo json: Não tem.
* PostPoll
  * Método: POST
  * Url exemplo: https://localhost/api/Poll
  * Corpo json: 
  ```
  {
    "PollDescription": "O que vc acha de Harry Potter?",
    "Options": [
      {
          "OptionDescription": "Bom"
      },
      {
          "OptionDescription": "Show!"
      },
      {
          "OptionDescription": "Ruim"
      },
      {
          "OptionDescription": "Ruinzao"
      }
    ]
  }
  ```  
* DeletePoll
  * Método: Delete
  * Url exemplo: https://localhost/api/Poll/4
  * Corpo Json: Não tem   
* Vote  
  * Método: Post
  * Url exemplo: https://localhost/api/Poll/1/Vote
  * Corpo Json: Não tem. Para votar envie o id da Option na url. (No exemplo acima o Id é 1)
* Stats
  * Método: GET
  * Url exemplo: https://localhost/api/Poll/6/Stats
  * Corpo Json: Não tem.
  
