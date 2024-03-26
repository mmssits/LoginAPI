using System.ComponentModel.DataAnnotations;

namespace LoginAPI.Data.DTOs
{
    public class UpdateUserDTO
    {
        [Required(ErrorMessage = "O primeiro nome é um campo obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O sobrenome é um campo obrigatório.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "O CPF é um campo obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter entre 11 caracteres, contendo apenas números.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "A senha é um campo obrigatório.")]
        [MinLength(8, ErrorMessage = "A senha deve conter, no mínimo, 8 caracteres.")]
        public string Password { get; set; }
    }
}
