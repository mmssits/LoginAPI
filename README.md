# LoginAPI

Esta API permite gerencia o login de usuários, listando os usuários cadastrados, cadastrando novos usuários, editando informações dos mesmos e, até mesmo, excluindo usuários desejados.

## Sumário

- [Instalação](#instalação)
- [Uso](#uso)
- [Tarefas](#tarefas)
- [Exemplos de Solicitação](#exemplos-de-solicitação)
- [Contribuição](#contribuição)
- [Licença](#licença)



## Instalação

Para executar esse projeto localmente, você precisará dos seguintes recursos:

- **Estrutura:** .NetCore (version 8.0.0)
- **Estrutura:** ASP .NetCore (version 8.0.0)
- **Package:** AutoMapper (version 12.0.0)
- **Package:** AutoMapper.Extensions.Microsoft.DependencyInjection (version 12.0.0)
- **Package:** Microsoft.AspNetCore.JsonPatch (version 8.0.0)
- **Package:** Microsoft.AspNetCore.Mvc.NewtonsoftJson (version 8.0.0)
- **Package:** Microsoft.EntityFrameworkCore (version 8.0.0)
- **Package:** Microsoft.EntityFrameworkCore.SqlServer (version 8.0.0)
- **Package:** Microsoft.EntityFrameworkCore.Tools (version 8.0.0)

Para começar, clone o repositório do projeto:

`git clone https://github.com/mmssits/LoginAPI`

Em seguida, navegue até o diretório do projeto e execute o seguinte comando no terminal para iniciá-lo:

`dotnet run`

A API está disponível em `http://localhost:7101`



## Uso

Esta API permite realizar as seguintes operações:

- Criar um novo usuário, verificando se o mesmo já existe ou não através do CPF
- Listar todos os usuários
- Obter detalhes de um usuário específico
- Atualizar dados de um usuário existente
- Excluir um usuário



## Tarefas

- `GET /api/user` - Retorna uma lista de todas os usuários. 
- `GET /api/user/{id}` - Retorna os detalhes de um usuário específico. 
- `POST /api/user` - Cria um novo usuário. 
- `PUT /api/user/{id}` - Atualiza os dados de um usuário existente por inteiro.
- `PATCH /api/user/{id}` - Atualiza dados parciais de um usuário existente. 
- `DELETE /api/user/{id}` - Exclui um usuário específico.


## Exemplo de Solicitação


##### Criar um novo usuário:

`POST/api/user`

``` json
{
	"Name": "Nome",
	"LastName": "Sobrenome",
	"CPF": "00000000000",
	"Email": "nome@gmail.com",
	"Password": "senha123"
}
```


##### Atualizar dados de usuário por inteiro:

`PUT/api/user`

``` json
{
	"Name": "Nome",
	"LastName": "Sobrenome",
	"CPF": "00000000000",
	"Password": "senha123"
}
```


##### Atualizar dados de usuário parcialmente:

`POST/api/user`

``` json
[
	{
		"op": "replace",
		"path": "/Name",
		"value": "Nome Atualizado"
	}
]
```


## Contribuição

Caso queira contribuir com os conteúdos ou sugerir modificações, siga as seguintes etapas:

1. Faça um fork do repositório
2. Crie uma nova branch (`git checkout -b feature/nova-feature`)
3. Faça commit de suas alterações (`git commit -am 'Adiciona nova feature'`)
4. Faça push para a branch (`git push origin feature/nova-feature`)
5. Envie um pull request

Além disso, você pode compartilhar e promover este projeto para contribuir com meu desenvolvimento.


## Licença

Este projeto está licenciado sob a licença [MIT](https://opensource.org/licenses/MIT).


# 

Autoria por Mariana Matos.