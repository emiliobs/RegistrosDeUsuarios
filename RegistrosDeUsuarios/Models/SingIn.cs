using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Configuration;
using System.Web;

namespace RegistrosDeUsuarios.Models
{
    public class SingIn
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public String User { get; set; }

        [EmailAddress]
        [Required]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        [StringLength(100,ErrorMessage = "El número maximo de caracteres {1} de {0}, y el minimo es {1} ", MinimumLength = 6)]
        public string Password { get; set; }

        UserDataDataContext user = new UserDataDataContext();
        private User obj = new User();

        public bool singIn()
        {
            var query = user.Users.Count(u => u.Email == Email || u.UserName ==  User);



            if (query > 0)
            {
                return false;
            }
            else
            {
                obj.Name = Name;
                obj.LastName = LastName;
                obj.UserName = User;
                obj.Email = Email;
                obj.Password = Password;


                user.Users.InsertOnSubmit(obj);
                user.SubmitChanges();
                return true;
            }
        }
    }
}