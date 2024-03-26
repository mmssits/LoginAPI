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
        [HttpGet]
        public IEnumerable<ReadUserDTO> RecuperaUsuarios() 
        {
            return _mapper.Map<List<ReadUserDTO>>(_userContext.Usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaUsuarioPorID(int id)
        {
            var user = _userContext.Usuarios.FirstOrDefault(usr => usr.Id == id);

            if (user == null) return NotFound();

            var userDTO = _mapper.Map<ReadUserDTO>(user);

            return Ok(userDTO);
        }

        // Método Create - Post
        [HttpPost]
        public IActionResult CadastrarUser([FromBody] CreateUserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO); // mapeia user para DTO

            _userContext.Usuarios.Add(user);
            _userContext.SaveChanges();

            return Ok();
        }

        // Métodos Update - Put e Patch
        [HttpPut("{id}")] // atualiza todas as informações contidados no UpdateDTO
        public IActionResult AtualizarUsuario(int id, [FromBody] UpdateUserDTO userDTO)
        {
            var user = _userContext.Usuarios.FirstOrDefault(usr => usr.Id == id);

            if (user == null) return NotFound();

            _mapper.Map(userDTO, user);

            _userContext.SaveChanges();

            return NoContent();
        }

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
