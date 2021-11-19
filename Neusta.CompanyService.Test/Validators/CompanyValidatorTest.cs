using Neusta.CompanyService.Abstraction.Exceptions;
using Neusta.CompanyService.Validators;
using NUnit.Framework;

namespace Neusta.CompanyService.Test.Validators
{
    [TestFixture]
    public class CompanyValidatorTest
    {
        private CompanyValidator validator;

        [SetUp]
        public void SetUp()
        {
            validator = new CompanyValidator();
        }

        [Test]
        public void CompanyNotFoundThrowsException()
        {
            CompanyNotFoundException exception =
                Assert.Throws<CompanyNotFoundException>(() => validator.FoundCompany(null));

            Assert.That(exception.Message, Is.EqualTo("No company found"));
        }
    }
}