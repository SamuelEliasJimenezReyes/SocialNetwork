using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.ViewModels.Users
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "You must type user Email")]
        [DataType(DataType.Text)]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must have a token")]
        [DataType(DataType.Text)]
        public string Token { get; set; }

        [Required(ErrorMessage = "You must type user  password ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Password dont match")]
        [Required(ErrorMessage = "You must type a password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public bool HasError { get; set; }
        public string? Error { get; set; }
    }
}
