using System.ComponentModel.DataAnnotations;

namespace Imtahan_Sim_2.ViewModels.Account
{
    public class RegisterVm
    {
        [MinLength(3)]
        public string Name { get; set; }
        [MinLength(3)]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [MinLength(4)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public bool RememberMe { get; set; }
    }
}
