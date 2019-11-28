using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using Suitcase;
using System.Collections.Generic;

namespace SuitcaseUnitTests
{
    [TestClass]
    public class DayTimeTest
    {
        [TestMethod]
        public void DayChangeTest()
        {
            //expexted
            string expected = "У валiзi настала нiч!";
            bool called = false;
            Mock.SetupStatic(typeof(Case));
            Mock.Arrange(() => new Night()).DoInstead(() => called = true);

            //actual
            Day day = new Day();
            string actual = day.Change();

            Assert.AreEqual(expected, actual);
            Assert.IsTrue(called);
        }

        [TestMethod]
        public void DayCallEveryoneTest()
        {
            //expexted
            Mock.SetupStatic(typeof(Case));
            List<string> expectedList = new List<string>() {"Expected string"};
            Mock.Arrange(() => Case.room.Call()).Returns(expectedList);
            Mock.Arrange(() => Case.pasture.Call()).Returns(expectedList);

            //actual
            Day day = new Day();
            List<string> actualList = new List<string>();
            day.CallEveryone(actualList);

            Assert.AreEqual(expectedList[0], actualList[0]);
            Assert.AreEqual(expectedList[0], actualList[1]);
        }

        [TestMethod]
        public void DayGetTimeTest()
        {
            //expexted
            string expected = "У валiзi зараз день. Що ви хочете зробити?";

            //actual
            Day day = new Day();
            string actual = day.GetTime();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NightChangeTest()
        {
            //expexted
            string expected = "У валiзi настав день!";
            bool called = false;
            Mock.SetupStatic(typeof(Case));
            Mock.Arrange(() => new Day()).DoInstead(() => called = true);

            //actual

            Night night = new Night();
            string actual = night.Change();

            Assert.AreEqual(expected, actual);
            Assert.IsTrue(called);
        }

        [TestMethod]
        public void NightCallEveryoneTest()
        {
            //expexted
            Mock.SetupStatic(typeof(Case));
            List<string> expectedList = new List<string>() { "Усi тварини зараз сплять." };

            //actual
            Night night = new Night();
            List<string> actualList = new List<string>();
            night.CallEveryone(actualList);

            Assert.AreEqual(expectedList[0], actualList[0]);
        }

        [TestMethod]
        public void NightGetTimeTest()
        {
            //expexted
            string expected = "У валiзi зараз нiч. Що ви хочете зробити?";

            //actual
            Night night = new Night();
            string actual = night.GetTime();

            Assert.AreEqual(expected, actual);
        }
    }
}
