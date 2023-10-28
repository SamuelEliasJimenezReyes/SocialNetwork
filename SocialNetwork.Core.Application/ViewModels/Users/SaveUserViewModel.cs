using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.ViewModels.Users
{
    public class SaveUserViewModel
    {
        public string? ImagePath { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? File { get; set; }

        [Required(ErrorMessage = "You must type user Fristname")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You must type user Lastname")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You must type an Username")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required(ErrorMessage = "You must type a password")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@!.\-_])[A-Za-z\d@!.\-_]{8,}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Password dont match")]
        [Required(ErrorMessage = "You must type a password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "You must type an Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must type a phone number")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Phone number must be in the a format like this 123-456-7890")]
        [DataType(DataType.Text)]
        public string Phone { get; set; }

        public bool HasError { get; set; }
        public string? Error { get; set; }
    }
}

