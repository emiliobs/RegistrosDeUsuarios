using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace DropDownListMVC.Models
{
    public class UsersData
    {
        [DataType(DataType.Text)]
        [DisplayName("Users")]
        [UIHint("List")]
        public List<SelectListItem> usersLista { get; set; }


        public int Id { get; set; }

        public UsersData()
        {
            DataUsersDataContext db = new DataUsersDataContext();

            usersLista = new List<SelectListItem>();

            var users = db.Users.ToList();

            foreach (var user in users)
            {
                usersLista.Add(new SelectListItem()
                {
                    Value = user.IdUser.ToString(),
                    Text = user.Name

                });
            }
        }


    }
}