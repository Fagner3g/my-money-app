using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myMoneAppAPI.Services
{
    public class myMoneySeguranca
    {
        public static bool Login(string login, string senha)
        {
            var usuario = new
            {
                login = "fagner.gomes",
                senha = "alfa4721"
            };

            if (usuario.login == login && usuario.senha == senha)
                return true;
            else
                return false;
        }
    }
}