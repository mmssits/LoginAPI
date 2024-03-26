using System.ComponentModel.DataAnnotations;

namespace LoginAPI.Data.DTOs
{
    public class CreateUserDTO
    {
        [Required(ErrorMessage = "O primeiro nome é um campo obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O sobrenome é um campo obrigatório.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "O CPF é um campo obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter entre 11 caracteres, contendo apenas números.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O e-mail é um campo obrigatório.")]
        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$", ErrorMessage = "Informe um e-mail válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é um campo obrigatório.")]
        [MinLength(8, ErrorMessage = "A senha deve conter, no mínimo, 8 caracteres.")]
        public string Password { get; set; }
    }
}
