![Texto alternativo](https://raw.githubusercontent.com/Julianavdsantos/Cadastro-de-Clientes/master/EmccampTela.png)


---

# Projeto CRUD de Cadastro de Usuários

Este projeto é uma aplicação web para gerenciar o cadastro de usuários, utilizando operações CRUD (Create, Read, Update, Delete) para manipulação dos dados com Api, incluindo campos de pesquisa de usuário com base em termos de busca e paginação. A aplicação foi desenvolvida utilizando [WEB API ASP.NET Core MVC], [Entity Framework Core] e no front [Javascript, jquery, boostrap].



## Endpoints da API

- `GET /api/User/AllUsers`: Obter todos os usuários cadastrados.
- `GET /api/User/skip/{Skip:int}/take/{Take:int}`: Paginação de usuários.
- `GET /api/User/{id}`: Obter um usuário por ID.
- `POST /api/User`: Cadastrar um novo usuário.
- `PUT /api/User/{id}`: Atualizar um usuário existente.
- `DELETE /api/User/{id}`: Excluir um usuário.
- `GET /api/User/pesquisar`: Pesquisar usuários com base em critérios.

## Configuração e Execução

1. Clone este repositório em sua máquina local.
2. Certifique-se de ter as ferramentas necessárias instaladas.
3. Configure o banco de dados e a conexão com o Entity Framework Core.
4. O front será executado no arquvo index.html. http://localhost:5267


