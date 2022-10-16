using System.ComponentModel.DataAnnotations;

namespace EMarket.Core.Application.ViewModels.Users
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Debe colocar el nombre del usuario")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Debe colocar una password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
