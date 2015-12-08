using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opm_validation_service.Services;

namespace opm_validation_service.Tests {
    [TestClass]
    public class IdentityManagementTest {
        [TestMethod]
        public void BasicImTest() {
            IdentityManagement im = new IdentityManagement();
            bool userValid = im.ValidateUser("cxv");
            Console.WriteLine("user {0} was valid ={1}.", "cxv", userValid);
            IUser user = im.GetUserInfo("cxv");
            Console.WriteLine("user {0} userid ={1}.", "cxv", user == null ? "N/A" : user.Id.ToString());

            userValid = im.ValidateUser("AQIC5wM2LY4SfcwVw9OdT3tA9TWaxy7IzGUuC5echSPcgb4.*AAJTSQACMDE.*");
            Console.WriteLine("user {0} was valid ={1}.", "AQIC5wM2LY4SfcwVw9OdT3tA9TWaxy7IzGUuC5echSPcgb4.*AAJTSQACMDE.*", userValid);
            IUser user2 = im.GetUserInfo("AQIC5wM2LY4SfcwVw9OdT3tA9TWaxy7IzGUuC5echSPcgb4.*AAJTSQACMDE.*");
            Console.WriteLine("user {0} userid ={1}.", "AQIC5wM2LY4SfcwVw9OdT3tA9TWaxy7IzGUuC5echSPcgb4.*AAJTSQACMDE.*", user2==null?"N/A":user2.Id.ToString());
        }
    }
}
