using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrosDeUsuarios.Models
{
    public class SessionData
    {
        private string session;

        public string GetSession(string name)
        {
            this.session = Convert.ToString(HttpContext.Current.Session[name]);

            return session;
        }

        public void SetSession(string name, string data)
        {
            HttpContext.Current.Session[name] = data;
        }

        public void DestruirSession()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.RemoveAll();
        }
    }
}