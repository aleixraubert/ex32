using Microsoft.VisualStudio.TestPlatform.TestHost;
using Prog;

namespace Prog_test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EvilHigher()
        {
            int evil = 52000;
            int Min_evil = 1000;
            int Max_evil = 50000;

            bool expected = false;

            bool actual = Batalla.EvilIsInLimits(evil, Min_evil, Max_evil);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EvilLower()
        {
            int evil = 500;
            int Min_evil = 1000;
            int Max_evil = 50000;

            bool expected = false;

            bool actual = Batalla.EvilIsInLimits(evil, Min_evil, Max_evil);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EvilRight()
        {
            int evil = 12000;
            int Min_evil = 1000;
            int Max_evil = 50000;

            bool expected = true;

            bool actual = Batalla.EvilIsInLimits(evil, Min_evil, Max_evil);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HasTwoVowels()
        {
            string name = "Aa";
            bool expected = true;

            bool actual = Batalla.CheckIfHasTwoVowels(name);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HasNotTwoVowels()
        {
            string name = "Daddf";
            bool expected = false;

            bool actual = Batalla.CheckIfHasTwoVowels(name);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HighLength()
        {
            string name = "holaholaholaholaholaholahola";
            int min = 2;
            int max = 25;

            bool expected = false;

            bool actual = Batalla.CheckStringLength(name, min, max);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LowerLength()
        {
            string name = "a";
            int min = 2;
            int max = 25;

            bool expected = false;

            bool actual = Batalla.CheckStringLength(name, min, max);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CorrectLength()
        {
            string name = "aleix";
            int min = 2;
            int max = 25;

            bool expected = true;

            bool actual = Batalla.CheckStringLength(name, min, max);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HasSpecialChars()
        {
            string name = "aleix!";

            bool expected = true;

            bool actual = Batalla.CheckIfHasSpecialChars(name);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HasNotSpecialChars()
        {
            string name = "aleix";

            bool expected = false;

            bool actual = Batalla.CheckIfHasSpecialChars(name);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalcEvilWin()
        {
            int evil = 10000;
            bool win = true;

            int expected = 2500;

            int actual = Batalla.CalcEvil(evil, win);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalcEvilLose()
        {
            int evil = 10000;
            bool win = false;

            int expected = 125;

            int actual = Batalla.CalcEvil(evil, win);

            Assert.AreEqual(expected, actual);
        }
    }
}