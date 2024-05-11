![Texto alternativo](https://raw.githubusercontent.com/Julianavdsantos/Cadastro-de-Clientes/master/TelaEmccamp.png)

Projeto CRUD de Cadastro de Usuários
Este projeto é uma aplicação web para gerenciar o cadastro de usuários, utilizando operações CRUD (Create, Read, Update, Delete) para manipulação dos dados com Api, incluindo campos de pesquisa de usuário com base em termos de busca e paginação. A aplicação foi desenvolvida utilizando [WEB API ASP.NET Core MVC], [Entity Framework Core] e no front [Javascript, jquery, boostrap]

Endpoints da API
GET /api/User/AllUsers: Obter todos os usuários cadastrados.
GET /api/User/skip/{Skip:int}/take/{Take:int}: Paginação de usuários.
GET /api/User/{id}: Obter um usuário por ID.
POST /api/User: Cadastrar um novo usuário.
PUT /api/User/{id}: Atualizar um usuário existente.
DELETE /api/User/{id}: Excluir um usuário.
GET /api/User/pesquisar: Pesquisar usuários com base em critérios.
