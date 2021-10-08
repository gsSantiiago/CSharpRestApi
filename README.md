# CSharpRestApi
## Exemplo de uma Api Rest em C#
A api trás exemplos de operações CRUD de um servidor, além de testes de conexão do servidor e cadastro de vídeos.
O projeto foi criado utilizando o template `webapi` através do comando `dotnet new webapi --no-https`.

## Instalação
O projeto necessita a instalação do .NET para executar.

Compilar projeto e suas dependências.
```
$ dotnet build
```
Configurar `.env` file.
```
DATABASE={nome_do_banco_de_dados}
MONGO_URI={string_de_conexao_do_banco_mongo}
```

## Execução
Executar o projeto.
```
$ dotnet run
```
Ao final do comando o projeto estará rodando em `http://localhost:5000/`.

## Rotas
Para testar o projeto estão disponíveis as rotas abaixo.

| Ação | Método | Rota |
| ---- | ------ | ---- |
| Criar um novo servidor | POST | /api/server |
| Remover um servidor existente | DELETE | /api/servers/{serverId} |
| Recuperar um servidor existente | GET | /api/servers/{serverId} |
| Checar disponibilidade de um servidor | GET | /api/servers/available/{serverId} |
| Listar todos os servidores | GET | /api/servers |
| Adicionar um novo vídeo à um servidor | POST | /api/servers/{serverId}/videos |
| Remover um vídeo existente | DELETE | /api/servers/{serverId}/videos/{videoId} |
| Recuperar dados cadastrais de um vídeo | GET | /api/servers/{serverId}/videos/{videoId} |
| Download do conteúdo binário de um vídeo | GET | /api/servers/{serverId}/videos/{videoId}/binary |
| Listar todos os vídeos de um servidor | GET | /api/servers/{serverId}/videos |
| Reciclar vídeos antigos | POST | /api/recycler/process/{days} |
| Checar status da recliclagem de vídeos | GET | /api/recycler/status |
