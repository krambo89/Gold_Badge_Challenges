using System;
using System.Collections.Generic;
using GoldBadge_Challenges;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Menu_UnitTest
{
    [TestClass]
    public class MenuRepositortyTest
    {
        private MenuRepository _repo;
        private Menu _item;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepository();

            _item = new Menu(1, "Ham Sandwhich.", "Ham Pattie on a bun.", (decimal)3.00, "Ham Pattie, White Bun, American Cheese, Lettuce, Tomato, Mustard");

            _repo.AddItemToMenu(_item);
        }

        [TestMethod]
        public void GetMenu_ShouldReturnCorrectItem()
        {

            MenuRepository repo = new MenuRepository();

            Menu ham = new Menu();

            repo.AddItemToMenu(ham);

            List<Menu> menu = repo.GetMenu();

            bool directoryHasHam = menu.Contains(ham);

            Assert.IsTrue(directoryHasHam);
        }

        [TestMethod]
        public void DeleteExistingItem_ShouldReturnTrue()
        {
            bool removeResult = _repo.DeleteExistingItem(_item);

            Assert.IsTrue(removeResult);
        }

        [DataTestMethod]
        [DataRow(1, true)]
        [DataRow(2, false)]
        public void DeleteByItemName_ShouldReturnCorrectBool(int mealNumber, bool expectedResult)
        {
            bool actualResult = _repo.DeleteItemByMealNumber(mealNumber);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}