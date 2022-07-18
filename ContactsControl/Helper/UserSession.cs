using ContactsControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ContactsControl.Helper
{
    public class UserSession : IUserSession
    {
        private readonly IHttpContextAccessor _httpContext;

        public UserSession(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public void OverUserSession()
        {
            _httpContext.HttpContext.Session.Remove("userSessionSignedIn");
        }

        public UserModel SearchUserSession()
        {
            string userSession = _httpContext.HttpContext.Session.GetString("userSessionSignedIn");

            if (string.IsNullOrEmpty(userSession)) return null;

            return JsonConvert.DeserializeObject<UserModel>(userSession);
        }

        public void StartUserSession(UserModel user)
        {
            string value = JsonConvert.SerializeObject(user);

            _httpContext.HttpContext.Session.SetString("userSessionSignedIn", value);
        }
    }
}
