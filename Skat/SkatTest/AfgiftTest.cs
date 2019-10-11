using System;
using System.Reflection.Metadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skat;

namespace SkatTest
{
    [TestClass]
    public class AfgiftTest
    {
        [TestMethod]
        public void BilAfgiftUnder200000()
        {
            // ARRANGE
            Afgift afgift = new Afgift();
            int pris = 150000;
            double expected = pris * 0.85;

            // ACT
            int actual = afgift.BilAfgift(pris);

            // ASSERT
            Assert.AreEqual((int)expected, actual, "Are not equal");
        }

        [TestMethod]
        public void BilAfgiftOver200000()
        {
            // ARRANGE
            Afgift afgift = new Afgift();
            int pris = 300000;
            double expected = (pris * 1.50) - 130000;

            // ACT
            int actual = afgift.BilAfgift(pris);

            // ASSERT
            Assert.AreEqual((int)expected, actual, "Are not equal");
        }

        public void BilAfgiftUnder0()
        {
            // ARRANGE
            Afgift afgift = new Afgift();
            int pris = -1000;
            
            // ACT & ASSERT
            try
            {
                afgift.BilAfgift(pris);
                Assert.Fail(); // If it gets to this line, no exception was thrown.
            }
            catch (ArgumentException)
            { }
        }

        [TestMethod]
        public void ElBilAfgiftUnder200000()
        {
            // ARRANGE
            Afgift afgift = new Afgift();
            int pris = 120000;
            double expected = (pris * 0.85)*0.20;
        
            // ACT
            int actual = afgift.ElBilAfgift(pris);

            // ASSERT
            Assert.AreEqual((int)expected, actual, "Are not equal");
        }

        [TestMethod]
        public void ElBilAfgiftOver200000()
        {
            // ARRANGE
            Afgift afgift = new Afgift();
            int pris = 400000;
            double expected = ((pris * 1.50) - 130000) * 0.20;

            // ACT
            int actual = afgift.ElBilAfgift(pris);

            // ASSERT
            Assert.AreEqual(expected, actual, "Are not equal");
        }

        [TestMethod]
        public void ElBilAfgiftUnder0()
        {
            // ARRANGE
            Afgift afgift = new Afgift();
            int pris = -35000;
            
            // ACT & ARRANGE
            try
            {
                afgift.ElBilAfgift(pris);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }
        }
    }
}
