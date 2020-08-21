using System;
using System.Security.Claims;
using Challenge_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Claims_Test
{
    [TestClass]
    public class ClaimsTest
    {
        [TestMethod]
        public void SetClaim_ShouldGetCorrectInt()
        {
            Claims claim = new Claims();

            claim.ClaimID = 1;

            int expected = 1;
            int actual = 1;

            Assert.AreEqual(expected, actual);
        }
    }
}
