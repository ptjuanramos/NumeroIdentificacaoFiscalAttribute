using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NumeroIdentificacaoFiscalAttribute.Helpers.Tests
{
    [TestFixture]
    public class NifValidationHelper_IsNIFValid
    {
        [Test]
        public void IsNIFValid_InputNotValidNIF_ReturnFalse()
        {
            var result = NifValidationHelper.IsNIFValid("123456789");
            Assert.IsFalse(result);
        }

        [Test]
        public void IsNIFValid_InputNIFLessThanNineDigits_ReturnFalse()
        {
            var result = NifValidationHelper.IsNIFValid("50370687");
            Assert.IsFalse(result);
        }

        [Test]
        public void IsNIFValid_InputValidNIF_ReturnTrue()
        {
            var result = NifValidationHelper.IsNIFValid("503706876");
            Assert.IsTrue(result);
        }
    }
}
