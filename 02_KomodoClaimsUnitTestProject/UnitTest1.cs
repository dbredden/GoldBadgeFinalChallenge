using _02_KomodoClaimsClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _02_KomodoClaimsUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private ClaimRepository _claimRepository;
        private Claim _claimOne;

        [TestInitialize] 
        public void Arrange()
        {
            _claimRepository = new ClaimRepository();
            _claimOne = new Claim(1, ClaimType.Car, "windshield", 200, DateTime.Parse("09/21/2021"), DateTime.Parse("09/23/2021"), true);
        }

        [TestMethod]
        public void AddClaimToDirectory_Test()
        {
            bool wasAdded = _claimRepository.AddClaimToDirectory(_claimOne);
            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void RemoveClaim_Test()
        {
            var _claimTwo = new Claim(2, ClaimType.Home, "home break in", 250, DateTime.Parse("10/01/2021"), DateTime.Parse("10/02/2021"), true);
            _claimRepository.AddClaimToDirectory(_claimTwo);

            var claimList = _claimRepository.GetAllClaims();
            var claimListCount = claimList.Count;

            _claimRepository.RemoveClaim();
            var newClaimList = _claimRepository.GetAllClaims();
            var newClaimListCount = newClaimList.Count;

            bool wasDeleted = newClaimListCount + 1 == claimListCount;

            Assert.IsTrue(wasDeleted);
        }
    }
}
