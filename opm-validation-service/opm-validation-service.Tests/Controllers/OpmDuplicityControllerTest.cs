using NUnit.Framework;
using opm_validation_service.Controllers;
using opm_validation_service.Models;
using opm_validation_service.Services;

namespace opm_validation_service.Tests.Controllers {

    [TestFixture]
    public class OpmDuplicityControllerTest{

        /// <summary>
        /// All the combinations tested in the EanEicCheckServiceUnitTest; this is just a test for checking the post going through the controller.
        /// </summary>
        [Test]
        public void Get()
        {
            OpmVerificator opmVerificator = null;
            OpmDuplicityController controller = new OpmDuplicityController(opmVerificator);
            Assert.IsFalse(controller.Get("859182400123456789").Result);
        }
    }
}
