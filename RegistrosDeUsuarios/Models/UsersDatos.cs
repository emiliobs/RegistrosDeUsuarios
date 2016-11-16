using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrosDeUsuarios.Models
{
    public class UsersDatos
    {
        UserDataDataContext db = new UserDataDataContext();

        public List<UserDatosModel> UserDatos()
        {
            List<UserDatosModel> userList = new List<UserDatosModel>();

            var users = db.Users.OrderBy(u => u.Name).ToList();

            foreach (var user in users)
            {
                var datos = new UserDatosModel()
                {

                    Name = user.Name,
                    Password = user.Password,
                    LastName = user.LastName,
                    Email = user.Email,
                    User = user.UserName,
                    Id = user.IdUser
                };

                userList.Add(datos);
            }

            return userList;

        }

        public UserDatosModel EditDatos(int id)
        {
            var user = db.Users.SingleOrDefault(u => u.IdUser == id);

            var datos = new UserDatosModel()
            {

                Email = user.Email,
                Id = user.IdUser,
                LastName = user.LastName,
                Name = user.Name,
                Password = user.Password,
                User = user.UserName
            };

            return datos;
        }


        public bool Actualizar(UserDatosModel model)
        {
            var user = db.Users.Single(x=>x.IdUser == model.Id);

            user.Email = model.Email;
            user.LastName = model.LastName;
            user.Name = model.Name;
            user.Password = model.Password;
            user.UserName = model.User;

            db.SubmitChanges();

            return true;

        }

        public bool Eliminar(UserDatosModel model)
        {
            var user = db.Users.Single(x=>x.IdUser == model.Id);

            db.Users.DeleteOnSubmit(user);

            db.SubmitChanges();

            return true;
        }

    }




     public class UserDatosModel
    {
         public int Id { get; set; }

        public string   Name { get; set; }

        public string   LastName { get; set; }

        public string User { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}