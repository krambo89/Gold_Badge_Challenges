using System;
using System.Collections.Generic;
using Challenge_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadgeRepositoryUnitTest
{
    [TestClass]

    public class BadgeRepositoryUnitTest
    {
        private BadgesRepository _repo;
        private Badges _badge;

        [TestMethod]
        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgesRepository();
            _badge = new Badges(12345, new List<string> { "a7", "a6" });

            _repo.AddBadgesToDirectory(12345, new List<string> { "a7", "a6" });
        }

        public void GetBadgeRepository_ShouldReturnCorrectItem()
        {
            // Could not figure out how to make this one work//

            // BadgesRepository repo = new BadgesRepository();

          // Badges badge = new Badges();

           // repo.AddBadgesToDirectory(badge);

          //  Dictionary<int, List<string>> direc = repo.GetBadgeDirectory();

           // bool directoryHasBadge = direc.ContainsValue(badge);

           // Assert.IsTrue(directoryHasBadge);
        }
    }
}
