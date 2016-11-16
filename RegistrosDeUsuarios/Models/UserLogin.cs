using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistrosDeUsuarios.Models
{
    public class UserLogin
    {
        [EmailAddress]
        [Required(ErrorMessage = "<font color='red'>Email requerido.</font>")]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}", MinimumLength = 6)]
        [Required(ErrorMessage = "<font color='red'>Password requerido.</font>")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        public string UserName { get; set; }

        private UserDataDataContext user = new UserDataDataContext();

        public bool Login()
        {
            var query = from u in user.Users where u.Email == Email && u.Password == Password select u;


            if (query.Count() > 0)
            {
                //var query2 = from u in user.Users where u.Email == Email select u;
                var datos = query.ToList();

                foreach (var data in datos)
                {
                    UserName = data.UserName;
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}