using System;
using System.IO;
using System.Net;
using System.Security.Authentication;

namespace opm_validation_service.Services {
    public class IdentityManagement : IIdentityManagement {
        private static readonly Uri SsoUrl = new Uri(@"https://am-proxytest.bohemiaenergy.cz/opensso/identity/");

        public bool ValidateUser(string token) {
            try {
                string validationString = HttpGet("isTokenValid?tokenid=" + token);
                return validationString.Split("=".ToCharArray())[1].StartsWith("true");
            } catch (WebException ex) {
                HttpStatusCode statusCode = ((HttpWebResponse)ex.Response).StatusCode;
                if (statusCode == HttpStatusCode.Unauthorized) {
                    return false;
                }
                throw;
            }
        }

        private string HttpGet(string restOfUri, string token = "") {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(SsoUrl + restOfUri);
            request.Method = "GET";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.CookieContainer = new CookieContainer();
            if (token != "") {
                Cookie c = new Cookie("iPlanetDirectoryPro", token);
                c.Domain = SsoUrl.Host;
                request.CookieContainer.Add(c);
            }
            Stream responseStream = request.GetResponse().GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            return reader.ReadToEnd();
        }

        public IUser GetUserInfo(string token) {
            try {
                string userInfoString = HttpGet("attributes", token);
                return createUser(userInfoString);
            } catch (WebException ex) {
                HttpStatusCode statusCode = ((HttpWebResponse)ex.Response).StatusCode;
                if (statusCode == HttpStatusCode.Unauthorized) {
                    return null;
                }
                throw;
            }
        }

        private IUser createUser(string userInfoString)
        {
            bool uidRead = false;
            foreach (string s in userInfoString.Split("\n".ToCharArray()))
            {
                if (uidRead)
                {
                    string uid = s.Split("=".ToCharArray())[1];
                    return new User(uid);
                }
                uidRead = (s == "userdetails.attribute.name=uid");
            }
            throw new Exception();
        }

        public string Login(string userName, string password)
        {
            string validationString = HttpGet("authenticate?username=" + userName + "&password=" + password);

            string[] validationResult = validationString.Split("=".ToCharArray());

            if (validationResult[0] == "token.id")
            {
                return validationResult[1];
            }
            throw new AuthenticationException("Login failed.");
        }
    }
}