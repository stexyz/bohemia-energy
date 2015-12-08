using System;
using System.IO;
using System.Net;

namespace opm_validation_service.Services {
    public class IdentityManagement : IIdentityManagement {
        //TODO SP: change type string -> Url ?
        //TODO SP: validate the token

        private static readonly Uri SsoUrl = new Uri(@"https://am-proxytest.bohemiaenergy.cz/opensso/identity/");

        public bool ValidateUser(string token) {
            try {
                string validationString = HttpGet("isTokenValid?tokenid=" + token);
                Console.WriteLine(validationString);
                return validationString.Split("=".ToCharArray())[1].StartsWith("true");
            } catch (WebException ex) {
                HttpStatusCode statusCode = ((HttpWebResponse)ex.Response).StatusCode;
                if (statusCode == HttpStatusCode.Unauthorized) {
                    Console.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
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
                Console.WriteLine(userInfoString);
                return new User();
            } catch (WebException ex) {
                HttpStatusCode statusCode = ((HttpWebResponse)ex.Response).StatusCode;
                if (statusCode == HttpStatusCode.Unauthorized) {
                    Console.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
                    return null;
                }
                throw;
            }
        }

    }
}