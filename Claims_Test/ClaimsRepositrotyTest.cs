using System;
using System.Collections.Generic;
using Challenge_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Claims_Test
{
    [TestClass]
    public class ClaimsRepositrotyTest
    {

        private ClaimsRepository _repo;
        private Claims _claim;

        [TestMethod]
        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimsRepository();

            _claim = new Claims(1, "Car", "Car Wreck", 300.10d, new DateTime(2018, 7, 30), new DateTime(2018, 7, 30), true);

            _repo.AddClaimsToDirectory(_claim);
        }


        [TestMethod]
        public void GetClaimsDirectory_ShouldReturnCorrectItem()
        {

            ClaimsRepository repo = new ClaimsRepository();

            Claims car = new Claims();

            repo.AddClaimsToDirectory(car);

            Queue<Claims> direc = repo.GetClaimsDirectory();

            bool directoryHasCar = direc.Contains(car);

            Assert.IsTrue(directoryHasCar);
        }


            [TestMethod]
        public void DeleteExistingClaim_ShouldReturnTrue()
        {
            int claimCount = _repo.GetClaimsDirectory().Count;

              _repo.DeleteExistingClaim();

            int newClaimCount = _repo.GetClaimsDirectory().Count;

            Assert.IsTrue(newClaimCount < claimCount);
        }

        
    }
}