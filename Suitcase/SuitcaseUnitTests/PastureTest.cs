using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Suitcase;
using Telerik.JustMock;
using System.Collections.Generic;

namespace SuitcaseUnitTests
{
    [TestClass]
    public class PastureTest
    {
        [TestMethod]
        public void PastureAddTest()
        {
            //expected
            string expextedAdded = "Тварину заселено.";
            string expextedPastureOvercrowded = "Неможливо заселити тварину! Немає вiльних пасовиськ!";
            // Хочемо отримати відповідь від повністю забитого пасовища
            Horse horse = new Horse("Знайда", "ч");
            Pasture overcrowded = new Pasture();
            for (int i = 0; i < 20; i++)
            {
                Horse crowd = new Horse("Табун", "ч");
                overcrowded.animals.Add(crowd);
            }
            Mock.Arrange(() => overcrowded.Add(horse)).Returns(expextedPastureOvercrowded);
            // Хочемо отримати підтвердження від пасовища, що передало тварину іншому пасовищу
            Deer lostDeer = new Deer("Приблуда", "ч");
            Pasture overcrowdedWithDeers = new Pasture();
            for (int i = 0; i < 20; i++)
            {
                Deer crowd = new Deer("Стадо", "ч");
                overcrowdedWithDeers.animals.Add(crowd);
            }
            Mock.Arrange(() => overcrowdedWithDeers.Add(lostDeer)).Returns(expextedAdded);

            //actual
            string actualOvercrowded = overcrowded.Add(horse);
            Deer deer = new Deer("Олень", "ч");
            Pasture pasture = new Pasture();
            string actualAdded = pasture.Add(deer);
            string redirected = overcrowdedWithDeers.Add(lostDeer);

            Assert.AreEqual(expextedAdded, actualAdded);
            Assert.AreEqual(expextedPastureOvercrowded, actualOvercrowded);
            Assert.AreEqual(expextedAdded, redirected);
        }

        [TestMethod]
        public void PastureBuildTest()
        {
            //expected
            bool called = false;
            bool redirected = false;

            Pasture pasture = new Pasture();
            Mock.Arrange(() => new Pasture()).DoInstead(() => called = true);
            pasture.BuildPasture();
            PastureStub pastureStub = new PastureStub();
            pasture.pasture = pastureStub;
            Mock.Arrange(() => pastureStub.BuildPasture()).DoInstead(() => redirected = true);
            pasture.BuildPasture();

            Assert.IsTrue(called);
            Assert.IsTrue(redirected);
        }

        [TestMethod]
        public void CallTest()
        {
            //expected
            Horse horse = new Horse("Шептало", "ч");
            Pasture pasture = new Pasture();
            pasture.Add(horse);
            PastureStub pastureStub = new PastureStub();
            pasture.pasture = pastureStub;
            string expexted = "expexted";
            List<string> expectedList = new List<string>() {"expectedList" };

            Mock.Arrange(() => horse.Voice()).Returns(expexted);
            Mock.Arrange(() => pastureStub.Call()).Returns(expectedList);

            // actual
            List<string> list = pasture.Call();

            Assert.AreEqual(expexted, list[0]);
            Assert.AreEqual(expectedList[0], list[1]);
        }

        [TestMethod]
        public void CallByNameTest()
        {
            //expected
            Horse horse = new Horse("Шептало", "ч");
            Deer deer = new Deer("Олень", "ч");
            Deer deer1 = new Deer("Олень", "ч");
            Pasture pasture = new Pasture();
            pasture.Add(horse);
            pasture.Add(deer);
            pasture.Add(deer1);
            PastureStub pastureStub = new PastureStub();
            pasture.pasture = pastureStub;
            string expexted = "expexted";
            List<string> expectedList = new List<string>() { "expectedList" };

            Mock.Arrange(() => deer.Voice()).Returns(expexted);
            Mock.Arrange(() => deer1.Voice()).Returns(expexted);
            Mock.Arrange(() => pastureStub.Call(Arg.IsAny<string>())).Returns(expectedList);

            // actual
            List<string> list = pasture.Call("Олень");

            Assert.AreEqual(expexted, list[0]);
            Assert.AreEqual(expexted, list[1]);
            Assert.AreEqual(expectedList[0], list[2]);
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void GetFoodTest()
        {
            //expected
            Horse horse = new Horse("Шептало", "ч");
            Pasture pasture = new Pasture();
            pasture.Add(horse);
            PastureStub pastureStub = new PastureStub();
            pasture.pasture = pastureStub;
            double expexted = 11.0;

            Mock.Arrange(() => horse.dailyFood).Returns(1.0);
            Mock.Arrange(() => pastureStub.GetFood()).Returns(10.0);

            // actual
            double actual = pasture.GetFood();

            Assert.AreEqual(expexted, actual);
        }

        [TestMethod]
        public void CountAnimalsTest()
        {
            //expected
            Pasture pasture = new Pasture();
            PastureStub pastureStub = new PastureStub();
            pasture.pasture = pastureStub;
            int expexted = 1;

            Mock.Arrange(() => pastureStub.CountAnimals()).Returns(1);

            // actual
            int actual = pasture.CountAnimals();

            Assert.AreEqual(expexted, actual);
        }
    }
     class PastureStub : Pasture
    {

    }
}
