# DesafioEnquete
Desafio de desenvolver uma API para criar e usar enquetes.

### Ferramentas utilizadas
Foi utilizado .NET Core para desenvolver este projeto e Enitity Framework para criar o banco de dados com migrações code-first. 
O Banco de dados utilizado foi o SQL Server. A IDE utilizada foi o Visual Studio 2019.

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

##### 4. Endpoints
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
  
  
## English

### Utilized Tools
To develop this project, it was utilized .NET Core and Entity Framework Core to create the database with code-first migrations. The
utilized database was Sql Server. The used IDE was Visual Studio 2019.

### Steps to Install/Run the project 
##### 1. Recover dependencies using Nuget
Open the solution on Visual Studio 2019 and then open Nuget Package Manager Console. It will notify you that some packages are missing in the project 
and will give you the option to download the dependencies.

##### 2. Configure the Database
I Recommend two alternatives to configure the database:

- Running the ScriptDatabase.sql file (available on the root directory of the project) on a SqlServer database. Configure the appsetting.json 
file to point to this new database.
- Generate the database from Nuget Package Manager using Entity Framework Core migrations. To do this, type the `update-database` command in the Nuget Package Manager Console. This will create a new database in the local Server `(LocalDb)\MSSQLLocalDB`. 

##### 3. Run the project
Run the project by clicking on the Run button on Visual Studio. You can also generate a publish from the API and deploy it on IIS, for example.

##### 4. Endpoints
* GetPoll
  * Method: GET
  * Example URL: https://localhost/api/Poll/5
  * json body: Does not apply.
* GetPolls
  * Method: GET
  * Example URL: https://localhost/api/Poll
  * json body: Does not apply.
* PostPoll
  * Method: POST
  * Example URL: https://localhost/api/Poll
  * json body: 
  ```
  {
    "PollDescription": "What do you think of Harry Potter?",
    "Options": [
      {
          "OptionDescription": "Good"
      },
      {
          "OptionDescription": "Great!"
      },
      {
          "OptionDescription": "Bad"
      },
      {
          "OptionDescription": "Terrible"
      }
    ]
  }
  ```  
* DeletePoll
  * Method: Delete
  * Example URL: https://localhost/api/Poll/4
  * Json Body: Does not apply.
* Vote  
  * Método: Post
  * Example Url: https://localhost/api/Poll/1/Vote
  * Json Body: Does not apply. To vote send the option Id in the URL. (In this example the ID is 1)
* Stats
  * Method: GET
  * Example Url: https://localhost/api/Poll/6/Stats
  * Json Body: Does not apply.
  
