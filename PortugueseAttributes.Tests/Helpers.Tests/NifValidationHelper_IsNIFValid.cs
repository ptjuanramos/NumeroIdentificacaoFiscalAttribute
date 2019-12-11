using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortugueseAttributes.Helpers.Tests
{
    [TestClass]
    public class NifValidationHelper_IsNIFValid
    {
        [TestMethod]
        public void IsNIFValid_InputNotValidNIF_ReturnFalse()
        {
            var result = NifValidationHelper.IsNIFValid("987654321");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNIFValid_InputNIFLessThanNineDigits_ReturnFalse()
        {
            var result = NifValidationHelper.IsNIFValid("50370687");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNIFValid_InputValidNIF_ReturnTrue()
        {
            var result = NifValidationHelper.IsNIFValid("503706876");
            Assert.IsTrue(result);
        }
    }
}
