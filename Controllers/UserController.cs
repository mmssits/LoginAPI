using AutoMapper;
using LoginAPI.Data;
using LoginAPI.Data.DTOs;
using LoginAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

namespace LoginAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserContext _userContext;
        private readonly IMapper _mapper;

        // Construtor - injeção de dependência para manipular o banco
        public UserController(UserContext userContext, IMapper mapper) 
        {
            _userContext = userContext;
            _mapper = mapper;
        }


        // Métodos Read - Get e GetId
        /// <summary>
        /// Lista todos os usuários existentes.
        /// </summary>
        /// <returns>Os usuários cadastrados na tabela</returns>

        [HttpGet]
        public IEnumerable<ReadUserDTO> RecuperaUsuarios() 
        {
            return _mapper.Map<List<ReadUserDTO>>(_userContext.Usuarios);
        }

        /// <summary>
        /// Lista um usuário específico através do CPF.
        /// </summary>
        /// <returns>Usuário específico por CPF</returns>

        [HttpGet("{cpf}")]
        public IActionResult RecuperaUsuarioPorID(string cpf)
        {
            var user = _userContext.Usuarios.FirstOrDefault(usr => usr.CPF == cpf);

            if (user == null) return NotFound();

            var userDTO = _mapper.Map<ReadUserDTO>(user);

            return Ok(userDTO);
        }

        // Método Create - Post
        /// <summary>
        /// Cadastra um usuário na tabela de usuários, verificando se o CPF já não está em uso.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /LoginAPI
        ///     {
        ///        "Name": "Nome",
	    ///        "LastName": "Sobrenome",
	    ///        "CPF": "00000000000",
	    ///        "Email": "nome@gmail.com",
	    ///        "Password": "senha123"
        ///     }
        ///     
        /// </remarks>
        /// <returns>Um novo usuário criado</returns>
        /// <response code = "201">Retorna o novo usuário cadastrado</response>
        /// <response code = "400">Não foi possível cadastrar o usuário</response>
        
        [HttpPost]
        public IActionResult CadastrarUser([FromBody] CreateUserDTO userDTO)
        {
            // verifica se usuario existe por meio do cpf
            var userExist = _userContext.Usuarios.FirstOrDefault(usr => usr.CPF ==  userDTO.CPF);

            if (userExist != null) return Conflict("CPF já está em uso.");

            // caso o usuario não exista, cria o mesmo
            User user = _mapper.Map<User>(userDTO); // mapeia user para DTO 

            _userContext.Usuarios.Add(user);
            _userContext.SaveChanges();

            return Ok();
        }

        // Métodos Update - Put e Patch
        /// <summary>
        /// Realiza atualização dos dados de um usuário de maneira integral.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     PUT /LoginAPI
        ///     {
        ///        "Name": "Nome",
	    ///        "LastName": "Sobrenome",
	    ///        "CPF": "00000000000",
	    ///        "Password": "senha123"
        ///     }
        ///     
        /// </remarks>
        /// <response code = "201">Retorna o usuário atualizado</response>
        /// <response code = "400">Não foi possível atualizar o usuário</response>

        [HttpPut("{id}")] // atualiza todas as informações contidados no UpdateDTO
        public IActionResult AtualizarUsuario(int id, [FromBody] UpdateUserDTO userDTO)
        {
            var user = _userContext.Usuarios.FirstOrDefault(usr => usr.Id == id);

            if (user == null) return NotFound();

            _mapper.Map(userDTO, user);

            _userContext.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Realiza atualização dos dados de um usuário de maneira parcial.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     PATCH /LoginAPI
        ///     {
        ///        "op": "replace",
		///        "path": "/Name",
		///        "value": "Nome Atualizado"
        ///     }
        ///     
        /// </remarks>
        /// <response code = "201">Retorna o usuário atualizado</response>
        /// <response code = "400">Não foi possível atualizar o usuário</response>

        [HttpPatch("{id}")]
        public IActionResult AtualizarUsuarioParcial(int id, JsonPatchDocument<UpdateUserDTO> patchDocument)
        {
            var user = _userContext.Usuarios.FirstOrDefault(usr => usr.Id == id);

            if (user == null) return NotFound();

            var userUpdate = _mapper.Map<UpdateUserDTO>(user);

            patchDocument.ApplyTo(userUpdate, ModelState);

            if (!ModelState.IsValid) { return ValidationProblem(ModelState); }

            _mapper.Map(userUpdate, user);

            _userContext.SaveChanges();

            return NoContent();
        }

        // Método Delete - Delete

        /// <summary>
        /// Realiza a exclusão de um usuário por meio do ID.
        /// </summary>

        [HttpDelete("{id}")]
        public IActionResult ExcluirUsuario(int id) 
        {
            var user = _userContext.Usuarios.FirstOrDefault(usr => usr.Id == id);

            if (user == null) return NotFound();

            _userContext.Remove(user);

            _userContext.SaveChanges();

            return NoContent();
        }
        
    }
}
