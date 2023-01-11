using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.View
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Digite o Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite a Senha")]
        public string Password { get; set; }
    }
}
