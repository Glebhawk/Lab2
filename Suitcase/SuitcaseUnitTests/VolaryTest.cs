using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Suitcase;
using Telerik.JustMock;

namespace SuitcaseUnitTests
{
    [TestClass]
    public class VolaryTest
    {
        [TestMethod]
        public void AddTest()
        {
            //Вовк і вовк
            Volary volary1 = new Volary();
            Wolf wolf1 = new Wolf("Happy Wolf", "ч");
            Wolf TestWolf1 = new Wolf("Вова", "ч");
            volary1.Add(wolf1);
            bool redirected1 = false;
            Mock.NonPublic.Arrange(volary1, "RedirectAnimal", new object[1] { TestWolf1 }).DoInstead(() => redirected1 = true);

            volary1.Add(TestWolf1);

            Assert.IsTrue(redirected1);

            //Вовк і тигриця
            Volary volary2 = new Volary();
            Tiger tiger = new Tiger("Машенька", "ж");
            Wolf TestWolf2 = new Wolf("Вова", "ч");
            volary2.Add(tiger);
            bool redirected2 = false;
            Mock.NonPublic.Arrange(volary2, "RedirectAnimal", new object[1] { TestWolf2 }).DoInstead(() => redirected2 = true);

            volary2.Add(TestWolf2);

            Assert.IsTrue(redirected2);

            // Переповнений вольєр
            Volary volary3 = new Volary();
            for (int i = 0; i < 4; i++)
            {
                Wolf wolf = new Wolf("Вовчиця", "ж");
                volary3.Add(wolf);
            }
            Wolf TestWolf3 = new Wolf("Вова", "ч");
            bool redirected3 = false;
            Mock.NonPublic.Arrange(volary3, "RedirectAnimal", new object[1] { TestWolf3 }).DoInstead(() => redirected3 = true);

            volary3.Add(TestWolf3);

            Assert.IsTrue(redirected3);

            // Вовчиця і вовк
            Volary volary4 = new Volary();
            Wolf wolf2 = new Wolf("Вовчиця", "ж");
            Wolf TestWolf4 = new Wolf("Happy Wolf", "ч");
            volary4.Add(wolf2);
            bool added4 = false;
            Mock.Arrange(() => volary4.animals.Add(TestWolf4)).DoInstead(() => added4 = true);

            volary4.Add(TestWolf4);

            Assert.IsTrue(added4);

            // Вовк і вовчиця
            Volary volary5 = new Volary();
            Wolf wolf5 = new Wolf("Happy Wolf", "ч");
            Wolf TestWolf5 = new Wolf("Вовчиця", "ж");
            volary5.Add(wolf5);
            bool added5 = false;
            Mock.Arrange(() => volary5.animals.Add(TestWolf5)).DoInstead(() => added5 = true);

            volary5.Add(TestWolf5);

            Assert.IsTrue(added5);

            // Порожній вольєр
            Volary volary6 = new Volary();
            Wolf TestWolf6 = new Wolf("Happy Wolf", "ч");
            bool added6 = false;
            Mock.Arrange(() => volary6.animals.Add(TestWolf6)).DoInstead(() => added6 = true);

            volary6.Add(TestWolf6);

            Assert.IsTrue(added6);
        }

        [TestMethod]
        public void BuildVolaryTest()
        {
            //expected
            bool called = false;
            bool redirected = false;

            Volary volary = new Volary();
            Mock.Arrange(() => new Volary()).DoInstead(() => called = true);
            volary.buildVolary();
            VolaryStub volaryStub = new VolaryStub();
            volary.volary = volaryStub;
            Mock.Arrange(() => volaryStub.buildVolary()).DoInstead(() => redirected = true);
            volary.buildVolary();

            Assert.IsTrue(called);
            Assert.IsTrue(redirected);
        }

        [TestMethod]
        public void CallTest()
        {
            //expected
            Wolf wolf = new Wolf("Happy Wolf", "ч");
            Volary volary = new Volary();
            volary.Add(wolf);
            VolaryStub volaryStub = new VolaryStub();
            volary.volary = volaryStub;
            string expexted = "expexted";
            List<string> expectedList = new List<string>() { "expectedList" };

            Mock.Arrange(() => wolf.Voice()).Returns(expexted);
            Mock.Arrange(() => volaryStub.Call()).Returns(expectedList);

            // actual
            List<string> list = volary.Call();

            Assert.AreEqual(expexted, list[0]);
            Assert.AreEqual(expectedList[0], list[1]);
        }

        [TestMethod]
        public void CallByNameTest()
        {
            //expected
            Wolf wolf = new Wolf("Вова", "ч");
            Wolf wolf1 = new Wolf("Чуйка", "ж");
            Wolf wolf2 = new Wolf("Чуйка", "ж");
            Volary volary = new Volary();
            volary.Add(wolf);
            volary.Add(wolf1);
            volary.Add(wolf2);
            VolaryStub volaryStub = new VolaryStub();
            volary.volary = volaryStub;
            string expexted = "expexted";
            List<string> expectedList = new List<string>() { "expectedList" };

            Mock.Arrange(() => wolf1.Voice()).Returns(expexted);
            Mock.Arrange(() => wolf2.Voice()).Returns(expexted);
            Mock.Arrange(() => volaryStub.Call(Arg.IsAny<string>())).Returns(expectedList);

            // actual
            List<string> list = volary.Call("Чуйка");

            Assert.AreEqual(expexted, list[0]);
            Assert.AreEqual(expexted, list[1]);
            Assert.AreEqual(expectedList[0], list[2]);
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void GetFoodTest()
        {
            //expected
            Wolf wolf = new Wolf("Happy Wolf", "ч");
            Volary volary = new Volary();
            volary.Add(wolf);
            VolaryStub volaryStub = new VolaryStub();
            volary.volary = volaryStub;
            double expexted = 8.0;

            Mock.Arrange(() => wolf.dailyFood).Returns(4.0);
            Mock.Arrange(() => volaryStub.GetFood()).Returns(4.0);

            // actual
            double actual = volary.GetFood();

            Assert.AreEqual(expexted, actual);
        }

        [TestMethod]
        public void CountAnimalsTest()
        {
            //expected
            Volary volary = new Volary();
            VolaryStub volaryStub = new VolaryStub();
            volary.volary = volaryStub;
            int expexted = 1;

            Mock.Arrange(() => volaryStub.CountAnimals()).Returns(1);

            // actual
            int actual = volary.CountAnimals();

            Assert.AreEqual(expexted, actual);
        }

        [TestMethod]
        public void CountTest()
        {
            //expected
            int expected = 1;
            bool called = false;
            Volary volary = new Volary();
            VolaryStub volaryStub = new VolaryStub();
            volary.volary = volaryStub;

            Mock.Arrange(() => volaryStub.Count()).DoInstead(() => called = true);

            // actual
            int actual = volary.Count();

            Assert.AreEqual(expected, actual);
        }
    }

    class VolaryStub : Volary
    {

    }
}
