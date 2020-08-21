using System;
using GoldBadge_Challenges;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Menu_UnitTest
{
    [TestClass]
    public class MenuTest
    {
        [TestMethod]
        public void SetMenuItem_ShouldGetCorrectString()
        {
            Menu item = new Menu();
            item.MealName = "Ham Sandwhich";
            string expected = "Ham Sandwhich";
            string actual = item.MealName;
            Assert.AreEqual(expected, actual);
        }
    }
}
