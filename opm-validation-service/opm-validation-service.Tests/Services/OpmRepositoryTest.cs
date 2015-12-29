using NUnit.Framework;
using opm_validation_service.Models;
using opm_validation_service.Persistence;

namespace opm_validation_service.Tests.Services {
    [TestFixture]
    public class OpmRepositoryTest {
        OpmInMemoryRepository repository = new OpmInMemoryRepository();

        EanEicCode validCode = new EanEicCode("859182400123456789");

        [Test]
        public void AddAndCheck() {
            EanEicCode c1 = new EanEicCode("859182400123456789");
            EanEicCode c2 = new EanEicCode("859182400123456789");
            Assert.AreEqual(c1, c2);

            repository.TryAdd(new Opm(validCode));
//            repository.TryGetOpm()
        }
    }
}
